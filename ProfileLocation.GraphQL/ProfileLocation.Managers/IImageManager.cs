// <copyright file="IImageManager.cs" company="Victor Saly Ltd">
// Copyright (c) Victor Saly Ltd. All rights reserved.
// </copyright>

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
    public interface IImageManager
    {
        /// <summary>
        /// Get opengrah data from url.
        /// </summary>
        /// <param name="url">page to be crawl.</param>
        /// <returns>Image output model.</returns>
        ImageOutput GetOpenGraph(string url);

        /// <summary>
        /// Get cropped image from string base64.
        /// </summary>
        /// <param name="imageBase64">image string base64.</param>
        /// <param name="width">the with in pixels of the expected size.</param>
        /// <param name="height">the height in pixels of the expected size.</param>
        /// <param name="needToFill">if required to fill the gap by increasing the size.</param>
        /// <returns>Image output model.</returns>
        ImageOutput GetCroppedImage(string imageBase64, int width, int height, bool needToFill);
    }
}
