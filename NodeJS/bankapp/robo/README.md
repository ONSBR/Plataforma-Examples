Os arquivos operador(linux) e operador.exe(windows) é um pequeno aplicativo para criar cotações testes na plataforma
a entrada do aplicativo é o arquivo entrada.json (que deve sempre ficar no mesmo diretório). Este arquivo contém os parametros
para customizar a execução e a geraão de cotações e cálculos

```json
{
    "tipos":["B"],
    "empresas":["PET01"],
    "anoInicial":2017,
    "maxMes":2,
    "maxDias":1,
    "valores":{
        "A":1,
        "AA":2,
        "AAA":3
    },
    "criarCotacoes":true,
    "calcularMedias":true,
    "calcularTaxas":true
}
```
- O campo "tipos" é a lista de todos os tipos disponíveis para cotações;
- O campo "empresas" é a lista de empresas que serão criadas
- anoInicial é o ano mínimo para a criação das cotações
- maxMes é quantos meses do ano serão criadas cotações
- maxDias são quantos dias do mês que serão criadas cotações
- o campo "valores" é para caso queira criar cotações com valores fixos e por tipo, caso não seja preenchido o tipo da cotação o seu valor será aleatório
- criarCotações, calcularMedias e calcularTaxas são as flags para executar cada rotina do robô


### Requests

Criar uma cotação

```http
PUT /sendevent HTTP/1.1
Host: localhost:8081
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: ccb231b1-4789-5789-57af-4aa55b472068

{
    "name": "push.operacao.request",
    "payload":{
      "empresa": "PET01",
      "valor": 1000,
      "tipo": "A",
      "data": "2017-01-01T12:00:00"
    }
}
```

Retificar uma cotação
```http
PUT /sendevent HTTP/1.1
Host: localhost:8081
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: ee109af4-59f2-950a-e641-dcaf06511c04

{
    "name": "retificacao.cotacao.request",
    "payload":{
      "id":"0445f898-8c7d-4549-88c9-a073cee6c8a0",
      "tipo": "AAA"

    }
}
```

Abrir uma simulação
```http
PUT /sendevent HTTP/1.1
Host: localhost:8081
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: b64a6eb4-9ba3-a440-bb6b-612890941ee5

{
    "name": "simulacao.cotacao.request",
    "payload":{
      "branch": "cenario-1",
      "empresa": "PET01",
      "mes": 1
    }
}
```

Aprovar um reprocessamento (serviço Maestro)

```http
POST /v1.0.0/reprocessing/<id_reprocessamento>/approve HTTP/1.1
Host: localhost:6971
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: fb3dac82-598d-4eb8-4b1a-37a753cac8d9

{
	"user":"<usuario>"
}
```

Calcular média histórica
```http
PUT /sendevent HTTP/1.1
Host: localhost:8081
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: d8b6e051-d21e-d705-fc61-7d368ad969b8

{
    "name": "calcula.media.historica.request",
    "payload":{
      "empresa": "PET01",
      "mes": 1,
      "ano":2017
    }
}
```

Calcular Taxa

```http
PUT /sendevent HTTP/1.1
Host: localhost:8081
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: 30b912e4-ce53-331f-eb53-7cd1be6c398e

{
    "name": "calcula.taxa.empresa.request",
    "payload":{
      "empresa": "PET01",
      "ano":2018
    }
}
```