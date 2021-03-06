// <copyright file="EFDesignTimeServices.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using Humanizer; //needs Humanizer.Core 2.2.0 NuGet package
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace ProfileLocation.Data.EF
{
    public class EFDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddSingleton<IPluralizer, MyPluralizer>();
        }
    }

    public class MyPluralizer : IPluralizer
    {
        //used for naming tables
        public string Pluralize(string name) => name?.Pluralize(false) ?? name;
        //used for naming entities
        public string Singularize(string name) => name?.Singularize(false) ?? name;
    }
}