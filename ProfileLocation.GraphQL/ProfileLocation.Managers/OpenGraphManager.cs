// <copyright file="OpenGraphManager.cs" company="Victor Saly Ltd">
// Copyright (c) Victor Saly Ltd. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Net;
using System.Text;
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
                ImageBase64 = ConvertImageURLToBase64(result?.Image?.ToString()),
                Title = result?.Title,
            };
        }

        /// <summary>
        /// Convert external image into Base64 embeded image.
        /// </summary>
        /// <param name="url">Image url.</param>
        /// <returns>string base64.</returns>
        private string ConvertImageURLToBase64(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            byte[] byteResult = this.GetImage(url);

            sb.Append(Convert.ToBase64String(byteResult, 0, byteResult.Length));

            return sb.ToString();
        }

        /// <summary>
        /// Get byte information from url.
        /// </summary>
        /// <param name="url">url to be downloaded.</param>
        /// <returns>a byte result of request.</returns>
        private byte[] GetImage(string url)
        {
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)response.ContentLength;
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception)
            {
                buf = null;
            }

            return buf;
        }
    }
}
