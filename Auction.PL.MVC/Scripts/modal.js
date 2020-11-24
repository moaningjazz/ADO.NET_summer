function openModalWindow(modalWindowId) {
    let modal = document.getElementById(modalWindowId);
    modal.style.display = "flex";
}

function closeModalWindow(modalWindowId) {
    let modal = document.getElementById(modalWindowId);
    modal.style.display = "none";
}

function openModalWindowWithValue(modalWindowId, idInput, value) {
    let input = document.getElementById(idInput);
    input.value = value;
    let modal = document.getElementById(modalWindowId);
    modal.style.display = "flex";
}