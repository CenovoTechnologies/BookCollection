const electron = require('electron');
const {ipcRenderer} = electron;

const form = document.querySelector('form');
form.addEventListener('submit', submitForm);

ipcRenderer.on('collection:init', function(e, userId) {
	setUserId(userId);
});

function setUserId(userId) {
	const id = document.createTextNode(userId);
    document.querySelector('#userId').appendChild(id);
}

function submitForm(e) {
	e.preventDefault();
	const collectionName = document.querySelector('#collectionNameInput').value;
	ipcRenderer.send('collection:add', collectionName, document.getElementById('userId').innerHTML);
}