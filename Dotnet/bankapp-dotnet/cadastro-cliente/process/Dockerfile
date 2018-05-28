FROM microsoft/dotnet:2.0.7-sdk-2.1.200-stretch 
WORKDIR /usr/published/cadastra-cliente
COPY . .
RUN dotnet publish -c release -o published
CMD [ "dotnet", "cadastro-cliente.Process/published/Plataforma-SDK.NET.dll" ]