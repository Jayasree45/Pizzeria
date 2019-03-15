function up(max) {
    document.getElementById("myNumber").value = parseInt(document.getElementById("myNumber").value) + 1;
    if (document.getElementById("myNumber").value >= parseInt(max)) {
        document.getElementById("myNumber").value = max;
    }

}
function down(min) {
    document.getElementById("myNumber").value = parseInt(document.getElementById("myNumber").value) - 1;
    if (document.getElementById("myNumber").value <= parseInt(min)) {
        document.getElementById("myNumber").value = min;
    }
}

function calc1() {

    var Price = parseFloat(document.getElementById("output").value);
//alert(Price + "1")
    var noTickets = document.getElementById("myNumber").value;
   // alert(noTickets + "2")

    var total = Price * noTickets
  //  alert(total + "3")

    if (!isNaN(total))
        document.getElementById("total").innerHTML = total;
   /// alert(Price + "4")

}
function calculate1(obj) {
    document.getElementById("output").innerHTML = obj.value;
  //  alert("hello")
    //quantTotal = getElementById('myNumber') * 100;
}


function ToppingsPrice() {
    //var price = 100;
    //price += 50;
    document.getElementById("priceText").value = parseInt(document.getElementById("priceText").value) + 50;
}


function calc() {

    var Price = parseFloat
        (document.getElementById("priceText").value);
    //alert(Price + " 1");
    var noOfUnits = parseInt(document.getElementById("myNumber").value);
    //alert(noOfUnits + " 2");
    var total = parseFloat(Price * noOfUnits);
    //alert(total + " 3");
    if (!isNaN(total))
        document.getElementById("priceText").innerHTML = total;
}
function calculate(obj) {
    document.getElementById("priceText").innerHTML = obj.value;
    //quantTotal = getElementById('myNumber') * 100;
}

//function ButtonClickQuickAdd() {
//    dataObj = JSON.stringify({
//        'input': $('#myNumber').val(),
//        'name': $('#total').val()
//    });

//    $.ajax({
//        url: "/Home/ReviewOrder",
//        type: 'POST',
//        async: false,
//        dataType: 'json',
//        contentType: 'application/json',
//        data: dataObj,
//        success: function (data) { },
//        error: function (xhr) { }
//    });

//}

function reviewFunct() {
    debugger;


    var radioval = $("input[type='radio'][name='j']:checked").val();
    var output = $('#total').val();
    dataObj = JSON.stringify({
        'input': radioval,
        'name': output
    });

    //$.ajax({
    //    url: "/Home/ReviewOrder",
    //    type: 'POST',
    //    async: false,
    //    dataType: 'json',
    //    contentType: 'application/json',
    //    data: dataObj,
    //    success: function (data) { },
    //    error: function (xhr) { }
    //});
    var saveUrl = "/Home/ReviewOrder1"
    //'@Url.Action("Home","ReviewOrder")';
    var newUrl = "/Home/ReviewOrder" + "?" + "input=" + radioval + "&" + "name=" + output;
    var final = "?input=" + radioval;

    //'@Url.Action("Home","ReviewOrder")';

    $.ajax({
        type: 'POST',
        url: saveUrl,
        //  data: dataObj, async: false,
        dataType: 'json',
        contentType: 'application/json',
        data: dataObj,
        // Some params omitted 
        success: function (res) {
            window.location.href = newUrl;
        },
        error: function () {
            alert('The worst error happened!');
        }
    });

    //var jobValue = document.getElementById('j').value
    // alert("review");
}


