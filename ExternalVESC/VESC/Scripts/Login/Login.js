var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window, $location) {

    $scope.ValidarLogin = function (varUsuario, varContrasena) {
        $http
           ({
               method: "POST",
               url: "/Login/ValidarLogin",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { usuario: varUsuario, contrasena: varContrasena }
           }).then(function (datos) {
               console.log("OK");
               $scope.loginRequest = datos.data;
               $scope.mostrarMensaje = true;

               if($scope.loginRequest.Success)
               {
                   $scope.mostrarMensaje = false;
                   $window.location.href = "/Empleado/Empleado";
               }

           }, function (error) {
               console.log("ERROR");
           });
    }

});