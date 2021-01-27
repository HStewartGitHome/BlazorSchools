Blazor Schools .Net 5.0 Upgrade

Stewart Hyde

Introduction
============

This document describes the steps and findings that I found when upgrading the
project to .NET 5.0.

[Migrate from ASP.NET Core 3.1 to 5.0 \| Microsoft
Docs](https://docs.microsoft.com/en-us/aspnet/core/migration/31-to-50?view=aspnetcore-5.0&tabs=visual-studio)

I did try as instructed in above document, but I found doing this manually based
on the steps, but I had problems with the Blazor application. Thinking outside
of box, I came up with an idea that would make this both more reliable and
simpler. This is basically use Microsoft Visual Studio template application to
recreate the application for .Net 5 and move dedicated content in.

Steps
=====

The following are the steps I took to handle upgrading to .Net 5.0.

-   Using latest Visual Studio 2019 Blazor template create a similar Web
    Assembly application with same name and details but using .Net 5.0.

-   Move specific 3.1 BlazorSchools changes into new 5.0 project and make it
    functional (removing default views and adjusting NavMenu…)

-   Added SchoolVirtual view using new Virtualization and link to NavMenu

-   Remove BlazorSchools subproject from original 3.1 project but keeping other
    projects.

-    In other projects update manifests based on doc to 5.0

-   Update Nuget projects to 5.0 and remove non compatible or obsolete ones

-   Run dotnet nuget locals –-clear all
