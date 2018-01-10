var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/RazonSocial/GetRazonSocial",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaRazonSocial = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddRazonSocial = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nueva Empresa";

        $scope.razonSocial = [];
    }

    $scope.TituloEditRazonSocial = function (varRazonSocial) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Empresa ";

        $scope.razonSocial = varRazonSocial;
    }

    $scope.EditRazonSocial = function (varRazonSocial) {
        $scope.modalTitle = "Editar Empresa ";

        $http
           ({
               method: "POST",
               url: "/RazonSocial/EditRazonSocial",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { razonSocial: varRazonSocial }
           }).then(function (datos) {
               console.log("OK");
               $scope.razonSocial = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddRazonSocial = function () {
        $http
            ({
                method: "GET",
                url: "/RazonSocial/AddRazonSocial",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" }
            }).then(function (datos) {
                console.log("OK");
            }, function (error) {
                console.log("ERROR");
            });
    }

});