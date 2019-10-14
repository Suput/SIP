FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine3.9
WORKDIR /app
COPY ProjectSIP/project-sip-build .
ENTRYPOINT ["dotnet", "projectSIP.dll"]
