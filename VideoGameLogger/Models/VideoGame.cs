using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameLogger.Models
{
    public class VideoGame
    {
        public int VideoGameID { get; set; }
        [Required]
        [Display (Name = "Name of Fighting Game")]
        public string NameOfFightingGame { get; set; }
        [Display(Name = "Won?")]
        public bool WinOrLose { get; set; }
        [Display(Name = "Number of Rounds")]
        public int NumberOfRounds { get; set; }

        [Display(Name = "Charater Name")]
        public int CharacterID { get; set; }
        public virtual Character NameOfCharacter { get; set; }

        [Display(Name = "How Long in Minutes")]
        public TimeSpan HowLongMinutes { get; set; }
        [Display(Name = "Record Time in Minutes")]
        public TimeSpan RecordTimeMinutes { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
    }
}