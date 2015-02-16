var booksModule = angular.module('booksapp', []);

booksModule.factory("booksService", booksService);
booksModule.controller("booksController", booksController);