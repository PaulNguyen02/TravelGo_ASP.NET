# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019

# Set the working directory
WORKDIR /inetpub/wwwroot

# Copy the current directory contents into the container at /inetpub/wwwroot
COPY . .

# Expose port 80
EXPOSE 80

# Start the application
ENTRYPOINT ["C:\\ServiceMonitor.exe", "w3svc"]