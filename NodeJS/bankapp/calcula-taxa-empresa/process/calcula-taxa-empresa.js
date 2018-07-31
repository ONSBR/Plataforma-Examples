const SDK = require("plataforma-sdk/worker/sdk")

function calculaTaxaAAA(mediasAAA) {
    var valor = mediasAAA.map(m => m.media).reduce((acc,curr) => acc + curr,0)
    return (valor/mediasAAA.length) * 1.345
}

function calculaTaxaAA(mediasAA) {
    var valor = mediasAA.map(m => m.media).reduce((acc,curr) => acc + curr,0)
    return (valor/mediasAA.length) * 0.045
}

function calculaTaxaA(mediasA) {
    var valor = mediasA.map(m => m.media).reduce((acc,curr) => acc + curr,0)
    return (valor/mediasA.length) * 5
}

var strategy = {
    "AAA":calculaTaxaAAA,
    "AA":calculaTaxaAA,
    "A":calculaTaxaA,
}


SDK.run((context, resolve) => {
    var params = context.event.payload;
    var taxas = context.dataset.Taxa.collection.toArray();
    var mediaHistoricas = context.dataset.MediaHistorica.collection.toArray();
    var hashMediasMes = {}
    var exist = false;
    var taxa = {
        ano:params.ano,
        empresa:params.empresa,
    }
    if (taxas.length > 0){
        taxa = taxas[0]
        exist = true;
    }

    mediaHistoricas.forEach(mediaHistorica => {
        if (!hashMediasMes[mediaHistorica.mes]) {
            hashMediasMes[mediaHistorica.mes] = {}
        }
        if(!hashMediasMes[mediaHistorica.mes][mediaHistorica.tipo]) {
            hashMediasMes[mediaHistorica.mes][mediaHistorica.tipo] = []
        }
        hashMediasMes[mediaHistorica.mes][mediaHistorica.tipo].push(mediaHistorica)
    })
    var valores = Object.keys(hashMediasMes).map(mes => {
        var metricas = hashMediasMes[mes]
        var valor = 0;
        Object.keys(metricas).map(tipo => {
            var medias = metricas[tipo]
            valor  += strategy[tipo](medias)
            console.log("tipo: ",tipo," valor: ",valor)
            return valor
        })
        return valor
    })

    var valorFinal = valores.reduce((acc,cur)=> acc + cur,0) / 12
    taxa.valor = valorFinal
    if (exist){
        context.dataset.Taxa.update(taxa)
    }else{
        context.dataset.Taxa.insert(taxa)
    }
    resolve()
})




