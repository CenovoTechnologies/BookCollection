const electron = require('electron');
const url = require('url');
const path = require('path');

const {app, BrowserWindow, Menu, ipcMain} = electron;

let mainWindow;
let addCollectionWindow;

//Listen for the app to be ready
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

function createAddWindow() {
	addCollectionWindow = new BrowserWindow({
		width: 300,
		height: 200,
		title:'Add new book collection'
	});

	addCollectionWindow.loadURL(url.format({
		pathname: path.join(__dirname, 'addCollectionWindow.html'),
		protocol: 'file:',
		slashes: true
	}));

	addCollectionWindow.on('close', function() {
		addCollectionWindow = null;
	});
}

ipcMain.on('item:add', function(e, item) {
	mainWindow.webContents.send('item:add', item);
	addCollectionWindow.close();
});

const mainMenuTemplate = [
	{
		label:'File',
		submenu:[
			{
				label: 'Add New Collection',
				click(){
					createAddWindow();
				}
			},
			{
				label: 'Remove Collection',
				click(){
					mainWindow.webContents.send('item:clear');
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
