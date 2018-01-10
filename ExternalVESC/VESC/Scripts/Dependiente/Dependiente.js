var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Dependiente/GetDependiente",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");

               $scope.listaDependiente = datos.data.Resul;

               if (!datos.data.Session) {
                   $window.location.href = "/Login/Login";
               }
           }, function (error) {
               console.log("Error: " + error.error);
           });


    $scope.TituloAddDependiente = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Dependiente";

        $scope.dependiente = null;
    }

    $scope.TituloEditDependiente = function (varDependiente) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Dependiente";

        $scope.dependiente = varDependiente;
    }

    $scope.EditDependiente = function (varDependiente) {
        $http
           ({
               method: "POST",
               url: "/Dependiente/EditDependiente",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { dependiente: varDependiente, listaDependiente: $scope.listaDependiente }
           }).then(function (datos) {
               console.log("OK");

               $scope.listaDependiente = datos.data.Resul;

               if (!datos.data.Session) {
                   $window.location.href = "/Login/Login";
               }

           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddDependiente = function (varDependiente) {
        $http
            ({
                method: "POST",
                url: "/Dependiente/AddDependiente",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { dependiente: varDependiente, listaDependiente: $scope.listaDependiente }
            }).then(function (datos) {
                console.log("OK");

                $scope.listaDependiente = datos.data.Resul;

                if (!datos.data.Session) {
                    $window.location.href = "/Login/Login";
                }

            }, function (error) {
                console.log("ERROR");
            });
    }

});