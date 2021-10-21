using EFcoreIDbContextIssue.Data.DB;
using LibraryFromNuget.Data.Models;
using LibraryFromNuget.Interfaces;
using LibraryFromNuget.Services;
using Microsoft.Extensions.DependencyInjection;


// actuall usage is configure it in startup (aspnetcore project)
// shown minimal example
var serviceCollection = new ServiceCollection();
var serviceProvider = serviceCollection
    .AddDbContext<ApplicationDatabaseContext>(/*configuration*/)
    .AddScoped<ISomeService, ServiceThatManageModel>().BuildServiceProvider();

using var scopedProvider = serviceProvider.CreateScope();
var service = scopedProvider.ServiceProvider.GetRequiredService<ISomeService>();

service.SaveSomeManagedModel(new SomeManagedModel() { });

/*
    IDbContext must exist for creating data contracts. when you can promise that your database structure will have some table.
    Also you need contract for IIdentityDbContext<> : IDbContext
    If IDbContext will exsist this sample will works.

    In this example you install some package from nuget on your aspnetcore project.
    Package has service that work with some data and requires database to save info about that models. 
    You cant pass type of your database class to nuget package.
    
    Then you cant create service that works with your db and put it in nuget project.
    
    Why you cant put ApplicationDatabaseContext to NUGET package:
    if ApplicationDatabaseContext  will be in package it will be ApplicationDatabaseContext :DbContext
    then in actuall project where you use package you need to inherit from it, and it will works untill you will need IdentityDbContext.
    
    Cuz when you use IdentityDbContext in your project db class will be AppDbContext : IdentityDbContext, NugetPackageDbModel. 
    You cant use multiple inheritance.


    How to create IDbContext?
    Just copy all methods signatures from DbContext to IDbContext + add properties like change tracker and other;
    made DbContest : IDbContext. Dont need to change anything.

    There not a lot of work. You need just copy/paste and change a bit already exsist code. It wont brake anything.
 
 */