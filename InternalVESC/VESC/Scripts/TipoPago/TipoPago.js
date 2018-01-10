var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/TipoPago/GetTipoPago",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaTipoPago = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddTipoPago = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Tipo Pago";

        $scope.formato = null;
    }

    $scope.TituloEditTipoPago = function (varTipoPago) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Tipo Pago";

        $scope.formato = varTipoPago;
    }

    $scope.EditTipoPago = function (varTipoPago) {
        $http
           ({
               method: "POST",
               url: "/TipoPago/EditTipoPago",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { formato: varTipoPago, listaTipoPago: $scope.listaTipoPago }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaTipoPago = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddTipoPago = function (varTipoPago) {
        $http
            ({
                method: "POST",
                url: "/TipoPago/AddTipoPago",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { formato: varTipoPago, listaTipoPago: $scope.listaTipoPago }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaTipoPago = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});