const electron = require('electron');
const {ipcRenderer} = electron;
const collection = document.querySelector('#collectionName');
const addBookBtn = document.querySelector('#addBookBtn');
const backBtn = document.querySelector('#backBtn');
const bookList = document.querySelector('#bookList');

addBookBtn.addEventListener('click', createBook);
backBtn.addEventListener('click', returnToHomepage);

ipcRenderer.on('collection:open', function(e, collectionName, collectionId, userId) {
    document.querySelector('#collectionName').innerHTML = collectionName;
    document.querySelector('#collectionId').innerHTML = collectionId;
    document.querySelector('#userId').innerHTML = userId;
    getBooksForCollection(collectionId);
});

ipcRenderer.on('book:add', function(e, book) {
    addBookToList(book);
});

ipcRenderer.on('collection:getBooks', function(e, books) {
    for(b in books) {
        addBookToList(books[b]);
    }
});

function createBook(e) {
    e.preventDefault();
    ipcRenderer.send('addBookBtn:click', document.querySelector('#userId').innerHTML, document.querySelector('#collectionId').innerHTML);
}

function returnToHomepage(e) {
    e.preventDefault();
    ipcRenderer.send('homepage:return');
}

function getBooksForCollection(collectionId) {
    ipcRenderer.send('collection:getBooks', collectionId);
}

function addBookToList(book) {
    var authorText = "Author(s): ";
    if (book.author != null) {
         text = text + book.author;
    } 
    const bookIcon = document.createElement("i");
    bookIcon.classList="fas fa-book circle";
    const title = document.createElement("span");
    title.classList="title";
    title.innerHTML=book.title;
    const p = document.createElement("p");
    p.innerHTML = authorText;
    const li = document.createElement("li");
    li.classList="collection-item avatar";
    li.id=book.bookId;
    li.appendChild(bookIcon);
    li.appendChild(title);
    li.appendChild(p);
    bookList.appendChild(li);
}