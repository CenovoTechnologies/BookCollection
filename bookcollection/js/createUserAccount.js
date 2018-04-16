const electron = require('electron');
const {ipcRenderer} = electron;

const form = document.querySelector('form');
form.addEventListener('submit', submitForm);

function submitForm(e) {
    e.preventDefault();
    if (isFormValid()) {
        sendToMain();
    }
}

function isPasswordValid(e) {

}

function isFormValid() {
    var isValid = true;
    if (!doPasswordsMatch()) {
        isValid = false;
        document.querySelector('#passwordInput').value = '';
        document.querySelector('#repeatPasswordInput').value = '';
        alert("Passwords must match");
    }
    if (!isEmailValid(document.querySelector('#emailInput').value)) {
        isValid = false;
        alert("Valid email address is required");
    }

    return isValid;
}
            
function doPasswordsMatch() {
    const password = document.querySelector('#passwordInput').value;
    const password2 = document.querySelector('#repeatPasswordInput').value;
    return password === password2;
}

function isEmailValid(email) {
    var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regex.test(email);
}

function sendToMain() {
    const firstName = document.querySelector('#firstNameInput').value;
    const middleName = document.querySelector('#middleNameInput').value;
    const lastName = document.querySelector('#lastNameInput').value;
    const email = document.querySelector('#emailInput').value;
    const password = document.querySelector('#passwordInput').value;
    ipcRenderer.send('userAccount:add', firstName, middleName, lastName, email, password);
}