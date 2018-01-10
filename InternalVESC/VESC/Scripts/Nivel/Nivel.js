var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Nivel/GetNivel",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaNivel = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddNivel = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Nivel";

        $scope.nivel = null;
    }

    $scope.TituloEditNivel = function (varNivel) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Nivel";

        $scope.nivel = varNivel;
    }

    $scope.EditNivel = function (varNivel) {
        $http
           ({
               method: "POST",
               url: "/Nivel/EditNivel",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { nivel: varNivel, listaNivel: $scope.listaNivel }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaNivel = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddNivel = function (varNivel) {
        $http
            ({
                method: "POST",
                url: "/Nivel/AddNivel",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { nivel: varNivel, listaNivel: $scope.listaNivel }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaNivel = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});