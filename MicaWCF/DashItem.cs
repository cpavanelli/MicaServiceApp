﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicaWCF
{
    public class DashItem
    {
        public string Nome { get; set; }
        public Nullable<DateTime> Registrado { get; set; }
        public Nullable<DateTime> Quando { get; set; }
        public string Dia { get; set; }
        public int ID { get; set; }
        public bool IsRestaurante { get; set; }
        public bool IsEvento { get; set; }


    }
}