using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.DTOs
{
    public class ImageDTO
    {
        /// <summary>
        /// Base64
        /// </summary>
        public string Data { get; set; }
        public byte[] AsBytes
        {
            get
            {
                if (Data == null)
                {
                    return null;
                }
                return Convert.FromBase64String(Data);
            }

        }

        public ImageDTO(byte[] bytes)
        {
            Data = Convert.ToBase64String(bytes);
        }
        public ImageDTO()
        {

        }
    }
}
