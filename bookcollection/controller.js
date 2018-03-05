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
            url: 'http://localhost:58128/api/BookGenres',
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
            url: 'http://localhost:58128/api/BookFormats',
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