using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.Models
{
    public class PostItNote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Category { get; set; }
        public Image Image { get; set; }
        public User User { get; set; }
    }
}
