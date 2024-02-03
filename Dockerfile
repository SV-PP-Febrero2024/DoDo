FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

RUN dotnet publish "DoDo.Presentation" -c Release -o /DoDo

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /DoDo
COPY --from=build /src .

EXPOSE 7790
VOLUME /DoDo/DoDo.Data

ENV MACHINE_NAME ${COMPUTERNAME}
ENTRYPOINT ["dotnet", "DoDo.Presentation/bin/Release/net6.0/DoDo.Presentation.dll"]