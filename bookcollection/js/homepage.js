const electron = require('electron');
const {ipcRenderer} = electron;
const collectionList = document.querySelector('#bookCollectionList');
const addCollectionBtn = document.querySelector('#addCollectionBtn');

 addCollectionBtn.addEventListener('click', createCollection);
    
ipcRenderer.on('collection:add', function(e, collectionInfo) {
    var json = JSON.parse(collectionInfo);
    appendCollectionToList(json.CollectionId, json.CollectionName);
});

ipcRenderer.on('userAccount:add', function(e, userInfo) {
    var json = JSON.parse(userInfo);
    addUserInfoToScreen(json.UserId, json.FirstName, json.LastName);
});

ipcRenderer.on('userAccount:login', function(e, userInfo) {
    var json = JSON.parse(userInfo);
    addUserInfoToScreen(json.UserId, json.FirstName, json.LastName);
    getCollectionsForUsers(json.UserId);
});

ipcRenderer.on('user:getCollections', function(e, collectionInfo) {
    for (j in collectionInfo) {
        appendCollectionToList(collectionInfo[j].collectionId, collectionInfo[j].collectionName);
    }
});
    
function addUserInfoToScreen(userId, firstName, lastName) {
    const nameText = document.createTextNode(firstName + ' ' + lastName);
    const id = document.createTextNode(userId);
    document.querySelector('#userId').appendChild(id);
    document.querySelector('#nameOfUser').appendChild(nameText);
}

function getCollectionsForUsers(userId) {
    ipcRenderer.send('user:getCollections', userId);
}

function appendCollectionToList(collectionId, collectionName) {
    const btn = document.createElement('a');
    const itemText = document.createTextNode(collectionName);
    const itemId = document.createTextNode(collectionId);
    btn.appendChild(itemText);
    btn.id = collectionId;
    btn.classList = "collection-item blue-grey-text text-darken-4";
    btn.href="javascript:void(0)";
    btn.onclick=function(e) {
        openCollection(e, collectionId);
    };
    collectionList.appendChild(btn);
}

function removeCollection(e) {
    e.target.remove();
}

function createCollection(e) {
    e.preventDefault();
    ipcRenderer.send('addCollectionBtn:click', document.getElementById('userId').innerHTML);
}

function openCollection(e, collectionId) {
    const collectionName = e.target.firstChild.nodeValue;
    const userId = document.getElementById('userId').innerHTML;
    ipcRenderer.send('collection:open', collectionName, collectionId, userId);
}