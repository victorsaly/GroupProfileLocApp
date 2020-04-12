using System;
using System.Collections.Generic;
using System.Text;
using OpenGraphNet;
using ProfileLocation.Domain.Managers.Output;

namespace ProfileLocation.Managers
{
    /// <summary>
    /// Open Graph Services to retrieve data from OG standards.
    /// </summary>
    public interface IOpenGraphManager
    {
        /// <summary>
        /// Get opengrah data from url.
        /// </summary>
        /// <param name="url">page to be crawl</param>
        /// <returns>OpenGraphData Image Url.</returns>
        OpenGraphProfileOutput GetOpenGraph(string url);
    }
}
