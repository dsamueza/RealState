
//var vueVM;
var app
var IdJsonPredido
//function ApplyBindingTPredio(data) {
//    vueVM = new Vue({
//        el: "#divPoll",
//        data: {
//            poll: data
//        },
//        methods: {
//            keymonitor: function (event) {
//                var charCode = (event.which) ? event.which : event.keyCode
//                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
//                    return false;
//                }
//                console.log(charCode);
//                return true;
//            },
//            changeHandler: function (event) {
//                // change of userinput, do something
//                alert(event.id);
//            },
//            moment: function () {
//                return moment();
//            },
//            openModal: function () {
//                return openModal();
//            },
//            currentSlide: function (data) {
//                return currentSlide(data);
//            },
//            Save: function () {
//                return Save();
//            }
//        }
//    });



//    $.unblockUI();
//}


function bindPredio(Id) {
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
          
                ApplyBindingPredio(data);
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
        //data: {
        //    predios: [
        //        {
        //            IdProyecto: 0,
        //            IdPredio: 0,
        //            Secuencial: 0,
        //            Nombre: '',
        //            Zona:'',
        //            Dimension: '',
        //            latitud: '',
        //            longitud: '',
        //            Propietario: '',
        //            Estado:'',
        //            imagen:''}


        //    ]
        //},
        data: { predios: _model },
    methods: {
        street: function (e) {
          
            return 's'+e+'2';
        },
        map: function (e) {
            return 'm'+e + '1';

        },
        geoINI: function (e) {
            geo(e)
         
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
            alert(coordenadas);
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
                image: ''

            })

        }
    }
    })
  
}
function Save() {

    $.blockUI({ message: "cargando..." });

    $.ajax({
        url: "/UrbanProperty/GuardarPredios",
        type: "post",
        data: {
            ModelJson: ko.toJSON(app.$data.predios),
             IdArea: IdJsonPredido
        },
        success: function (data) {
            $.unblockUI();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $.unblockUI();
        }
    });


}