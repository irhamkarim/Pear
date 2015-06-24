﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DSLNG.PEAR.Data.Enums;

namespace DSLNG.PEAR.Data.Entities
{
    public class PmsConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Pilar Pilar { get; set; }
        public int Weight { get; set; }
        public ScoringType ScoringType { get; set; }
        public ScoreIndicator ScoreIndicator { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PmsConfigDetails> PmsConfigDetailsList { get; set; }
    }
}
