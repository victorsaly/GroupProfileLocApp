// <copyright file="ProfileLocationMutations.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using System; 
using GraphQL.Types; 
using Microsoft.Extensions.DependencyInjection; 
using ProfileLocation.Data.EF.Contexts; 
using ProfileLocation.WebAPI.Models.GraphQL; 
using ProfileLocation.Data.EF.Entities; 
using ProfileLocation.Domain.ORM.Models;
using ProfileLocation.Domain.ORM.Interfaces; 
using ProfileLocation.WebAPI.Models;
using ProfileLocation.WebAPI.Models.GraphQL.Input;
using Microsoft.AspNetCore.Hosting;

namespace ProfileLocation.WebAPI.Schema.Mutation 
{ 
    public class ProfileLocationMutations : ObjectGraphType 
    {
        public IWebHostEnvironment Environment { get; }

        public ProfileLocationMutations(IWebHostEnvironment environment)
        {
            if (environment.EnvironmentName != "Testing")
            {
                //EnableGroup();
                //EnableLocation();
                //EnableProfile();
                //EnableProfileGroup();
                //EnableSocial();
                //EnableSocialType();

            }
        }

        public void EnableAllMutations()
        {
            EnableGroup();
            EnableLocation();
            EnableProfile();
            EnableProfileGroup();
            EnableSocial();
            EnableSocialType();

        }

        public void EnableGroup()
        {
            Field(typeof(GroupType), 
                "AddOrUpdateGroup", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GroupInputType>>() { Name = "group" }), 
                resolve: context => 
                { 
                    var entity = context.GetArgument<Group>("group"); 
                    var qlUserContext = (QLUserContext) context.UserContext;
                    using (var scope = qlUserContext.ServiceProvider.CreateScope()) 
                    { 
                        var repo = scope.ServiceProvider.GetService<IRepository<Group>>(); 
                        return repo.Save(entity); 
                    } 
                }); 
        }    
        public void EnableLocation()
        {
            Field(typeof(LocationType), 
                "AddOrUpdateLocation", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LocationInputType>>() { Name = "location" }), 
                resolve: context => 
                { 
                    var entity = context.GetArgument<Location>("location"); 
                    var qlUserContext = (QLUserContext) context.UserContext;
                    using (var scope = qlUserContext.ServiceProvider.CreateScope()) 
                    { 
                        var repo = scope.ServiceProvider.GetService<IRepository<Location>>(); 
                        return repo.Save(entity); 
                    } 
                }); 
        }    
        public void EnableProfile()
        {
            Field(typeof(ProfileType), 
                "AddOrUpdateProfile", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProfileInputType>>() { Name = "profile" }), 
                resolve: context => 
                { 
                    var entity = context.GetArgument<Profile>("profile"); 
                    var qlUserContext = (QLUserContext) context.UserContext;
                    using (var scope = qlUserContext.ServiceProvider.CreateScope()) 
                    { 
                        var repo = scope.ServiceProvider.GetService<IRepository<Profile>>(); 
                        return repo.Save(entity); 
                    } 
                }); 
        }    
        public void EnableProfileGroup()
        {
            Field(typeof(ProfileGroupType), 
                "AddOrUpdateProfileGroup", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProfileGroupInputType>>() { Name = "profileGroup" }), 
                resolve: context => 
                { 
                    var entity = context.GetArgument<ProfileGroup>("profileGroup"); 
                    var qlUserContext = (QLUserContext) context.UserContext;
                    using (var scope = qlUserContext.ServiceProvider.CreateScope()) 
                    { 
                        var repo = scope.ServiceProvider.GetService<IRepository<ProfileGroup>>(); 
                        return repo.Save(entity); 
                    } 
                }); 
        }    
        public void EnableSocial()
        {
            Field(typeof(ProfileLocation.WebAPI.Models.GraphQL.SocialType), 
                "AddOrUpdateSocial", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<SocialInputType>>() { Name = "social" }), 
                resolve: context => 
                { 
                    var entity = context.GetArgument<Social>("social"); 
                    var qlUserContext = (QLUserContext) context.UserContext;
                    using (var scope = qlUserContext.ServiceProvider.CreateScope()) 
                    { 
                        var repo = scope.ServiceProvider.GetService<IRepository<Social>>(); 
                        return repo.Save(entity); 
                    } 
                }); 
        }    
        public void EnableSocialType()
        {
            Field(typeof(SocialTypeType), 
                "AddOrUpdateSocialType", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<SocialTypeInputType>>() { Name = "socialType" }), 
                resolve: context => 
                { 
                    var entity = context.GetArgument<ProfileLocation.Domain.ORM.Models.SocialType>("socialType"); 
                    var qlUserContext = (QLUserContext) context.UserContext;
                    using (var scope = qlUserContext.ServiceProvider.CreateScope()) 
                    { 
                        var repo = scope.ServiceProvider.GetService<IRepository<ProfileLocation.Domain.ORM.Models.SocialType>>(); 
                        return repo.Save(entity); 
                    } 
                }); 
        }    

	}
}