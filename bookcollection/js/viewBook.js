const electron = require('electron');
const { ipcRenderer } = electron;
const backBtn = document.querySelector('#backBtn');

backBtn.addEventListener('click', returnToViewCollection);

ipcRenderer.on('book:open', function (e, responseBody, userId) {
    var el = document.querySelector('#bookInfoTabs');
    var options;
    var instance = M.Tabs.init(el, options);
    document.querySelector('#bookTitle').innerHTML = responseBody.title;
    document.querySelector('#collectionId').innerHTML = responseBody.collectionId;
    document.querySelector('#userId').innerHTML = userId;
    document.querySelector('#bookId').innerHTML = bookId;
    fillOutBookPage(responseBody);
});

function returnToViewCollection(e) {
    e.preventDefault();
    ipcRenderer.send('viewCollection:return', document.querySelector('#collectionId').innerHTML);
}

function fillOutBookPage(book) {
    document.querySelector("#title").innerHTML = book.title;
    document.querySelector("#subTitle").innerHTML = book.subTitle;
    document.querySelector("#authors").innerHTML = createAuthorsTextField(book.bookAuthors);
    document.querySelector("#isbn").innerHTML = book.isbn;
    document.querySelector("#genre").innerHTML = book.bookGenre.genre;
    document.querySelector("#format").innerHTML = book.bookFormat.format;
    document.querySelector("#pageNum").innerHTML = book.numberOfPages;
    document.querySelector("#locClass").innerHTML = book.locClassification;
    document.querySelector("#publisher").innerHTML = book.publisher;
    if (book.publisherDate !== "0001-01-01T00:00:00") {
        document.querySelector("#publishedDate").innerHTML = book.publisherDate;
    }
    document.querySelector("#plot").innerHTML = book.plot;
}

function createAuthorsTextField(bookAuthors) {
    var authors = "";
    bookAuthors.forEach( function(ab, index) {
        authors = authors.concat(ab.author.firstName + ' ');
        if (typeof ab.author.middleName != 'undefined' && ab.author.middleName) {
            authors = authors.concat(ab.author.middleName + ' ');
        }
        authors = authors.concat(ab.author.lastName);
        if (index < bookAuthors.length-1) {
            authors = authors.concat(', ');
        }
    });
    return authors;
}