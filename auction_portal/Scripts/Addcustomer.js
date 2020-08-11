

function Customerdata()
{
     
    var MdlCustomer = [];
    MdlCustomer[0] = new Object();

    MdlCustomer[0].Email = $("#Email").val();
    MdlCustomer[0].password = $("#password").val();
    

    var a = JSON.stringify(MdlCustomer);
    $.ajax({
        type: "POST",
        url: "/auction_portalController/loginfunc",
        data: a,
        datatype: "json",
        traditional: true,
        async: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            alert('successfully imported into xero');

        },
        error: function (jxhr) {
            alert('error occure will imported into xero');
        }

    });




}