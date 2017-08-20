# Build stage
FROM microsoft/aspnetcore-build:2 AS build-env

WORKDIR /app

# Restore

## Calculator.Add.Interface
COPY Api.Calculator/Calculator.Add.Interface/Calculator.Add.Interface.csproj ./Api.Calculator/Calculator.Add.Interface/
RUN dotnet restore Api.Calculator/Calculator.Add.Interface/Calculator.Add.Interface.csproj

## Calculator.Add.Service
COPY Api.Calculator/Calculator.Add.Service/Calculator.Add.Service.csproj ./Api.Calculator/Calculator.Add.Service/
RUN dotnet restore Api.Calculator/Calculator.Add.Service/Calculator.Add.Service.csproj

## Calculator.Add.Test
COPY Api.Calculator/Calculator.Add.Test/Calculator.Add.Test.csproj ./Api.Calculator/Calculator.Add.Test/
RUN dotnet restore Api.Calculator/Calculator.Add.Test/Calculator.Add.Test.csproj

## Calculator.Multiply.Interface
COPY Api.Calculator/Calculator.Multiply.Interface/Calculator.Multiply.Interface.csproj ./Api.Calculator/Calculator.Multiply.Interface/
RUN dotnet restore Api.Calculator/Calculator.Multiply.Interface/Calculator.Multiply.Interface.csproj

## Calculator.Multiply.Service
COPY Api.Calculator/Calculator.Multiply.Service/Calculator.Multiply.Service.csproj ./Api.Calculator/Calculator.Multiply.Service/
RUN dotnet restore Api.Calculator/Calculator.Multiply.Service/Calculator.Multiply.Service.csproj

## Calculator.Multiply.Test
COPY Api.Calculator/Calculator.Multiply.Test/Calculator.Multiply.Test.csproj ./Api.Calculator/Calculator.Multiply.Test/
RUN dotnet restore Api.Calculator/Calculator.Multiply.Test/Calculator.Multiply.Test.csproj

## Calculator
COPY Api.Calculator/Calculator/Calculator.csproj ./Api.Calculator/Calculator/
RUN dotnet restore Api.Calculator/Calculator/Calculator.csproj

# Copy source
COPY . .

# Test
ENV TEAMCITY_PROJECT_NAME=fake
RUN dotnet test Api.Calculator/Calculator.Add.Test/Calculator.Add.Test.csproj
RUN dotnet test Api.Calculator/Calculator.Multiply.Test/Calculator.Multiply.Test.csproj

# Publish
RUN dotnet publish Api.Calculator/Calculator/Calculator.csproj -o /publish

# Runtime stage
FROM microsoft/aspnetcore:2

COPY --from=build-env /publish /publish

WORKDIR /publish

RUN ls -alR

ENTRYPOINT ["dotnet", "Calculator.dll"]
