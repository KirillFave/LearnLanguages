document.addEventListener('dblclick', e => {
    if (e.target.classList.contains('scheme-item')) {
        const schemeItem = e.target;
        const row = schemeItem.dataset.row;
        const column = schemeItem.dataset.column;

        const addSchemeItemPopover = document.getElementById('add-scheme-item-popover');

        addSchemeItemPopover.classList.remove('d-none');
    }
});

document.getElementById('confirm-add-item-btn').addEventListener('click', e => {
    text = 
});