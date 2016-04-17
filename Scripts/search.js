var app = angular.module('SearchApp', []);

app.controller('customerSearchController', function ($scope, $http) {
    $http.get("http://localhost:65081/Musteriler/GetAllCustomerJson").success(function (response) {
        $scope.customers = response;
    });
});

app.controller('staffSearchController', function ($scope, $http) {
    $http.get("http://localhost:65081/Calisanlar/GetAllStaffJson").success(function (response) {
        $scope.staffs = response;
    });
});

app.controller('supplierSearchController', function ($scope, $http) {
    $http.get("http://localhost:65081/Tedarikciler/GetAllSupplierJson").success(function (response) {
        $scope.suppliers = response;
    });
});

app.controller('serviceSearchController', function ($scope, $http) {
    $http.get("http://localhost:65081/Servisler/GetAllServiceJson").success(function (response) {
        $scope.services = response;
    });
});

app.controller('assetSearchController', function ($scope, $http) {
    $http.get("http://localhost:65081/Satislar/GetAllAssetJson").success(function (response) {
        $scope.assets = response;
    });
});

app.controller('paymentSearchController', function ($scope, $http) {
    $http.get("http://localhost:65081/Giderler/GetAllPayment").success(function (response) {
        $scope.payments = response;
    });
});
