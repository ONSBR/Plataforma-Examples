const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve, reject) => {
    console.log("Realizando consolidação de saldo");
    var params = context.event.payload;
    var operacoes = context.dataset.Operacao.collection.toArray();
    var conta = context.dataset.Conta.collection.first();
    var saldo = 0;
    operacoes.forEach(op => {
        if (op.type === "credit") {
            saldo += op.value;
        } else if (op.type === "debit") {
            saldo -= op.value;
        }
    });
    conta.balance = saldo;
    context.dataset.Conta.update(conta);
    resolve();
});