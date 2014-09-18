'use strict';

angular.module('app.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$window', '$http', function ($scope, $window, $http) {
        $scope.$root.title = 'Feedback System';
        $scope.currentPage = 0;
        $scope.pageSize = 10;

        $http.get('http://feedbacksystem.apphb.com/api/Feedbacks/Public').success(function (data) {
            var feedbacks = [];

            angular.forEach(data, function (feedback) {
                feedbacks.push(feedback);
            });

            $scope.feedbacks = feedbacks;
        });

        //$scope.feedbacks = [{
        //    id: 1,
        //    user: 'Hater Company',
        //    feedback: 'Hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate hate'
        //}, {
        //    id: 2,
        //    user: 'Another hater',
        //    feedback: 'Bastarts....'
        //}, {
        //    id: 3,
        //    user: 'Happy Company',
        //    feedback: 'You are awesomeeeee'
        //}];

        $scope.numberOfPages = function () {
            return Math.ceil($scope.feedbacks.length / $scope.pageSize);
        }
    }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'About';
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        $scope.$root.title = 'Sign In';

        // TODO: Authorize a user
        $scope.login = function (username, password) {
            $http.post('http://feedbacksystem.apphb.com/Token', {
                Username: username,
                Password: password,
                grant_type: "password"
            }).success(function () {
                $location.path('/');
            });

            return false;
        };
    }])

    // Path: /register
    .controller('RegisterCtrl', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        $scope.$root.title = 'Registration';

        $scope.register = function (username, password, confirmedPassword) {
            if (password == confirmedPassword) {
                $http.post('http://feedbacksystem.apphb.com/api/Account/Register', {
                    Email: username,
                    Password: password,
                    ConfirmPassword: confirmedPassword
                }).success(function () {
                    $location.path('/');
                });
            }
            else {
                $location.path('/register');
            }

            return false;
        };
    }])

    // Path: /createFeedback
    .controller('CreateFeedbackCtrl', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        $scope.title = 'Give Feedback';
        
        $scope.create = function (type, addressTo, text) {
            $http.post('http://feedbacksystem.apphb.com/api/Feedbacks/Create', {
                Type: type,
                PostDate: new Date(),
                Text: text,
                AddressedTo: addressTo
            }).success(function () {
                $location.path('/');
            });

            return false;
        };
    }])
    
    // Path: /viewFeedback
    .controller('ViewFeedbackCtrl', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {//, '$routeParams', $routeParams
        $scope.title = 'Feedback information';

        var feedbackId = 6;//$routeParams.id;

        $http.get('http://feedbacksystem.apphb.com/api/Feedbacks/ById/' + feedbackId).success(function (data) {
            console.log(data);
            $scope.feedbackText = data.Text;
        });
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
    }]);