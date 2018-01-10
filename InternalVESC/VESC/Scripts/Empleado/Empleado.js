var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Empleado/GetEmpleado",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaEmpleado = datos.data;
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddEmpleado = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Empleado";

        $scope.empleado = null;
    }

    $scope.TituloEditEmpleado = function (varEmpleado) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Empleado";

        $scope.empleado = varEmpleado;
    }

    $scope.EditEmpleado = function (varEmpleado) {
        $http
           ({
               method: "POST",
               url: "/Empleado/EditEmpleado",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { empleado: varEmpleado, listaEmpleado: $scope.listaEmpleado }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaEmpleado = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddEmpleado = function (varEmpleado) {
        $http
            ({
                method: "POST",
                url: "/Empleado/AddEmpleado",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { empleado: varEmpleado, listaEmpleado: $scope.listaEmpleado }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaEmpleado = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});