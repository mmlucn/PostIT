using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_Lib.Models
{
    public class OCRResult
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public Image Image { get; set; }

    }
}
