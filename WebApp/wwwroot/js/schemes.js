document.addEventListener('dblclick', e => {
    if (e.target.classList.contains('scheme-item')) {
        const schemeItem = e.target;
        const row = schemeItem.dataset.row;
        const column = schemeItem.dataset.column;

        const addSchemeItemPopover = document.getElementById('add-scheme-item-popover');
        const popoverHeight = addSchemeItemPopover.offsetHeight;
        const popoverWidth = addSchemeItemPopover.offsetWidth;

        const rect = schemeItem.getBoundingClientRect();

        let top = rect.top;

        if (top + popoverHeight > window.innerHeight) {
            top = window.innerHeight - popoverHeight;
        }

        let left = rect.right;

        if (left + popoverWidth > window.innerWidth) {
            left = rect.left - popoverWidth;
        }

        addSchemeItemPopover.style.top = top + 'px';
        addSchemeItemPopover.style.left = left + 'px';

        document.getElementById('input-row').value = row;
        document.getElementById('input-column').value = column;

        addSchemeItemPopover.classList.remove('d-none');
    }
});

document.getElementById('confirm-add-item-btn').addEventListener('click', e => {
    console.log();
});