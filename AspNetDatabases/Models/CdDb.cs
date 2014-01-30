using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetDatabases.Models
{
    public class CdDb
    {

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a Title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter an Artist.")]
        public string Artist { get; set; }

        public string RecordLabel { get; set; }

        public int RecordYear { get; set; }
    }
}