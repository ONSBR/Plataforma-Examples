const SDK = require("plataforma-sdk/worker/sdk")

SDK.run((context, resolve,reject)=>{
    var branchName = context.event.payload.branch;
    SDK.dropBranch(branchName).then(resolve).catch((e)=>{
        console.log("Falha");
        reject(e)
    });
})