const electron = require('electron');
const {ipcRenderer} = electron;

const loginForm = document.querySelector('form');
loginForm.addEventListener('submit', submitForm);
            
function submitForm(e) {
    e.preventDefault();
    const email = document.querySelector('#emailInput').value;
    const password = document.querySelector('#passwordInput').value;
    ipcRenderer.send('userAccount:login', email, password);
}