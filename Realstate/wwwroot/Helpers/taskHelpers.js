//var vueVM;
var apps,vuetask
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
                bindtaskID(data[0].id)
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


function bindtaskID(Id) {
    
    IdJsonPredido = Id


    $.ajax({
        type: "GET",
        url: "/task/GetDetailTask",
        // async: false,
        data: {
            idPredio: IdJsonPredido
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data) {
         
                // geo(parseFloat(data[0].latitude.trim()), parseFloat(data[0].length.trim()));
 
                ApplyBindingTask(data);
              
            } else {
                alert("Error! no se ha encontrado task null" + error);
            
            }
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado El task" + error);
       
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

function ApplyBindingTask(_modeltask) {
 
    vuetask = new Vue({
        el: '#DetailTask',

        data: {
            tasks: _modeltask,
            coment_note:''},
        methods: {
            moment: function (e) {
                return moment(e);
            },
            time: function (e,e1) {
                var d = new Date(e);
                var d1 = new Date(e1);
                var diff = d1 - d
                console.log(d1)
                console.log(d)
                console.log(diff/60000)
                return (diff / 60000) +' minutos';
            },
            addlist(_model) {
                this.tasks.push(_model)
            },
        },
        computed: {
            // Metódo que faz o sort das colunas, definindo o nome da coluna e a ordem
            orderedUsers: function () {
                  return _.orderBy(this.tasks, 'id','desc')
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




function SaveNotaAJAX(Id, idarea,area) {

    IdJsonPredido = Id
    IdJsonArea = idarea

    $.ajax({
        type: "post",
        url: "/task/_Note",
        // async: false,
        data: {
            coment: area,
            Idpredio: IdJsonPredido.toString()
        },
        success: function (data) {
            if (data) {

                // geo(parseFloat(data[0].latitude.trim()), parseFloat(data[0].length.trim()));
                vuetask.addlist(data[0])
                CKEDITOR.instances['coment_note'].setData('');;
                $.toaster({
                    priority: 'success',
                    title: 'Aviso',
                    message: "La nota fue creada",
                    settings: {
                        timeout: 5500
                    }
                });

            } else {
                alert("Error! no se ha encontrado task " + error);
                return ''

            }
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado El task" + error);

        }
    });

}



function SaveMailAJAX(Id, asunto,destinatario,msg) {

    IdJsonPredido = Id
  

    $.ajax({
        type: "post",
        url: "/task/_Message",
        
        // async: false,
        data: {
            coment: msg,
            subject: asunto,
            des: destinatario,
            Idpredio: IdJsonPredido.toString()
        },
        success: function (data) {
            if (data) {

                // geo(parseFloat(data[0].latitude.trim()), parseFloat(data[0].length.trim()));
                vuetask.addlist(data[0])
                CKEDITOR.instances['coment_note'].setData('');;
                $.toaster({
                    priority: 'success',
                    title: 'Aviso',
                    message: "El mail  fue enviado",
                    settings: {
                        timeout: 5500
                    }
                });

            } else {
                alert("Error! no se ha encontrado task " + error);
                return ''

            }
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado El task" + error);

        }
    });

}

function SaveReunionAJAX(Id, asunto,tiempo, msg) {

    IdJsonPredido = Id


    $.ajax({
        type: "post",
        url: "/task/_interaction",

        // async: false,
        data: {
            coment: msg,
            subject: asunto,
            reunion: tiempo,
            Idpredio: IdJsonPredido.toString()
        },
        success: function (data) {
            if (data) {

                // geo(parseFloat(data[0].latitude.trim()), parseFloat(data[0].length.trim()));
                vuetask.addlist(data[0])
                CKEDITOR.instances['coment_note'].setData('');;
                $.toaster({
                    priority: 'success',
                    title: 'Aviso',
                    message: "La reunion fue registrada",
                    settings: {
                        timeout: 5500
                    }
                });

            } else {
                alert("Error! no se ha encontrado task " + error);
                return ''

            }
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado El task" + error);

        }
    });

}