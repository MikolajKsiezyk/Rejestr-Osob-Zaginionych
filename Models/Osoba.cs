using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejOsobZaginionych.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataZaginiecia { get; set; }
        public string Plec { get; set; }
    }
}
