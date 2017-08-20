FROM microsoft/dotnet:2-sdk AS build-env
WORKDIR /app

# Restore
COPY Calculator.Integration.csproj .
RUN dotnet restore

# Copy source
COPY . .

ENTRYPOINT ["dotnet", "test"]
