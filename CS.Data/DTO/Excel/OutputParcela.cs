﻿using System;
namespace CS.Data.DTO.Excel
{
    public class OutputParcela:Output
    {
        public int Index
        {
            get;
            set;
        }
        public string Tarla
        {
            get;
            set;
        }
        public string Parcela
        {
            get;
            set;
        }
        public string CatFol
        {
            get;
            set;
        }
        public int Suprafata
        {
            get;
            set;
        }
    }
}