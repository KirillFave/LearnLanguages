class WheelList {
    add() {
        const name = document.getElementById('new-list-name').value.trim();

        $.ajax({
            url: '/Wheel?handler=AddList',
            method: 'POST',
            data: {
                name: name,
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            }
        })
        .then((response) =>
            document.getElementById('wheel').outerHTML = response);
    }

    getListPartialView(guid) {
        return $.ajax({
            url: '/Wheel?handler=ListPartialView',
            method: 'GET',
            data: {
                guid: guid,
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            }
        });
    }

    addItem() {
        const listGuid = document.getElementById('wheel').dataset.listGuid;

        const titleInput = document.getElementById('item-title-input');
        const title = titleInput.value;

        const definitionInput = document.getElementById('item-definition-input');
        const definition = definitionInput.value;

        $.ajax({
            url: '/Wheel?handler=AddItem',
            method: 'POST',
            data: {
                listGuid: listGuid,
                title: title,
                definition: definition,
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            }
        })
        .then((response) => {
            document.getElementById('items').insertAdjacentHTML('beforeend', response);
            titleInput.value = '';
            definitionInput.value = '';
            this.drawWheel();
        });
    }

    canvas = NaN;
    ctx = NaN;
    spinBtn = NaN;
    resetBtn = NaN;
    sectors = 0;
    rotationAngle = 0; // текущий угол поворота колеса (в радианах)
    isSpinning = false;
    animationFrame = null;
    spinVelocity = 0; // текущая угловая скорость (рад/кадр)
    friction = 0.985; // коэффициент замедления
    minSpin = 0.01;

    lastSectorIndex = -1; // Для отображения последнего выигравшего сектора

    // Палитра цветов (Bootstrap-ish)
    colorPalette = [
        '#0d6efd', '#dc3545', '#198754', '#ffc107', '#0dcaf0', '#6f42c1',
        '#fd7e14', '#20c997', '#e83e8c', '#6610f2', '#d63384', '#ffcd39',
        '#087990', '#6c757d', '#2b3035', '#f8f9fa'
    ];

    drawWheel(angle = 0) {
        const items = document.getElementById('items').querySelectorAll('li');
        const count = items.length;
        const anglePerSector = (Math.PI * 2) / count;
        const radius = this.canvas.width / 2;
        const centerX = radius;
        const centerY = radius;

        // Очистить канвас (прозрачный фон, но подложка белая)
        this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);

        // Рисуем каждый сектор
        for (let i = 0; i < count; i++) {
            const item = items[i];

            const startAngle = i * anglePerSector + angle;
            const endAngle = (i + 1) * anglePerSector + angle;

            // чередуем цвета из палитры (по кругу)
            this.ctx.fillStyle = this.colorPalette[i % this.colorPalette.length];

            // Рисуем сектор
            this.ctx.beginPath();
            this.ctx.moveTo(centerX, centerY);
            this.ctx.arc(centerX, centerY, radius, startAngle, endAngle);
            this.ctx.closePath();
            this.ctx.fill();

            // Добавим тонкую обводку между секторами (белую)
            this.ctx.strokeStyle = '#ffffff';
            this.ctx.lineWidth = 1.5;
            this.ctx.beginPath();
            this.ctx.moveTo(centerX, centerY);
            this.ctx.arc(centerX, centerY, radius, startAngle, endAngle);
            this.ctx.lineTo(centerX, centerY);
            this.ctx.stroke();

            // --- добавим номер сектора (по желанию) ---
            this.ctx.save();
            this.ctx.translate(centerX, centerY);
            this.ctx.rotate(startAngle + anglePerSector / 2);
            this.ctx.textAlign = 'center';
            this.ctx.textBaseline = 'middle';
            this.ctx.font = 'bold ' + (radius * 0.12) + 'px "Segoe UI", Roboto, sans-serif';
            this.ctx.fillStyle = '#ffffff';
            this.ctx.shadowColor = 'rgba(0,0,0,0.3)';
            this.ctx.shadowBlur = 6;
            this.ctx.shadowOffsetX = 1;
            this.ctx.shadowOffsetY = 1;
            this.ctx.fillText(item.innerHTML, radius * 0.65, 0);
            this.ctx.restore();
        }

        // Центральный кружок (ступица)
        this.ctx.beginPath();
        this.ctx.arc(centerX, centerY, radius * 0.02, 0, 2 * Math.PI);
        this.ctx.fillStyle = '#212529';
        this.ctx.shadowBlur = 12;
        this.ctx.shadowColor = '#00000040';
        this.ctx.fill();
        this.ctx.shadowBlur = 0; // сброс тени для дальнейшей отрисовки

        // обводка внешнего края
        this.ctx.beginPath();
        this.ctx.arc(centerX, centerY, radius, 0, 2 * Math.PI);
        this.ctx.strokeStyle = '#dee2e6';
        this.ctx.lineWidth = 4;
        this.ctx.stroke();
    }

    spin() {
        if (this.isSpinning) return; // уже крутится
        this.isSpinning = true;
        // случайное приращение скорости (от 0.3 до 0.8 рад/кадр)
        this.spinVelocity = 0.3 + Math.random() * 0.5;
        // случайное направление (иногда против часовой)
        if (Math.random() > 0.8) this.spinVelocity *= -1;

        // запускаем
        if (this.animationFrame) cancelAnimationFrame(this.animationFrame);
        this.animationFrame = requestAnimationFrame(this.step);
    }

    step = () => {
        if (!this.isSpinning) return;

        // применяем трение
        this.spinVelocity *= this.friction;

        // если скорость очень маленькая — останавливаем
        if (Math.abs(this.spinVelocity) <= this.minSpin) {
            this.isSpinning = false;
            this.spinVelocity = 0;
            if (this.animationFrame) {
                cancelAnimationFrame(this.animationFrame);
                this.animationFrame = null;
            }
            // финальное обновление метки
            //updateCurrentSectorLabel();
            return;
        }

        // увеличиваем угол поворота
        this.rotationAngle = (this.rotationAngle + this.spinVelocity) % (2 * Math.PI);
        this.drawWheel(this.rotationAngle);
        //updateCurrentSectorLabel(); // обновляем превью сектора во время вращения

        // продолжаем анимацию
        this.animationFrame = requestAnimationFrame(this.step);
    }

}

window.wheelList = new WheelList();

document.addEventListener('change', function (event) {
    if (event.target.id == 'select-wheel') {
        window.wheelList.getListPartialView(event.target.value)
            .then((response) => {
                document.getElementById('wheel').outerHTML = response;

                wheelList.canvas = document.getElementById('wheelCanvas');
                wheelList.ctx = wheelList.canvas.getContext('2d');

                wheelList.drawWheel();
            });
        
        return;
    }
});