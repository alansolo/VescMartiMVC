var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Club/GetClub",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaClub = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddClub = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Club";

        $scope.club = null;
    }

    $scope.TituloEditClub = function (varClub) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Club";

        $scope.club = varClub;
    }

    $scope.EditClub = function (varClub) {
        $http
           ({
               method: "POST",
               url: "/Club/EditClub",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { club: varClub, listaClub: $scope.listaClub }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaClub = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddClub = function (varClub) {
        $http
            ({
                method: "POST",
                url: "/Club/AddClub",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { club: varClub, listaClub: $scope.listaClub }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaClub = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});