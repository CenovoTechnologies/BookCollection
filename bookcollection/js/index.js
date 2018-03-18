const electron = require('electron');
const {ipcRenderer} = electron;

document.querySelector('#loginBtn').addEventListener('click', createLogin);
document.querySelector('#createAccountBtn').addEventListener('click', createUser);

function createLogin(e) {
	e.preventDefault();
	ipcRenderer.send('loginBtn:click');
}

function createUser(e) {
	e.preventDefault();
	ipcRenderer.send('createAccountBtn:click');
}