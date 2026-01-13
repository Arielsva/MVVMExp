function SetModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal('show');
                            bindForm(this);
                        });
                    return false;
                });
        });
    });
}

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#AddressTarget').load(result.url);
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });

        SetModal();
        return false;
    });
}

function SearchZipCode() {
    $(document).ready(function () {

        function clear_zip_form() {
            $("#Address_Street").val("");
            $("#Address_Neighborhood").val("");
            $("#Address_City").val("");
            $("#Address_State").val("");
        }

        $("#Address_PostalCode").blur(function () {

            var zip = $(this).val().replace(/\D/g, '');

            if (zip != "") {

                var validzipcode = /^[0-9]{8}$/;

                if (validzipcode.test(zip)) {

                    $("#Address_Street").val("...");
                    $("#Address_Neighborhood").val("...");
                    $("#Address_City").val("...");
                    $("#Address_State").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + zip + "/json/?callback=?",
                        function (data) {

                            if (!("erro" in data)) {
                                $("#Address_Street").val(data.logradouro);
                                $("#Address_Neighborhood").val(data.bairro);
                                $("#Address_City").val(data.localidade);
                                $("#Address_State").val(data.uf);
                            } 
                            else {
                                clear_zip_form();
                                alert("ZIP code not found.");
                            }
                        });
                } 
                else {
                    clear_zip_form();
                    alert("Invalid ZIP code format.");
                }
            } 
            else {
                clear_zip_form();
            }
        });
    });
}