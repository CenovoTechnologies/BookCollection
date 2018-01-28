const url = require('url');
const path = require('path');
const http = require('http');

module.exports = {
    createNewAccount: function(message, callback) {
        let body = '';
        const options = {
            hostname: 'localhost',
            port: 53656,
            path: '/api/Users/Register',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        };
        const req = http.request(options, (res) => {
            res.setEncoding('utf8');
            res.on('data', (chunk) => {
                body += chunk;
            });
            res.on('end', () => {
                callback(JSON.parse(body));
            });
        });
    
        req.on('error', (e) => {
            console.error(`problem with request: ${e.message}`);
        });
        req.end(message);
    },

    loginAccount: function(message, callback) {
        let body = '';
        const options = {
            hostname: 'localhost',
            port: 53656,
            path: '/api/Users/Login',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        };
        const req = http.request(options, (res) => {
            res.setEncoding('utf8')
            res.on('data', (chunk) => {
                body += chunk;
            });
            res.on('end', () => {
                callback(JSON.parse(body));
            });
        });
    
        req.on('error', (e) => {
            console.error(`problem with request: ${e.message}`);
        });
        req.end(message);
    },

    addBookCollection: function(message, callback) {
        let body = '';
        const options = {
            hostname: 'localhost',
            port: 53656,
            path: '/api/BookCollection/Create',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        };
        const req = http.request(options, (res) => {
            res.setEncoding('utf8')
            res.on('data', (chunk) => {
                body += chunk;
            });
            res.on('end', () => {
                callback(JSON.parse(body));
            });
        });
    
        req.on('error', (e) => {
            console.error(`problem with request: ${e.message}`);
        });
        req.end(message);
    },

    getBookCollectionsForUser: function(userId, callback) {
        let body = '';
        const options = {
            hostname: 'localhost',
            port: 53656,
            path: '/api/BookCollection/Collections?userId=' + userId,
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        };
        http.get(options, (res) => {
            res.setEncoding('utf8')
            res.on('data', (chunk) => {
                body += chunk;
            });
            res.on('end', () => {
                callback(JSON.parse(body));
            });
            res.on('error', (e) => {
                console.error(`problem with request: ${e.message}`);
            });
        });
    },

    getAllBookGenres: function (callback) {
        let body = '';
        const options = {
            hostname: 'localhost',
            port: 53656,
            path: '/api/BookGenres',
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        };
        http.get(options, (res) => {
            res.setEncoding('utf8')
            res.on('data', (chunk) => {
                body += chunk;
            });
            res.on('end', () => {
                callback(JSON.parse(body));
            });
            res.on('error', (e) => {
                console.error(`problem with request: ${e.message}`);
            });
        });
    },

    getAllBookFormats: function (callback) {
        let body = '';
        const options = {
            hostname: 'localhost',
            port: 53656,
            path: '/api/BookFormats',
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        };
        http.get(options, (res) => {
            res.setEncoding('utf8')
            res.on('data', (chunk) => {
                body += chunk;
            });
            res.on('end', () => {
                callback(JSON.parse(body));
            });
            res.on('error', (e) => {
                console.error(`problem with request: ${e.message}`);
            });
        });
    }
}