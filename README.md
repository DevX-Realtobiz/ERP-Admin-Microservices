# ERP-Admin-Microservices
[![Build status](https://ci.appveyor.com/api/projects/status/v644bifa58x9cuxi?svg=true)](https://ci.appveyor.com/project/Magik3a/erp-admin-microservices)

## Contractors Service
Sample reference containerized application, cross-platform and microservices architecture. 

## Identity Service (IdentityServer4)
This service is a identity provider or STS (Security Token Service) currently implemented with IdentityServer 4 wrapping ASP.NET Identity underneath.

## Infrastrucure (RabbitMQ)
RabbitMQ is a messaging broker - an intermediary for messaging. It gives your applications a common platform to send and receive messages, and your messages a safe place to live until received.

## Software requirements

### Software installation requirements for a Windows dev machine with Visual Studio 2017 and Docker for Windows:

* Docker for Windows with the concrete configuration specified below.
* Visual Studio 2017 (Latest version) with the workloads specified below.


  * Share drives in Docker settings (In order to deploy and debug with Visual Studio 2017)
  * Minimum 4 CPUs
  * Minimum 3 gb RAM
  
 # Run all of the cool stuffs
 Main steps:  

- Git clone https://github.com/Magik3a/ERP-Admin-Microservices
- Run add-firewall-rules-for-sts-auth-thru-docker.ps1 in PowerShell (The script will open ports 5100-5105)
- Open solution ERPAdmin.sln
- Set the VS startup project to the "docker-compose" project 
- Hit F5!
