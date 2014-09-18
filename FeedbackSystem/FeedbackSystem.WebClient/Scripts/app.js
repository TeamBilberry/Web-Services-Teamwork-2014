'use strict';

angular.module('app', ['ui.router', 'app.filters', 'app.services', 'app.directives', 'app.controllers'])
    .config(['$stateProvider', '$locationProvider', function ($stateProvider, $locationProvider) {

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/views/index',
                controller: 'HomeCtrl'

            })
            .state('about', {
                url: '/about',
                templateUrl: '/views/about',
                controller: 'AboutCtrl'
            })
            .state('createFeedback', {
                url: '/createFeedback',
                templateUrl: '/views/createFeedback',
                controller: 'CreateFeedbackCtrl'
            })
            .state('viewFeedback', {
                url: '/viewFeedback/:id',
                templateUrl: '/views/viewFeedback',
                controller: 'ViewFeedbackCtrl'
            })
            .state('login', {
                url: '/login',
                layout: 'basic',
                templateUrl: '/views/login',
                controller: 'LoginCtrl'
            })
            .state('register', {
                url: '/register',
                layout: 'basic',
                templateUrl: '/views/register',
                controller: 'RegisterCtrl'
            })
            .state('otherwise', {
                url: '*path',
                templateUrl: '/views/404',
                controller: 'Error404Ctrl'
            });

        $locationProvider.html5Mode(true);

    }])

    // Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
    // can be injected here. This is to prevent further system configuration during application run time.
    .run(['$templateCache', '$rootScope', '$state', '$stateParams', function ($templateCache, $rootScope, $state, $stateParams) {

        // <ui-view> contains a pre-rendered template for the current view
        // caching it will prevent a round-trip to a server at the first page load
        var view = angular.element('#ui-view');
        $templateCache.put(view.data('tmpl-url'), view.html());

        // Allows to retrieve UI Router state information from inside templates
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.$on('$stateChangeSuccess', function (event, toState) {

            // Sets the layout name, which can be used to display different layouts (header, footer etc.)
            // based on which page the user is located
            $rootScope.layout = toState.layout;
        });
    }]);