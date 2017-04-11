using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameLogger.Models
{
    public class Character
    {
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public int CharacterID { get; set; }
        [Display (Name = "Charater Name")]
        public string CharacterName { get; set; }
    }
}