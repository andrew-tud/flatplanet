var AngularAppCounter = angular.module('AngularAppCounter', ['ngRoute'])
    .config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
    })
    .config(function ($routeProvider, $locationProvider) {

        $routeProvider.when('', {
            templateUrl: '/Templates/Counter/View.html',
            controller: 'CounterController'
        });
        $routeProvider.when('/', {
            templateUrl: '/Templates/Counter/View.html',
            controller: 'CounterController'
        });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    })
    .directive('onlyDigits', function () {

        return {
            restrict: 'A',
            require: '?ngModel',
            link: function (scope, element, attrs, modelCtrl) {
                modelCtrl.$parsers.push(function (inputValue) {
                    if (inputValue == undefined) return '';
                    var transformedInput = inputValue.replace(/[^0-9]/g, '');
                    if (transformedInput !== inputValue) {
                        modelCtrl.$setViewValue(transformedInput);
                        modelCtrl.$render();
                    }
                    return transformedInput;
                });
            }
        };
    }).directive('onlyDigitsDecimals', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attr, ctrl) {
                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^0-9.]/g, '');

                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }
                        return parseFloat(digits);
                    }
                    return undefined;
                }
                ctrl.$parsers.push(inputValue);
            }
        };
    }).directive('onlyDigitsDashes', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attr, ctrl) {
                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^0-9\-]/g, '');

                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }
                        return parseFloat(digits);
                    }
                    return undefined;
                }
                ctrl.$parsers.push(inputValue);
            }
        };
    });

AngularAppCounter.run(function ($rootScope, $location) {
    $rootScope.go = function (path) {
        $location.path(path);
    };
});

