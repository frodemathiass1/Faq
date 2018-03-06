using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Faq.Models
{
    public class Kunde
    {
        public int KId { get; set; }

        [RegularExpression(@"^[a-zæøåA-ZÆØÅ''-'\s]{1,40}$")]
        public string Fornavn { get; set; }

        [RegularExpression(@"^[a-zæøåA-ZÆØÅ''-'\s]{1,40}$")]
        public string Etternavn { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$")]
        public string Epost { get; set; }

        [RegularExpression(@"^[a-zæøåA-ZÆØÅ1-9? ''-'\s]{1,250}$")]
        public string Sporsmalet { get; set; }


        public string Svaret { get; set; }

        public string Kategori { get; set; }
    }
}