var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Plan/GetPlan",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaPlan = datos.data.ListaPlan;
               $scope.listaModalidadPago = datos.data.ListaModalidadPago;
           }, function (error) {
               console.log("Error: " + error.error);
           });

    //$.validator.setDefaults({
    //    submitHandler: function () {
    //        alert("submitted!");
    //    }
    //});

    //$("#signupForm").validate({
    //    rules: {
    //        plan: {
    //            required: true,
    //            email: true
    //        },
    //        descripcion: {
    //            required: true,
    //            minlength: 5
    //        }
    //    },
    //    messages: {
    //        plan: "Please enter your firstname",
    //        descripcion: {
    //            required: "Please enter a username",
    //            minlength: "Your username must consist of at least 2 characters"
    //        }
    //    }
    //});


    $scope.TituloAddPlan = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nuevo Plan Empresarial";

        $scope.plan = null;
    }

    $scope.TituloEditPlan = function (varPlan) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Plan Empresarial";

        $scope.plan = varPlan;
    }

    $scope.EditPlan = function (varPlan) {
        $http
           ({
               method: "POST",
               url: "/Plan/EditPlan",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { plan: varPlan, listaPlan: $scope.listaPlan }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaPlan = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddPlan = function (varPlan) {

        $http
            ({
                method: "POST",
                url: "/Plan/AddPlan",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" },
                data: { plan: varPlan, listaPlan: $scope.listaPlan, listaModalidadPago: $scope.listaModalidadPago }
            }).then(function (datos) {
                console.log("OK");
                $scope.listaPlan = datos.data;
            }, function (error) {
                console.log("ERROR");
            });
    }

});