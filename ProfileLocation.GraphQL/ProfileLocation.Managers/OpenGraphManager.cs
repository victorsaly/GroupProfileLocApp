// <copyright file="OpenGraphManager.cs" company="Victor Saly Ltd">
// Copyright (c) Victor Saly Ltd. All rights reserved.
// </copyright>

using OpenGraphNet;
using ProfileLocation.Domain.Managers.Output;
using ProfileLocation.Domain.ORM.Attributes;

namespace ProfileLocation.Managers
{
    /// <summary>
    /// OpenGraph Manager to retrive data from website.
    /// </summary>
    public class OpenGraphManager : IOpenGraphManager
    {
        /// <inheritdoc/>
        [QLQuery]
        public OpenGraphProfileOutput GetOpenGraph(string url)
        {
            var result = OpenGraph.ParseUrl(url);

            return new OpenGraphProfileOutput()
            {
                Image = result?.Image?.ToString(),
                Title = result?.Title,
            };
        }
    }
}
