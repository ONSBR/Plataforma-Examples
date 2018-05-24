const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve, reject, fork) => {
    console.log("Realizando operação financeira");
    var params = context.event.payload;
    context.dataset.Operacao.insert(params);
    resolve();
});
