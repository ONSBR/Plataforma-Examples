const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve) => {
    var params = context.event.payload;
    var cotacao = context.dataset.Cotacao.collection.first();
    Object.keys(params).forEach(attr => {
        cotacao[attr] = params[attr];
    })
    context.dataset.Cotacao.update(cotacao);
    resolve();
});
