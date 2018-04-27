
//var vueVM;

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
    alert(Id)

}

var app = new Vue({
    el: '#app',
    data: {
        message: 1
    },
    methods: {
        repeat: function () {
            alert(this.message)
            this.message = this.message+1
        },
    }
})