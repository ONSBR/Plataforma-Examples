const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve, reject, fork) => {
    var branch = context.event.payload.branch;
    fork(branch, "faz a modificacao de operação");
    console.log("Realizando retificação de operação");
    var operacao = context.dataset.Operacao.collection.first();
    operacao.type = context.event.payload.type;
    operacao.value = context.event.payload.value;
    context.dataset.Operacao.update(operacao);
    resolve();
});