const electron = require('electron');
const url = require('url');
const path = require('path');
const controller = require('./controller');

const {app, BrowserWindow, Menu, ipcMain} = electron;

let mainWindow;
let addCollectionWindow;
let addUserWindow;
let loginWindow;
let addBookWindow;

app.on('ready', function() {
	mainWindow = new BrowserWindow({});

	mainWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'index.html'),
		protocol: 'file:',
		slashes: true
	}));
	mainWindow.on('closed', function() {
		app.quit();
	});

	const mainMenu = Menu.buildFromTemplate(mainMenuTemplate);
	Menu.setApplicationMenu(mainMenu);
});

function createCollectionWindow() {
	addCollectionWindow = new BrowserWindow({
		width: 300,
		height: 200,
		title:'Add new book collection'
	});

	addCollectionWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'createCollection.html'),
		protocol: 'file:',
		slashes: true
	}));

	addCollectionWindow.on('close', function() {
		addCollectionWindow = null;
	});
}

function createAddUserWindow() {
	addUserWindow = new BrowserWindow({
		width: 500,
		height: 500,
		title:'Create a New User Account'
	});

	addUserWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'createUserAccount.html'),
		protocol: 'file:',
		slashes: true
	}));

	addUserWindow.on('close', function() {
		addUserWindow = null;
	});
}

function createLoginWindow() {
	loginWindow = new BrowserWindow({
		width: 300,
		height: 200,
		title: 'Login'
	});

	loginWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'login.html'),
		protocol: 'file:',
		slashes: true
	}));

	loginWindow.on('close', function() {
		loginWindow = null;
	});
}

function createAddBookWindow() {
	addBookWindow = new BrowserWindow({
		width: 500,
		height: 500,
		title: 'Add New Book'
	});

	addBookWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'editBook.html'),
		protocol: 'file:',
		slashes: true
	}));

	addBookWindow.on('close', function() {
		addBookWindow = null;
	});
}

ipcMain.on('book:add', function(e, title, author) {
	mainWindow.webContents.send('book:add', title, author);
	addBookWindow.close();
})

ipcMain.on('collection:add', function(e, item) {
	mainWindow.webContents.send('collection:add', item);
	addCollectionWindow.close();
});

ipcMain.on('collection:open', function(e, collectionId) {
	mainWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'viewCollection.html'),
		protocol: 'file:',
		slashes: true
	}));
	mainWindow.webContents.on('did-finish-load', function() {
		mainWindow.webContents.send('collection:open', collectionId);
	});
});

ipcMain.on('userAccount:add', function(e, firstName, middleInitial, lastName, email, password) {
	controller.createNewAccount(firstName, middleInitial, lastName, email, password);
	mainWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'homepage.html'),
		protocol: 'file:',
		slashes: true
	}));
	addUserWindow.close();
});

ipcMain.on('userAccount:login', function(e, email, password) {
	mainWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'homepage.html'),
		protocol: 'file:',
		slashes: true
	}));
	loginWindow.close();
});

ipcMain.on('loginBtn:click', function(e) {
	createLoginWindow();
});

ipcMain.on('createAccountBtn:click', function(e) {
	createAddUserWindow();
});

ipcMain.on('addCollectionBtn:click', function(e) {
	createCollectionWindow();
});

ipcMain.on('addBookBtn:click', function(e) {
	createAddBookWindow();
});

const mainMenuTemplate = [
	{
		label:'File',
		submenu:[
			{
				label: 'Create a New Account',
				click(){
					createAddUserWindow();
				}
			},
			{
				label: 'Login',
				click(){
					createLoginWindow();
				}
			},
			{
				label: 'Quit',
				accelerator: process.platform == 'darwin' ? 'Command+Q' : 'Ctrl+Q',
				click(){
					app.quit();
				}
			}
		]
	}
];

if(process.platform == 'darwin') {
	mainMenuTemplate.unshift({});
}

if(process.env.NODE_ENV != 'production') {
	mainMenuTemplate.push({
		label: 'Developer Tools',
		submenu: [
			{
				label: 'Toggle DevTools',
				accelerator: process.platform == 'darwin' ? 'Command+I' : 'Ctrl+I',
				click(item, focusedWindow) {
					focusedWindow.toggleDevTools();
				}
			},
			{
				role: 'reload'
			}
		]
	});
}
