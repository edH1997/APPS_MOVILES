﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarketDemo.Models
{
    internal class Cliente
    {
        public string cedulaCli { get; set; }
        public string nombresCli { get; set; }
        public float totalPagarCre { get; set; }
        public float saldo { get; set; }
        public float debe { get; set; }
    }
}
