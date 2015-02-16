function booksController($scope, booksService) {
    $scope.title = '** book list';
    $scope.books = booksService.getBooks();
    //alert('controller called');
    //alert('books: ' + $scope.books.length);
}