using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse
{
    internal class FagModel
    {
        public string FagNavn { get; set; }

        public PersonModel Lærer { get; set; }
    }
}