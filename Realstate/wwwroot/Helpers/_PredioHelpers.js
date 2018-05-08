
//var vueVM;
var app
var IdJsonPredido



function bindPredio(Id,status) {
    IdJsonPredido = Id
    $.blockUI({ message: "cargando..." });
    $.ajax({
        type: "GET",
        url: "/UrbanProperty/GetGetPredio",
        // async: false,
        data: {
            idPredio: IdJsonPredido
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data) {
  
                if (status == 1) { ApplyBindingPredio(data);}
                if (status == 2) {

                  
                 
                    jQuery.each(data, function (index, value) {
                        //    app.removedata(0);
                          app.addlistPredio(value.id, value.idZonaProspectada, index);
                    });
                }

                $.unblockUI();
            } else {
                alert("Error! no se ha encontrado la tarea2" + error);
                $.unblockUI();
            }
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado la tarea222" + error);
            $.unblockUI();
        }
    });

}
function ApplyBindingPredio(_model) {

    app = new Vue({
        el: '#lote',
        data: { predios: _model },
    methods: {
        street: function (e) {
          
            return 's'+e+'2';
        },
        map: function (e) {
            return 'm'+e + '1';

        },
        geoINI: function (e) {
            geo(e, -0.1559192000, -78.4769077000 )
         
        },
        geoINIs: function (e, index) {
        
            var cadena = this.predios[index].coordenas,
                separador = ",", // un espacio en blanco
                limite = 2,
                arregloDeSubCadenas = cadena.split(separador, limite)

            this.predios[index].latitude = arregloDeSubCadenas[0].trim()
            this.predios[index].length = arregloDeSubCadenas[1].trim()

            geo(index, parseFloat(arregloDeSubCadenas[0].trim()), parseFloat(arregloDeSubCadenas[1].trim()))
            
        },
        processFile: function (e) {
           console.log(e.target.files[0])
        },
        onFileChange(e,index) {
            console.log(e.target.files )
            var files = e.target.files || e.dataTransfer.files;
            if (!files.length)
                return;
            this.createImage(files[0],index);
        },
        createImage(file, index) {
            var image = new Image();
            var reader = new FileReader();
            var vm = this;
            reader.onload = (e) => {
                vm.predios[index].image = e.target.result;
            };
            reader.readAsDataURL(file);
        },
        removeImage: function (e) {
            this.predios[e].image = '';
        },
        visualizar: function (e) {
            var coordenadas = panorama[e].getPosition() + '';
            var coord1 = coordenadas.replace("(", "")
            var coord2 = coord1.replace(")", "")
            this.predios[e].coordenas= coord2
        },
        addPredio: function () {
            this.predios.push({
                id:0,
                idProyecto: 0,
                idZonaProspectada: 0,
                secuencial: 0,
                idPropietario: 0,
                name: '',
                zona: '',
                value: '',
                latitude: '',
                length: '',
                statusRegister: 'D',
                image: '',
                coordenas:'-9LG'

            })



        },
        addRemove: function (index) {
          
            deletePredio(this.predios[index].id, index)
        }, removedata: function (index) {

            this.predios.splice(index, 1);
        },
        addlistPredio: function (_id, area,index) {
            
            this.predios[index].id = _id
            this.predios[index].idZonaProspectada = area
        },
        ViewPropietarioVUE: function (_id) {
            DataPropietario(_id)
        }
    }
    })
  
}
function Save() {

    $.blockUI({ message: "Guardando..." });

    $.ajax({
        url: "/UrbanProperty/GuardarPredios",
        type: "post",
        data: {
            ModelJson: ko.toJSON(app.$data.predios),
            IdArea: IdJsonPredido
          
        },
        success: function (data) {

            bindPredio(IdAreaProspeccion, 2)
            $.unblockUI();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $.unblockUI();
        }
    });


}
function addlistVue() {
    app.addPredio()
}
function deletePredio(id,index) {

    $.blockUI({ message: "Eliminando..." });

    $.ajax({
        url: "/UrbanProperty/deletePredios",
        type: "post",
        data: {
            
            IdPredio: id

        },
        success: function (data) {

            if (data == '1') {
                bootbox.alert("Predio Eliminado")
                app.removedata(index);
            }

            if (data == '-1') {
                bootbox.alert("Predio tiene tareas creadas")
            }
            $.unblockUI();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $.unblockUI();
        }
    });


}

function DataPropietario(id) {

 

    $.ajax({
        url: "/UrbanProperty/GetPropietario",
        type: "get",
        data: {

            idPropietario: id

        },
        success: function (data) {


            jQuery.each(data, function (index, value) {
                //    app.removedata(0);
                var dialog = bootbox.dialog({
                    title: 'Datos del Propietario',
                    size: 'small',
                    message: "<ul style='text-decoration: none; list-style: none;'><li > <b> Cédula:</b> "
                        + value.cedula
                        + "</li> <li><b>Nombre:</b>  "
                        + value.name
                        + "</li>"
                        + "</li> <li><b>Telefono:</b>  "
                        + value.phone
                        + "</li> "
                        + "</li> <li><b>Celular:</b>  "
                        + value.movil
                        + "</li> "
                        + "</li> <li><b>Mail:</b>  "
                        + value.email
                        + "</li></ul > ",
                    buttons: {
                        cancel: {
                            label: "OK",
                            className: 'btn-danger',

                        }

                    }

                });
            });
          
          
         
        },
        error: function (xhr, ajaxOptions, thrownError) {
          
        }
    });


}
