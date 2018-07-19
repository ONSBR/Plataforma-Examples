const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve) => {
    var params = context.event.payload;
    console.log(params);
    context.dataset.Cotacao.insert(params);
    resolve();
});
