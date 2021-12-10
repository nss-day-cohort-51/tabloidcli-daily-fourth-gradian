﻿using System;
using System.Collections.Generic;
using System.Text;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.Models
{
   public class Note

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public string Content { get; set; }
        public int CreationDate { get; set; }
        public Post Post { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
