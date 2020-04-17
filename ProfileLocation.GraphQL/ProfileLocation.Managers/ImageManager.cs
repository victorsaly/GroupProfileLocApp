// <copyright file="ImageManager.cs" company="Victor Saly Ltd">
// Copyright (c) Victor Saly Ltd. All rights reserved.
// </copyright>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using OpenGraphNet;
using ProfileLocation.Domain.Managers.Output;
using ProfileLocation.Domain.ORM.Attributes;

namespace ProfileLocation.Managers
{
    /// <summary>
    /// OpenGraph Manager to retrive data from website.
    /// </summary>
    public class ImageManager : IImageManager
    {
        /// <inheritdoc/>
        [QLQuery]
        public ImageOutput GetCroppedImage(string imageBase64, int width, int height, bool needToFill)
        {
            if (!string.IsNullOrEmpty(imageBase64) && imageBase64.Contains("data:image"))
            {
                imageBase64 = Regex.Match(imageBase64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            }

            var image = Base64ToImage(imageBase64);
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = width / (double)sourceWidth;
            nScaleH = (double)height / (double)sourceHeight;
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (height - (sourceHeight * nScale)) / 2;
                destX = (width - (sourceWidth * nScale)) / 2;
            }

            if (nScale > 1)
            {
                nScale = 1;
            }

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);

            Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    string.Format(
                        "destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                        destWidth,
                        destX,
                        destHeight,
                        destY,
                        width,
                        height), ex);
            }

            using (Graphics grPhoto = Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;
                Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                grPhoto.DrawImage(image, to, from, GraphicsUnit.Pixel);

                return new ImageOutput()
                {
                    ImageBase64 = Convert.ToBase64String(ImageToByteArray(bmPhoto)),
                };
            }
        }

        /// <summary>
        /// Convert image into byte array.
        /// </summary>
        /// <param name="imageIn">Image obj.</param>
        /// <returns>byte array.</returns>
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        /// <inheritdoc/>
        [QLQuery]
        public ImageOutput GetOpenGraph(string url)
        {
            var result = OpenGraph.ParseUrl(url);

            return new ImageOutput()
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

        /// <summary>
        /// Convert string base64 to image.
        /// </summary>
        /// <param name="base64String">string base image.</param>
        /// <returns>Image object.</returns>
        private Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}
