// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function atualizar(event) {
    var lineTable = $(event).closest("tr");

    var id = lineTable.find("td:eq(0)").text().trim();
    var name = lineTable.find("td:eq(1)").text().trim();
    var email = lineTable.find("td:eq(2)").text().trim();

    console.log("Id: " + id);
    console.log("Nome: " + name);
    console.log("Email: " + email);

    $("#id").val(id);
    $("#nome").val(name);
    $("#email").val(email);
}

function remover(event) {
    var lineTable = $(event).closest("tr");

    var id = lineTable.find("td:eq(0)").text().trim();
    
    let data = CreateElement(id);
    let url = "/home/remover";

    $.post(url, data, function (resp) {
        $('[message]').html("Post deletado com sucesso");
        $('[messageAlert]').addClass("show");
        $('#messageStatus').show();
        $(event).parent().parent().remove();
        setTimeout(function () {
            $('#messageStatus').hide();
        }, 20000);
    }).fail(function (error) {
        $('[messageAlert]').removeClass("alert-success").addClass("alert-warning").addClass("show");
        $('[message]').html("Erro ao editar" + error.responseText)
        $('#messageStatus').show();
        setTimeout(function () {
            $('#messageStatus').hide();
        }, 3500);
    });
}

function CreateElement(id) {
    return {
        Id: id,
    };
}