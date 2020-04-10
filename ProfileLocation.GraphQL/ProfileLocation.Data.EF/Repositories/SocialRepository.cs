// <copyright file="SocialRepository.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using Microsoft.EntityFrameworkCore; 
using ProfileLocation.Data.EF.Contexts; 
using ProfileLocation.Domain.ORM.Models; 
using ProfileLocation.Domain.ORM.Interfaces; 
 
namespace ProfileLocation.Data.EF.Repositories 
{ 
    public class SocialRepository : BaseRepository<Social> 
    { 
        public SocialRepository(ProfileLocationContext context, ILogManager logManager = null) : base(context, x => x.Id , logManager) 
        { 
      
        } 
 
        public override DbSet<Social> EntityDbSet => ProfileLocationContext.Socials; 
    } 
}