

function booksService($http, $q) {    
    //var uid = 3;    

    //var books = [
    //    { Id: 1, Name: 'War and Piece', Price: 100 },
    //    { Id: 2, Name: 'Programming ASP.NET MVC', Price: 20 }
    //];

    return {
        getBooks: function () {
            //// Get the deferred object
            //var deferred = $q.defer();
            //// Initiates the AJAX call
            //$http({ method: 'GET', url: '/events/GetTalkDetails' }).success(deferred.resolve).error(deferred.reject);
            //// Returns the promise - Contains result once request completes
            //return deferred.promise;
            //return books;
            return $http.get('/api/books');
        },

        add: function (book) {            
            var msg = angular.toJson(book, false);
            return $http.post('/api/books', msg);
        },

        update: function (book) {
            var url = '/api/books';
            var data = angular.toJson(book);
            return $http.put(url, data);
        },

        delete: function (id) {
            var url = '/api/books/' + id;
            return $http.delete(url);            
        }
    };
}