
function booksController($scope, booksService) {
    $scope.title = '** book list';
    $scope.new_book = {};    

    $scope.getAll = function () {
        var promise = booksService.getBooks();
        promise.success(function (data) {
            $scope.books = data;
        });
        promise.error(function (data) {
            alert('ajax failed!');
        });
    }

    $scope.getAll();

    $scope.getTotal = function()
    {
        var total = 0;
        //$scope.books.forEach(function (clb) {
        //    total += clb.price;
        //});
        return total;
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
                alert('post failed - ' + reason);
            })
        }
        else {
            booksService.update(new_book)
            .then(function (response) {
                $scope.getAll();
            }, function (reason) {
                alert('update failed.reason: '+reason);
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
            alert('delete failed: '+reason.data.Message);}
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