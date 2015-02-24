
function booksController($scope, booksService) {
    $scope.title = '** book list';
    $scope.new_book = {};
    $scope.total = 0;

    $scope.getAll = function () {
        var promise = booksService.getBooks();
        promise.success(function (data) {
            $scope.books = data;
            $scope.total = _getTotal(data);
        });
        promise.error(function (data) {
            alert('ajax failed!');
        });
    }

    $scope.getAll();

    var _getTotal = function (books) {
        var total = 0;
        $scope.books.forEach(function (clb) {
            total += clb.Price;
        });
        return total;
    }

    $scope.getTotal = function()
    {
        return $scope.total;
    }

    $scope.save = function () {        
        var id = $scope.new_book.Id;
        var new_book = { Id: id, Name: $scope.new_book.Name, Price: $scope.new_book.Price };

        if (id == null) {
            new_book.Id = 0;
            booksService.add(new_book)
            .then(function () {
                $scope.getAll();
            },
            function (reason) {
                alert('post failed - ' + reason.status + "-" + reason.statusText);
            })
        }
        else {
            booksService.update(new_book)
            .then(function (response) {
                $scope.getAll();
            }, function (reason) {
                alert('update failed.reason: ' + reason.status + "-" + reason.statusText);
            });
        }
        
        $scope.new_book = {};
    }

    $scope.delete = function (id) {
        booksService.delete(id)
        .then(function () {
            $scope.getAll();
        },
        function (reason) {
            alert('delete failed: '+reason.status+"-"+reason.statusText);}
        );
    }

    //prepares form's controls
    $scope.update = function (id) {
        for (i in $scope.books) {
            var book = $scope.books[i];
            if (book.Id == id) {
                $scope.new_book = angular.copy(book);                
                break;
            }
        }
    }
   
}