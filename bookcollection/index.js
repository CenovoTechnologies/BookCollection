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
	mainWindow = new BrowserWindow({
		width: 1200,
		height: 1000
	});

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
		width: 500,
		height: 500,
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
		width: 800,
		height: 800,
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
		width: 500,
		height: 500,
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
		width: 800,
		height: 900,
		title: 'Add New Book'
	});

	addBookWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'addBook.html'),
		protocol: 'file:',
		slashes: true
	}));

	addBookWindow.on('close', function() {
		addBookWindow = null;
	});
}

ipcMain.on('book:add', function(e, request) {
	controller.addBookToCollection(request, function(responseBody) {
		mainWindow.webContents.send('book:add', responseBody);
	});
	addBookWindow.close();
})

ipcMain.on('collection:add', function(e, collectionName, userId) {
	var message = JSON.stringify({
		"UserId": userId,
		"CollectionName": collectionName
	});
	controller.addBookCollection(message, function(responseBody) {
		mainWindow.webContents.send('collection:add', responseBody);
	});
	addCollectionWindow.close();
});

ipcMain.on('collection:open', function(e, collectionName, collectionId, userId) {
	controller.getCollectionById(collectionId, function(responseBody) {
		mainWindow.loadURL(url.format({
			pathname: path.join(__dirname, 'viewCollection.html'),
			protocol: 'file:',
			slashes: true
		}));
		mainWindow.webContents.once('did-finish-load', function() {
			mainWindow.webContents.send('collection:open', responseBody);
		});
	});	
});

ipcMain.on('userAccount:add', function(e, firstName, middleName, lastName, email, password) {
	var message = JSON.stringify({
		"FirstName": firstName,
		"LastName": lastName,
		"MiddleName": middleName,
		"Email": email,
		"Password": password
	});
	controller.createNewAccount(message, function(responseBody) {
		mainWindow.loadURL(url.format({
			pathname: path.join(__dirname, 'homepage.html'),
			protocol: 'file:',
			slashes: true
		}));
		mainWindow.webContents.on('did-finish-load', function() {
			mainWindow.webContents.send('userAccount:add', responseBody);
		});
	});
	addUserWindow.close();
});

ipcMain.on('userAccount:login', function(e, email, password) {
	var message = JSON.stringify({
		'Email': email,
		'Password': password
	});
	controller.loginAccount(message, function(responseBody) {
		mainWindow.loadURL(url.format({
			pathname: path.join(__dirname, 'homepage.html'),
			protocol: 'file:',
			slashes: true
		}));
		mainWindow.webContents.on('did-finish-load', function() {
			mainWindow.webContents.send('userAccount:login', responseBody);
		});
	});
	loginWindow.close();
});

ipcMain.on('user:getCollections', function(e, userId) {
	controller.getBookCollectionsForUser(userId, function(responseBody) {
		mainWindow.webContents.send('user:getCollections', responseBody);
	});
});

ipcMain.on('loginBtn:click', function(e) {
	createLoginWindow();
});

ipcMain.on('createAccountBtn:click', function(e) {
	createAddUserWindow();
});

ipcMain.on('addCollectionBtn:click', function(e, userId) {
	createCollectionWindow();	
	addCollectionWindow.webContents.on('did-finish-load', function() {
		addCollectionWindow.webContents.send('collection:init', userId);
	});
});

ipcMain.on('addBookBtn:click', function(e, userId, collectionId) {
	createAddBookWindow();
	addBookWindow.webContents.on('did-finish-load', function() {
		addBookWindow.webContents.send('addBook:init', userId, collectionId);
	});
});

ipcMain.on('homepage:return', function(e) {
	mainWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'homepage.html'),
		protocol: 'file:',
		slashes: true
	}));
});

ipcMain.on('bookGenre:getAll', function(e) {
	controller.getAllBookGenres(function(responseBody) {
		addBookWindow.webContents.send('bookGenre:getAll', responseBody);
	});
});

ipcMain.on('bookFormat:getAll', function(e) {
	controller.getAllBookFormats(function(responseBody) {
		addBookWindow.webContents.send('bookFormat:getAll', responseBody);
	});
});

ipcMain.on('collection:getBooks', function(e, collectionId) {
	controller.getAllBooksForCollection(collectionId, function(responseBody) {
		mainWindow.webContents.send('collection:getBooks', responseBody);
	});
});

ipcMain.on('book:open', function(e, bookId, userId) {
	controller.getBookByBookId(bookId, function(responseBody) {
		mainWindow.loadURL(url.format({
			pathname: path.join(__dirname, 'viewBook.html'),
			protocol: 'file:',
			slashes: true
		}));
		mainWindow.webContents.on('did-finish-load', function() {
			mainWindow.webContents.send('book:open', responseBody, userId);
		});
	});
});

ipcMain.on('viewCollection:return', function(e, collectionId) {
	controller.getCollectionById(collectionId, function(responseBody) {
		mainWindow.loadURL(url.format({
			pathname: path.join(__dirname, 'viewCollection.html'),
			protocol: 'file:',
			slashes: true
		}));
		mainWindow.webContents.once('did-finish-load', function() {
			mainWindow.webContents.send('viewCollection:return', responseBody);
		});
	});
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
