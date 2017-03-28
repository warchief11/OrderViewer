(function () {

    var app = angular.module('orderApp', ['ui.router']);

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
             .state("dashboard", {
                 url: "/",
                 templateUrl: 'App/templates/dashboard.html',
                 controller: 'DashboardCtrl as vm'
             })
             .state('about', {
                 url: '/about',
                 templateUrl: 'App/templates/about.html',
             });
    }]);
}());