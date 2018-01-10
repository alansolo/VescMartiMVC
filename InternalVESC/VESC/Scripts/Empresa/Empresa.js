var app = angular.module("MyApp", [])

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {
    $http
           ({
               method: "GET",
               url: "/Empresa/GetEmpresa",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" }
           }).then(function (datos) {
               console.log("OK");
               $scope.listaEmpresa = datos.data;
           }, function (error) {
               console.log("Error: "+ error.error);
           });

    //$("#formularioEmpresa").validate(
    //{
    //    rules:
    //    {
    //        empresa:
    //        {
    //            required: true,
    //            minlength: 2
    //        }
    //    },
    //    messages:
    //    {
    //        empresa:
    //        {
    //            requerid: "* Campo Obligatorio",
    //            minlength: "La empresa debe tener mas de 2 caracteres"
    //        }
    //    }
    //});


    $("numerico").keypress(function (e) {
        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            $("#errmsg").html("Solo se permiten numeros").show().fadeOut("slow");
            return false;
        }
    });

    $scope.TituloAddEmpresa = function () {
        console.log("Add Titulo");

        $scope.mostrarBotonesAdd = true;
        $scope.mostrarBotonesEdit = false;

        $scope.modalTitle = "Nueva Empresa";

        $scope.empresa = [];
    }

    $scope.TituloEditEmpresa = function (varEmpresa) {
        console.log("Edit Titulo");

        $scope.mostrarBotonesAdd = false;
        $scope.mostrarBotonesEdit = true;

        $scope.modalTitle = "Editar Empresa ";

        $scope.empresa = varEmpresa;
    }

    $scope.EditEmpresa = function (varEmpresa) {
        $scope.modalTitle = "Editar Empresa ";

        $http
           ({
               method: "POST",
               url: "/Empresa/EditEmpresa",
               datatype: 'json',
               contentType: 'application/json; charset=utf-8',
               header: { "contentType": "application/json" },
               data: { empresa: varEmpresa }
           }).then(function (datos) {
               console.log("OK");
               $scope.empresa = datos.data;
           }, function (error) {
               console.log("ERROR");
           });
    }

    $scope.AddEmpresa = function ()
    {
        //var form = $("#formularioEmpresa");

        //if (form.checkValidity() === false) {
        //    event.preventDefault();
        //    event.stopPropagation();
        //}
        //form.classList.add('was-validated');


        //$http
        //    ({
        //        method: "GET",
        //        url: "/Empresa/AddEmpresa",
        //        datatype: 'json',
        //        contentType: 'application/json; charset=utf-8',
        //        header: { "contentType": "application/json" }
        //    }).then(function (datos) {
        //        console.log("entro " + datos.data.empresa1);
        //    }, function (error) {
        //        console.log("no");
        //    });
    }

    $scope.AgregarEmpresa = function ()
    {
        $http
            ({
                method: "GET",
                url: "/Empresa/GetEmpresa",
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                header: { "contentType": "application/json" }
            }).then(function (datos) {
                console.log("entro " + datos.data.empresa1);
            }, function (error) {
                console.log("no");
            });
    }
});