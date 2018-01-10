var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Formato/GetFormato",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaFormato = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddFormato = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Formato Club";

        $scope.formato = null;
    }

    $scope.TituloEditFormato = function (varFormato) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Formato Club";

        $scope.formato = varFormato;
    }

    $scope.EditFormato = function (varFormato) {
        $http
           ({
               method: "POST",
               url: "/Formato/EditFormato",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { formato: varFormato, listaFormato: $scope.listaFormato }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaFormato = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddFormato = function (varFormato) {
        $http
            ({
                method: "POST",
                url: "/Formato/AddFormato",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { formato: varFormato, listaFormato: $scope.listaFormato }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaFormato = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});