using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.Models
{
    public class Image
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Base64 image
        /// </summary>
        public string Data { get; set; }

        public byte[] AsBytes
        {
            get
            {
                if (Data == null)
                    return null;
                return Convert.FromBase64String(Data);
            }
        }

        /// <summary>
        /// Constructor that takes <paramref name="bytes"/> as an input
        /// </summary>
        /// <param name="bytes"></param>
        public Image(byte[] bytes)
        {
            Data = Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Constructor that takes <paramref name="base64"/> as an input
        /// </summary>
        /// <param name="base64"></param>
        public Image(string base64)
        {
            Data = base64;
        }

        public Image()
        {

        }
    }
}
