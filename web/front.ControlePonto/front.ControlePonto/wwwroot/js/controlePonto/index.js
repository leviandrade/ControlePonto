var url = urlApis.controlePonto;
var pontos;

$("#cpf").mask('000.000.000-00', { reverse: true });

$("#frmControlePonto").on("submit", function (event) {
    event.preventDefault();
    requisicao(urlApis.controlePonto + "RegistroPonto/" +
        + $("#cpf").val().replace(/[^\d]+/g, '') + "/" + $("#inicio").val() + "/" + $("#termino").val(), "GET").done(function (retorno) {
            if (retorno.success) {
                pontos = retorno.data;
                let partesInicio = $("#inicio").val().split("-")
                var dtInicio = new Date(parseInt(partesInicio[0]), parseInt(partesInicio[1]) - 1, parseInt(partesInicio[2]));

                let partesTermino = $("#termino").val().split("-")
                var dtTermino = new Date(parseInt(partesTermino[0]), parseInt(partesTermino[1]) - 1, parseInt(partesTermino[2]));
                for (var i = dtInicio; i <= dtTermino; i = adicionarDia(dtInicio, 1)) {
                    let registrosDia = retorno.data.filter(p => moment(p.dtRegistroPonto).format("DD/MM/YYYY") == moment(i).format("DD/MM/YYYY"));
                    let entrada1 = registrosDia[0] != undefined ? moment(registrosDia[0].dtRegistroPonto).format("HH:mm") : "";
                    let entrada2 = registrosDia[1] != undefined ? moment(registrosDia[1].dtRegistroPonto).format("HH:mm") : "";
                    let saida1 = registrosDia[2] != undefined ? moment(registrosDia[2].dtRegistroPonto).format("HH:mm") : "";
                    let saida2 = registrosDia[3] != undefined ? moment(registrosDia[3].dtRegistroPonto).format("HH:mm") : "";
                    $("#tbodyPontos").append("<tr><th>" + moment(i).format("DD/MM/YYYY") +
                        "</th><td style='text-decoration: underline; cursor:pointer' class='text-center'  onclick=visualizarImagem('" + (registrosDia[0] != undefined ? registrosDia[0].id : "") + "')>" + entrada1 + "</td>" +
                        "<td style='text-decoration: underline; cursor:pointer' class='text-center' onclick=visualizarImagem('" + (registrosDia[1] != undefined ? registrosDia[1].id : '') + "')>" + saida1 + "</td>" +
                        "<td style='text-decoration: underline; cursor:pointer' class='text-center' onclick=visualizarImagem('" + (registrosDia[2] != undefined ? registrosDia[2].id : '') + "')>" + entrada2 + "</td>" +
                        "<td style='text-decoration: underline; cursor:pointer' class='text-center' onclick=visualizarImagem('" + (registrosDia[3] != undefined ? registrosDia[3].id : '') + "')>" + saida2 + "</td > " +
                        "</tr>");
                }
                $("#cardPontos").removeClass("d-none");
            }
        })
})

function visualizarImagem(id) {
    let ponto = pontos.filter(p => p.id == id)[0];
    bootbox.alert({
        message: "<img style='width: 400px' src='" + ponto.imagem + "'/><br/><a target='_blank' href='https://maps.google.com/?q=" +
            ponto.latitude + "," + ponto.longitude + "'>Visualizar local</a>",
        size: 'large',
    });
}