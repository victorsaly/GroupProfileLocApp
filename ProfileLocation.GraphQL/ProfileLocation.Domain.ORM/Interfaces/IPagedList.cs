// <copyright file="IPagedList.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileLocation.Domain.ORM.Interfaces
{
    public interface IPagedList<TObject> where TObject : class
    {
        IList<TObject> Items { get; }

        int TotalCount { get; }
        int CurrentPage { get; }
        int PageCount { get; }
        int PageSize { get; }
    }
}
