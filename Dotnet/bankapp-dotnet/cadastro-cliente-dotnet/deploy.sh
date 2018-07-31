#!/bin/sh
cd process
dotnet publish -c Release -o published 
cd ..
plataforma --deploy local