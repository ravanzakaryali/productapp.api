# Use the official .NET 8 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the solution and project files
COPY productapp.sln ./
COPY src/ ./src/
COPY test/ ./test/

# Restore the dependencies
RUN dotnet restore

# Build the project
RUN dotnet build -c Release -o /app/build

# Publish the project
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET 8 runtime image for the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app/publish .

# Expose port 80 to listen for HTTP traffic
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "ProductApp.API.dll"]
