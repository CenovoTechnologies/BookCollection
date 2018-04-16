const electron = require('electron');
const {ipcRenderer} = electron;
const collection = document.querySelector('#collectionName');
const addBookBtn = document.querySelector('#addBookBtn');
const backBtn = document.querySelector('#backBtn');
const bookList = document.querySelector('#bookList');
var authors = null;

addBookBtn.addEventListener('click', createBook);
backBtn.addEventListener('click', returnToHomepage);

ipcRenderer.on('collection:open', function(e, collection) {
    document.querySelector('#collectionName').innerHTML = collection.collectionName;
    document.querySelector('#collectionId').innerHTML = collection.collectionId;
    document.querySelector('#userId').innerHTML = collection.userId;
    authors = collection.authors;
    addBooksToPage(collection.books);
});

ipcRenderer.on('viewCollection:return', function(e, collection) {
    document.querySelector('#collectionName').innerHTML = collection.collectionName;
    document.querySelector('#collectionId').innerHTML = collection.collectionId;
    document.querySelector('#userId').innerHTML = collection.userId;
    authors = collection.authors;
    addBooksToPage(collection.books);
});

ipcRenderer.on('book:add', function(e, book) {
    addBookToList(book);
});

ipcRenderer.on('collection:getBooks', function(e, books) {
    addBooksToPage(books);
});

function addBooksToPage(books) {
    for(b in books) {
        addBookToList(books[b]);
    }
}

function createBook(e) {
    e.preventDefault();
    ipcRenderer.send('addBookBtn:click', document.querySelector('#userId').innerHTML, document.querySelector('#collectionId').innerHTML);
}

function returnToHomepage(e) {
    var list = document.getElementById('bookList');
    while (list.firstChild) {
        list.removeChild(list.firstChild);
    }
    ipcRenderer.send('homepage:return');
}

function getBooksForCollection(collectionId) {
    ipcRenderer.send('collection:getBooks', collectionId);
}

function addBookToList(book) {
    var authorIds = new Array();
    if (book.bookAuthors != null) {
        book.bookAuthors.forEach( function (ab) {
            if (ab.bookId === book.bookId) {
                authorIds.push(ab.authorId);
            }
        });
    }
    var authorText = createAuthorList(authorIds);
    const li = document.createElement("li");
    li.classList="collection-item avatar";
    li.id=book.bookId;
    li.appendChild(createRow(book,authorText));
    bookList.appendChild(li);
}

function createAuthorList(authorIds) {
    var authorText = 'Author(s): ';
    authorIds.forEach( function(id, index) {
        var author = authors.find(x => x.authorId === id);
        authorText = authorText.concat(author.firstName + ' ');
        if (typeof author.middleInitial != 'undefined' && author.middleInitial) {
            authorText = authorText.concat(author.middleInitial + ' ');
        }
        authorText = authorText.concat(author.lastName);
        if (index < authorIds.length-1) {
            authorText = authorText.concat(', ');
        }
    });
    return authorText;
}

function createDiv1(book, authorText) {
    const bookIcon = document.createElement("i");
    bookIcon.classList="fas fa-book circle";
    const title = document.createElement("span");
    title.classList="title";
    title.innerHTML=book.title;
    const p = document.createElement("p");
    p.innerHTML = authorText;
    const div1 = document.createElement("div");
    div1.classList="col s8";
    div1.appendChild(bookIcon);
    div1.appendChild(title);
    div1.appendChild(p);
    return div1;
}

function createDiv2(bookId) {
    const div2 = document.createElement("div");
    div2.classList="col s4";
    div2.appendChild(createEditButton(bookId));
    div2.appendChild(createViewButton(bookId));
    return div2;
}

function createRow(book, authorText) {
    const row = document.createElement("div");
    row.classList="row";
    row.appendChild(createDiv1(book, authorText));
    row.appendChild(createDiv2(book.bookId));
    return row;
}

function createViewButton(bookId) {
    const viewIcon = document.createElement("i");
    viewIcon.classList="fas fa-chevron-circle-right fa-2x grey-text text-darken-4 right";
    viewIcon.style="margin-top:1rem;"
    const viewButton = document.createElement("a");
    viewButton.href="#";
    viewButton.id="view_"+bookId;
    viewButton.onclick=function(e) {
        viewBook(e, bookId);
    };
    viewButton.appendChild(viewIcon);
    return viewButton;
}

function createEditButton(bookId) {
    const editIcon = document.createElement("i");
    editIcon.classList="far fa-edit fa-2x grey-text text-darken-4 right";
    editIcon.style = "margin-top:1rem;"
    const editButton = document.createElement("a");
    editButton.href="#";
    editButton.id="edit_"+bookId;
    editButton.appendChild(editIcon);
    return editButton;
}

function viewBook(e, bookId) {
    const userId = document.getElementById('userId').innerHTML;
    ipcRenderer.send('book:open', bookId, userId);
}