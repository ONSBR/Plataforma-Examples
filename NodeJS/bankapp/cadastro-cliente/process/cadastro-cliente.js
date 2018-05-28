const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve, reject, fork, log) => {
    log.info("Cadastrando Novo Cliente");
    var params = context.event.payload;
    params.balance = 0;
    context.dataset.Conta.insert(params);
    log.info("Cliente inserido");
    resolve();
});
