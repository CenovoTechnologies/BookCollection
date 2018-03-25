const url = require('url');
const path = require('path');
const request = require('request');

module.exports = {
    createNewAccount: function(message, callback) {
        request({
            method: 'POST',
            url: 'http://localhost:58128/api/Users/Register',
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            body: JSON.parse(message),
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    loginAccount: function(message, callback) {
        request({
            method: 'POST',
            url: 'http://localhost:58128/api/Users/Login',
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            body: JSON.parse(message),
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    addBookCollection: function(message, callback) {
        request({
            method: 'POST',
            url: 'http://localhost:58128/api/BookCollection/Create',
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            body: JSON.parse(message),
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    getBookCollectionsForUser: function(userId, callback) {
        request({
            method: 'GET',
            url: 'http://localhost:58128/api/BookCollection/Collections?userId=' + userId,
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    getAllBookGenres: function (callback) {
        request({
            method: 'GET',
            url: 'http://localhost:58128/api/BookGenres/All',
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    getAllBookFormats: function (callback) {
        request({
            method: 'GET',
            url: 'http://localhost:58128/api/BookFormats/All',
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    addBookToCollection: function (message, callback) {
        request({
            method: 'POST',
            url: 'http://localhost:58128/api/Book/Create',
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            body: JSON.parse(message),
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    getAllBooksForCollection: function (collectionId, callback) {
        request({
            method: 'GET',
            url: 'http://localhost:58128/api/Book/All',
            qs: { 
                collectionId: collectionId
            },
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    getBookByBookId: function (bookId, callback) {
        request({
            method: 'GET',
            url: 'http://localhost:58128/api/Book/Get',
            qs: { 
                id: bookId
            },
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    },

    getCollectionById: function (collectionId, callback) {
        request({
            method: 'GET',
            url: 'http://localhost:58128/api/BookCollection/Collection',
            qs: { 
                id: collectionId
            },
            headers:  { 
                'Cache-Control': 'no-cache',
                'Content-Type': 'application/json' 
            },
            json: true
        }, function (error, response, body) {
            if (response.statusCode == 200) {
                callback(body);
            }
        });
    }
}