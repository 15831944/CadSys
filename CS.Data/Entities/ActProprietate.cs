﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Data.Entities
{
    public class ActProprietate:BaseEntity
    {


        [ForeignKey("TipActProprietate")]
        public int? TipActProprietateId { get; set; }

        public virtual TipActProprietate TipActProprietate { get; set; }

        public string Numar
        {
            get;
            set;
        }

        public DateTime? Data
        {
            get;
            set;
        }

        public string Emitent
        {
            get;
            set;
        }

        public decimal Suprafata
        {
            get;
            set;
        }

        public string Carnet
        {
            get;
            set;
        }

        [InverseProperty("ActProprietate")]
        public virtual ICollection<InscriereAct> Inscrieri { get; set; } = new HashSet<InscriereAct>();

    }
}
