// <copyright file="GroupRepository.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using Microsoft.EntityFrameworkCore; 
using ProfileLocation.Data.EF.Contexts; 
using ProfileLocation.Domain.ORM.Models; 
using ProfileLocation.Domain.ORM.Interfaces; 
 
namespace ProfileLocation.Data.EF.Repositories 
{ 
    public class GroupRepository : BaseRepository<Group> 
    { 
        public GroupRepository(ProfileLocationContext context, ILogManager logManager = null) : base(context, x => x.Id , logManager) 
        { 
      
        } 
 
        public override DbSet<Group> EntityDbSet => ProfileLocationContext.Groups; 
    } 
}
