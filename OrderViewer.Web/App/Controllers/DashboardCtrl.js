angular.module('orderApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', 'Order'];

function DashboardCtrl($scope, Order) {
    var vm = this;
    vm.selectedOrder;

    vm.orders = [{ Id: 1 }, { Id: 2 }];
    Order.getOrders().then(function (orders) {
        vm.orders = orders;
    });

    vm.getOrderItems = Order.getOrderItems(vm.selectedOrder.Id).then(function (orderItems) {
        vm.orderItems = orderItems;
    });
    return vm;
};