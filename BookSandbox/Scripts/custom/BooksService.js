function booksService($http, $q) {
    return {
        getBooks: function () {
            //// Get the deferred object
            //var deferred = $q.defer();
            //// Initiates the AJAX call
            //$http({ method: 'GET', url: '/events/GetTalkDetails' }).success(deferred.resolve).error(deferred.reject);
            //// Returns the promise - Contains result once request completes
            //return deferred.promise;
            return [
                { id: '1', name: 'War and Piece', price: '100' },
                { id: '2', name: 'Programming ASP.NET MVC', price: '20' }
            ];
        }
    };
}