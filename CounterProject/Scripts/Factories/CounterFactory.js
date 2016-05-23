AngularAppCounter.factory('CounterFactory', function ($http, $rootScope) {
    return {
        addCounter: function (id) {
            return $http({
                method: 'GET',
                url: '/api/counter/' + id
            });
        },
        getCounter: function () {
            return $http({
                method: 'GET',
                url: '/api/counter'
            });
        }
    }
});