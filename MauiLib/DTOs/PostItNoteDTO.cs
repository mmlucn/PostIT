﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = MauiLib.Models.Image;

namespace MauiLib.DTOs
{
    public class PostItNoteDTO
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public string? Category { get; set; } = null;
        public ImageDTO? Image { get; set; } = null;
    }
}
