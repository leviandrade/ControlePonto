function requisicao(endereco, tipo, dados) {
    $(".loading").removeClass("d-none");

    var promise = $.ajax({
        cache: false,
        url: endereco,
        type: tipo,
        data: dados
    }).always(function () {
        $(".loading").addClass("d-none")
    });

    return promise;
}