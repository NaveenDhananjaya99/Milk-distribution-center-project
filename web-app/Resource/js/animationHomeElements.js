const boxex = document.querySelectorAll('.animation');

window.addEventListener('scroll', checkBoxes);



function checkBoxes() {
    const triggerBottem = window.innerHeight / 5 * 4;

    boxex.forEach(box => {

        const boxTop = box.getBoundingClientRect().top;

        if (boxTop < triggerBottem) {
            box.classList.add('show');
        } else {
            box.classList.remove('show');
        }
    })
}