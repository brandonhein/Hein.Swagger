powershell Remove-Item './.publish' -Recurse

powershell Remove-Item './src/Swagger/bin' -Recurse
dotnet publish ./src/Swagger/Swagger.csproj -o ./.publish/Hein.Swagger
powershell Compress-Archive -Path './.publish/Hein.Swagger/*' -DestinationPath './.publish/Hein.Swagger.zip'
powershell Remove-Item './.publish/Hein.Swagger' -Recurse
powershell Move-Item -Path ./src/Swagger/bin/Debug/*.nupkg -Destination ./.publish