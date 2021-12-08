using System.Collections.Generic;
using System;

namespace TabloidCLI.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime{ get; set; }

        public Journal()
        {
            CreateDateTime = DateTime.Now;
        }


        //public override string ToString()
        //{
        //    return FullName;
        //}
    }
}