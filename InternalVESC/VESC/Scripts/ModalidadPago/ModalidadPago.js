var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/ModalidadPago/GetModalidadPago",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaModalidadPago = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddModalidadPago = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Modalidad Pago";

        $scope.modalidadPago = null;
    }

    $scope.TituloEditModalidadPago = function (varModalidadPago) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Modalidad Pago";

        $scope.modalidadPago = varModalidadPago;
    }

    $scope.EditModalidadPago = function (varModalidadPago) {
        $http
           ({
               method: "POST",
               url: "/ModalidadPago/EditModalidadPago",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { modalidadPago: varModalidadPago, listaModalidadPago: $scope.listaModalidadPago }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaModalidadPago = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddModalidadPago = function (varModalidadPago) {
        $http
            ({
                method: "POST",
                url: "/ModalidadPago/AddModalidadPago",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { modalidadPago: varModalidadPago, listaModalidadPago: $scope.listaModalidadPago }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaModalidadPago = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});