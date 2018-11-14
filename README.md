
# Introduction
# AttachingIT.ToDo
Assignment for AttachingIT org, it just ToDo project built in angular & web api in .Net Core, Client side programming done in Typescript.

# Getting Started
1.  Installation process
    This project is web api, you can host in IIS, or self hosted server.
2.  Software dependencies
    IDE: Visula Studio 2017 Version 15.5.6 <br>
    Framework: .Net Core 2.1 C# https://www.microsoft.com/net/download/dotnet-core/2.1<br>
    Package Manager: Nuget API https://www.nuget.org/api/v2
3.  API references
    https://en.wikipedia.org/wiki/.NET_Core


# Build and Test
    1) Excersize1And2, just simple console application with different approches to solve same problem.
    2) Exercize3 - ToDo project with UI in angular & back end API is in .Net Core. ORM used as EF CORE & data stored in database MDF file.
    
    For building project -
    Make sure you download the code from repo or clone the repo, this project is developed C# .NET Core framework so you need to have .Net core SDK installed on your system
    All the packages used in the project has been downloaded from nuget so your Visual Studio should have package source as https://api.nuget.org/v3/index.json
    Once you open the project in visual studio, just build the project, this will restore the packages from nuget & all projects inside solution will build one by one.
    We have created 3 projects in the solutions.

    1)  WebApiRateLimiter - We have hosted web api, accessed mocked data, & provided limited access to the services.

    2)  WebApiRateLimiter.Demo - Console application to test the web api, this project has dependencies on above project so if you want to run this project you need to select multiple projects to run in solution & add above project while running this project.

    3)  WebApiRateLimiter.Tests - This projects has end to end integration test cases.

# Project Detais
    I have used the .NET technology stack to implement this project, I have build this project with latest framework/versions of the .NET.
    
    I have started with C# .NET Core 2.1 version to implement this web api, keeping in mind code should be easy to scale if we bring more serivces to this project, it should be readable & kept DRY wherever possible.
    
    In the project I have used to AutoMapper library to implement mapping between model to viewmodel & vice versa. this reduced to plenty of code.
