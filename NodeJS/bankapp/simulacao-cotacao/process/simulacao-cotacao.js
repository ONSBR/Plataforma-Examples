const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve, reject ,fork) => {
    if (context.event.payload.branch) {
        var branch = context.event.payload.branch;
        fork(branch, "faz a modificacao de operação");
    }
    var cotacoes = context.dataset.Cotacao.collection.toArray();
    cotacoes.forEach(cotacao => {
        if (cotacao.tipo == "AAA") {
            cotacao.tipo = "A"
        }else if (cotacao.tipo === "A") {
            cotacao.valor = cotacao.valor * 10
        }else if (cotacao.tipo === "AA") {
            cotacao.tipo = "AAA"
            cotacao.valor = cotacao.valor * 2
        }
        context.dataset.Cotacao.update(cotacao)
    });
    resolve()
});