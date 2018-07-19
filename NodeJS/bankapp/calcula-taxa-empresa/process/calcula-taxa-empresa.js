const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve) => {
    var params = context.event.payload;
    var taxas = context.dataset.Taxa.collection.toArray();
    var mediaHistoricas = context.dataset.MediaHistorica.collection.toArray();
    var hashEmpresas = {}
    var hashMediasMes = {}
    taxas.forEach(taxa => {
        hashEmpresas[taxa.empresa] = taxa
    });
    mediaHistoricas.forEach(mediaHistorica => {
        if (!hashMediasMes[mediaHistorica.tipo]) {
            hashMediasMes[mediaHistorica.tipo] = {}
        }
        if(!hashMediasMes[mediaHistorica.tipo][mediaHistorica.mes]) {
            hashMediasMes[mediaHistorica.tipo][mediaHistorica.mes] = []
        }
        hashMediasMes[mediaHistorica.tipo][mediaHistorica.mes].push(mediaHistorica)
    })
    console.log(JSON.stringify(hashMediasMes,null,4));
    resolve()
})