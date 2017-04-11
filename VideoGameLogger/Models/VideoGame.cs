﻿using System;
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
        public bool WinOrLose { get; set; }
        public int NumberOfRounds { get; set; }

        public int CharacterID { get; set; }
        public virtual Character NameOfCharacter { get; set; }

        public TimeSpan HowLongMinutes { get; set; }
        public TimeSpan RecordTimeMinutes { get; set; }
    }
}