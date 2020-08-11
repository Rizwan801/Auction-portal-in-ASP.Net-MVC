

function signupdata()
{
    var MdlCustomer = [];
    MdlCustomer[0] = new Object();
    if ($("#Fname").val()) {

        MdlCustomer[0].Fname = $("#Fname").val();
    }
    else {
        alert("First name Missing");
        return false;
    }
    if ($("#Lname").val()) {
        MdlCustomer[0].Lname = $("#Lname").val();
    }
    else {
        alert("last name Missing");
        return false;
    }
    if ($("#Email").val()) {
        MdlCustomer[0].Email = $("#Email").val();
    }
    else {
        alert("Email address Missing");
        return false;
    }
        if ($("#password").val()) {
            MdlCustomer[0].password = $("#password").val();
        }
        else {
            alert("password Missing");
            return false;
        }

            if ($("#phone").val()) {
                MdlCustomer[0].phone = $("#phone").val().toString();
            }
            else {
                alert("Phone number Missing");
                return false;
            }

                if ($("#city").val()) {
                    MdlCustomer[0].city = $("#city").val();
                }
                else {
                    alert("City name Missing");
                    return false;
                }

    var a = JSON.stringify(MdlCustomer);
    $.ajax({
        type: "POST",
        url: "/auction_portal/AddSignupdata",
        data: a,
        datatype: "json",
        traditional: true,
        async: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            alert('successfully imported into database');

        },
        error: function () {
            alert('error occure will imported into database');
        }

    });




}