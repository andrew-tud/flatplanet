AngularAppCounter.controller("CounterController", function ($scope, CounterFactory, $location, $rootScope, $routeParams) {
    $scope.generalErrorMessage = "";
    $scope.CounterMessage = "Increment counter";

    var promise;
    promise = CounterFactory.getCounter();
    promise.then(
    function (payload) {
        $scope.generalErrorMessage = "";
        if (payload.data != null) {
            $scope.Counter = payload.data.Counter1;
            if ($scope.Counter == 10) {
                $scope.CounterMessage = "Reached maximum (cannot increment)";
            }
        }
        else {
            $scope.generalErrorMessage = payload.data.error;
        }
    },
    function (errorPayload) {
        $scope.generalErrorMessage = "Server error.";
    });
    
    $scope.whenLoading = "Incrementing counter...";
    $scope.addCounter = function (id) {
        if ($scope.Counter < 10 && $scope.Counter != null && $scope.CounterMessage != $scope.whenLoading)
        {
            $scope.CounterMessage = $scope.whenLoading;
            var promise;
            promise = CounterFactory.addCounter(1);
            promise.then(
                function (payload) {
                    $scope.CounterMessage = "Increment counter";
                    $scope.generalErrorMessage = "";
                    if (payload.data != null) {
                        $scope.generalErrorMessage = "Counter incremented from previous value: " + $scope.Counter;
                        $scope.Counter = payload.data.Counter1;
                        if ($scope.Counter == 10) {
                            $scope.CounterMessage = "Reached maximum (cannot increment)";
                        }
                    }
                    else {
                        $scope.generalErrorMessage = payload.data.error;
                    }
                },
                function (errorPayload) {
                    $scope.generalErrorMessage = "Server error.";
                });
        }
    };

});