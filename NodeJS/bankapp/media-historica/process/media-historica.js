const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve) => {
    console.log("versão 1.0")
    var params = context.event.payload;
    var cotacoes = context.dataset.Cotacao.collection.toArray();
    var mediaHistoricas = context.dataset.MediaHistorica.collection.toArray();
    var hashmap = {}
    var hashMedias = {}
    if (mediaHistoricas.length > 0) {
        mediaHistoricas.forEach(m => {
            hashMedias[m.tipo] = m
        })
    }
    cotacoes.forEach(cotacao => {
        if (!hashmap[cotacao.tipo]){
            hashmap[cotacao.tipo] = []
        }
        hashmap[cotacao.tipo].push(cotacao)
    });

    Object.keys(hashmap).forEach(tipo => {
        if (!hashMedias[tipo]){
            var novaMedia = {
                ano:params.ano,
                mes:params.mes,
                empresa:params.empresa,
                tipo:tipo,
                media: calculaMedia(hashmap[tipo])
            }
            context.dataset.MediaHistorica.insert(novaMedia)
        }else{
            var media = hashMedias[tipo]
            media.media = calculaMedia(hashmap[tipo])
            context.dataset.MediaHistorica.update(media)
        }
    })
    resolve();
});


function calculaMedia(listaCotacoes) {
    var total = 0;
    listaCotacoes.forEach(cotacao => {
        total += cotacao.valor
    })
    return total / listaCotacoes.length
}