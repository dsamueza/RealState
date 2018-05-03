//var vueVM;
var apps
var IdJsonPredido


function bindPredioID(Id) {
    IdJsonPredido = Id
    $.blockUI({ message: "cargando..." });

    $.ajax({
        type: "GET",
        url: "/task/GetPredio",
        // async: false,
        data: {
            idPredio: IdJsonPredido
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data) {
                ApplyBindingPredioUnique(data);
               // geo(parseFloat(data[0].latitude.trim()), parseFloat(data[0].length.trim()));
                geo(-0.1559192, -78.4769077);
                $.unblockUI();
            } else {
                alert("Error! no se ha encontrado El predio" + error);
                $.unblockUI();
            }
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado El predio" + error);
            $.unblockUI();
        }
    });

}
function ApplyBindingPredioUnique(_model) {
  
    apps = new Vue({
        el: '#PredioTask',
    
        data: { predios: _model },
        methods: {
            street: function (e) {

                return 's' + e + '2';
            },
            map: function (e) {
                return 'm' + e + '1';

            },
            geoINI: function (e) {
                geo(e, -0.1559192000, -78.4769077000)

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
            onFileChange(e, index) {
                console.log(e.target.files)
                var files = e.target.files || e.dataTransfer.files;
                if (!files.length)
                    return;
                this.createImage(files[0], index);
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
                bootbox.alert({
                    title: "Coordenadas",
                    message: coord2,
                    backdrop: true
                });
            },
            addPredio: function () {
                this.predios.push({
                    id: 0,
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
                    coordenas: '-9LG'

                })

            }
        }
    })

}

var panorama;
var fenway

function geo(latC, lngC) {
    fenway = { lat: latC, lng: lngC };
    initialize()
}
function initialize() {
    console.log(fenway)
    var map = new google.maps.Map(document.getElementById('map1'), {
        center: fenway,
        zoom: 18
    });
    panorama = new google.maps.StreetViewPanorama(
        document.getElementById('street1'), {
            position: fenway,
            pov: {
                heading: 34,
                pitch: 10
            }
        });

    map.setStreetView(panorama);

}