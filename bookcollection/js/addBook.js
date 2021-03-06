const electron = require('electron');
const { ipcRenderer } = electron;
const addBookBtn = document.querySelector('#addBookBtn');

addBookBtn.addEventListener('click', addBook);

ipcRenderer.on('addBook:init', function (e, userId, collectionId) {
    setUserId(userId);
    setCollectionId(collectionId);
    getBookGenres();
    getBookFormats();
});

ipcRenderer.on('bookFormat:getAll', function (e, formats) {
    var elem = document.querySelector('#bookFormats');
    var options = '';
    for (f in formats) {
        options += '<option value=' + formats[f].bookFormatId + '>' + formats[f].format + '</option>';
    }
    document.getElementById('bookFormats').innerHTML = options;
    var instance = M.FormSelect.init(elem, options);
});

ipcRenderer.on('bookGenre:getAll', function (e, genres) {
    var elem = document.querySelector('#bookGenres');
    var options = '';
    for (g in genres) {
        options += '<option value=' + genres[g].bookGenreId + '>' + genres[g].genre + '</option>';
    }
    document.getElementById('bookGenres').innerHTML = options;
    var instance = M.FormSelect.init(elem, options);
});

function setUserId(userId) {
    document.querySelector('#userId').innerHTML = userId;
}

function setCollectionId(collectionId) {
    document.querySelector('#collectionId').innerHTML = collectionId;
}

function getBookGenres() {
    ipcRenderer.send('bookGenre:getAll');
}

function getBookFormats() {
    ipcRenderer.send('bookFormat:getAll');
}

function addBook(e) {
    e.preventDefault();
    var bookGenre = document.getElementById('bookGenres');
    var bookFormat = document.getElementById('bookFormats');
    const collectionId = document.querySelector('#collectionId').innerHTML;
    var request = JSON.stringify({
        "CollectionId": collectionId,
        "Title": document.getElementById('titleInput').value,
        "SubTitle": document.getElementById('subTitleInput').value,
        "Authors": MapAuthors(document.getElementById('authorInput').value),
        "ISBN": document.getElementById('IsbnInput').value,
        "BookGenreId": bookGenre.options[bookGenre.selectedIndex].value,
        "BookFormatId": bookFormat.options[bookFormat.selectedIndex].value,
        "NumberOfPages": document.getElementById('pagesInput').value,
        "Loc Classification": document.getElementById('locClassificationInput').value,
        "Dewey": document.getElementById('deweyInput').value,
        "Publisher": document.getElementById('publisherInput').value,
        // "PublisherDate": document.getElementById('publisherDateInput').value,
        "Plot": document.getElementById('plotInput').value
    });
    ipcRenderer.send('book:add', request);
}

function MapAuthors(authorInput) {
    var array = authorInput.split(', ');
    var jsonArray = new Array();
    array.forEach( function(string) {
        var a = string.split(' ');
        var author = new Object();
        author.FirstName = a[0];
        if (a.length == 3) {
            author.MiddleName = a[1];
            author.LastName = a[2];
        } else {
            author.LastName = a[1];
        }
        jsonArray.push(author);
    });
    return jsonArray;
}