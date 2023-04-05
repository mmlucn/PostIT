using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_Lib.Models
{
    public class PostItNote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public string Category { get; set; }
    }
}
