using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faq.Models
{
    public class DB
    {

        Context db = new Context();

        public List<Sporsmal> alleSporsmal()
        {
            var alleSporsmal = db.Sporsmaler.ToList();
            return alleSporsmal;
        }

        public List<Kunde> alleNyeSporsmal()
        {
            List<Kunde> nyeSporsmal = (from k in db.Kunder
                                     select
                                         new Kunde()
                                         {
                                             KId = k.KId,
                                             Fornavn = k.Fornavn,
                                             Etternavn = k.Etternavn,
                                             Epost = k.Epost,
                                             Sporsmalet = k.Sporsmalet,
                                             Svaret = k.Svaret,
                                             Kategori = k.Kategori
                                         }).ToList();
            return nyeSporsmal;
        }

        public void lagreNyttSporsmal(Kunde kundeInn)
        {
            try
            {
                var nyKunde = new KundeDb
                {
                    Fornavn = kundeInn.Fornavn,
                    Etternavn = kundeInn.Etternavn,
                    Epost = kundeInn.Epost,
                    Sporsmalet = kundeInn.Sporsmalet,
                    Kategori = kundeInn.Kategori
                };
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
            }
            catch (Exception feil)
            {

            }
        }
    }
}