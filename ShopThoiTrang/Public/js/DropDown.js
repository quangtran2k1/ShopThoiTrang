const dropdowns = document.querySelectorAll('.dropdown');
dropdowns.forEach(dropdowns=> {
    const select = dropdowns.querySelector('.select');
    const caret = dropdowns.querySelector('.caret');
    const menu = dropdowns.querySelector('.menu ')
    const option = dropdowns.querySelectorAll('.menu li');
    const selected = dropdowns.querySelector('.selected');

    select.addEventListener('click', () => {
        select.classList.toggle('select');
        select.classList.toggle('select-clicked');
        caret.classList.toggle('caret-rotate');
        menu.classList.toggle('menu-close');
    });
    options.forEach(option=> {
        option.addEventListener('click', () => {
            selected.innerText = option.innerText;
            select.classList.remove('select-clicked');
            caret.classList.remove('caret-rotate');
            menu.classList.remove('menu-close');
            options.forEach(option=> {
                option.classList.remove('active');
            });
            option.classList.add('ative');
        });
    });
});