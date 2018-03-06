using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Faq.Models;

namespace Faq.Models
{
    public class DBInit : DropCreateDatabaseAlways<Context>
    {

        protected override void Seed(Context context)
        {

            List<KundeDb> innKunde = new List<KundeDb>();
            var kunde1 = new KundeDb { KId = 001, Fornavn = "Ola", Etternavn="Mannus",Epost="ola@mannus.no",Sporsmalet="Kan man ha med kniv ombord?",Kategori="Annet" };
            var kunde2 = new KundeDb { KId = 003, Fornavn = "Petter", Etternavn="Petrus", Epost="petter@petrus.no",Sporsmalet="Kan man fly med propp i øret?",Kategori="Annet",Svaret="Det burde du absolutt ikke gjøre!" };
            var kunde3 = new KundeDb { KId = 004, Fornavn = "Elin", Etternavn = "Hurrah", Epost="elin@hurrah.no",Sporsmalet="Hvordan kan man få midlertidig pass?",Kategori="Annet" };
            innKunde.Add(kunde1);
            innKunde.Add(kunde2);
            innKunde.Add(kunde3);

            foreach (KundeDb k in innKunde)
            {
                context.Kunder.Add(k);
            }
            base.Seed(context);


            List<Sporsmal> innSpm = new List<Sporsmal>
            {
                new Sporsmal {
                    Sporsmalet ="Hvordan kan jeg sjekke status på min reise?",
                    Svaret ="For å se status på en en reise, gå til 'Sjekk status på flyvning' , og tast inn ditt rute nummer (Eks OSLKRS005)" +
                            " for informasjon og status om reisen.",
                    Kategori="Bestilling"
                    
                },
                new Sporsmal {
                    Sporsmalet = "Hvordan kan jeg avbestille min reise?",
                    Svaret="For å avbestille en reise, har du 2 alternativer.Du kan enkelt administrere din reise ved logge inn på din " +
                            "bruker konto, og velge 'avbestill reise'. Eller du kan ringe kundeservice på 22334455, " +
                            "og vi vil hjelpe deg. Refusjon vil kun bli gitt hvor det foreligger avbestillingsforsikring.",
                     Kategori="Bestilling"
                },
                new Sporsmal {
                    Sporsmalet = "Hvordan kan jeg endre min bestilling?",
                    Svaret ="For å endre en reise, har du 2 alternativer.Du kan enkelt administrere din reise ved logge inn på din " +
                            "bruker konto, og velge 'endre reise'. Eller du kan ringe kundeservice på 22334455, og vi vil hjelpe deg.Endringer er gratis " +
                            "der det foreligger endringsforskring, ellers vil tilkomme et endringsgebyr på 500NOK.",
                     Kategori="Bestilling"
                },
                new Sporsmal {
                    Sporsmalet = "Hvor mye koster ekstra bagasje?",
                    Svaret="Du kan ha med deg 1 håndbagasje(max 10kg, 55x40x23cm) og 1 innsjekket bagasje(max 20kg) uten ekstra kostnader." +
                            "Ytterligere bagasje koster 250kr pr kolli inntil 20kg.Se egn prisliste for spesialbagasje som sportsutstyr, musikkintrumenter etc.",
                     Kategori="Bagasje"
                },
                new Sporsmal {
                    Sporsmalet = "Hvordan kan jeg bestille ekstra bagasje?",
                    Svaret="Du kan ha med deg 1 håndbagasje(max 10kg, 55x40x23cm) og 1 innsjekket bagasje(max 20kg) uten ekstra kostnader." +
                            "Ytterligere bagasje koster 250kr pr kolli inntil 20kg.Se egn prisliste for spesialbagasje som sportsutstyr, musikkintrumenter etc.",
                     Kategori="Bagasje"
                },
                new Sporsmal {
                    Sporsmalet = "Hvordan reiser jeg med spesialbagasje som sportsutstyr, eller instrument?",
                    Svaret = "For å bestille ekstra bagasje en reise, har du 2 alternativer.Du kan enkelt bestille bagasje ved å logge inn " +
                            "bruker konto, og velge 'bestill bagasje'. Eller du kan ringe kundeservice på 22334455, og vi vil hjelpe deg.",
                     Kategori="Bagasje"
                },
                new Sporsmal {
                    Sporsmalet = "Hva er maksimalt mål og vekt på håndbagasje?",
                    Svaret="Maksimal vekt og dimensjoner for håndbagasje som er med ombord må være innen 10kg, og 55x40x23cm.",
                     Kategori="Bagasje"
                },
                new Sporsmal {
                    Sporsmalet = "Hva er maksimalt mål og vekt på innsjekket bagasje?",
                    Svaret= "Du kan sjekke inn så mange kolli du vil.Du betaler pr ekstra enhet, og de kan maksimalt være på 20kg.Se egne priselister for spesialbagasje.",
                     Kategori="Bagasje"
                },
                new Sporsmal {
                    Sporsmalet = "Kan jeg fly mens jeg er høygravid?",
                    Svaret= "Du kan fly med oss helt inntil 4 uker før termin, uten legeerklæring. For at du skal være trygg, " +
                        "så er det viktig at en evt legeerklæring foreligger, slik at vi kan hjelpe deg hvis vannet går og kabinen blir transformert til en fødestue....",
                     Kategori="Spesielle behov"
                },
                new Sporsmal {
                    Sporsmalet = "Kan jeg ha med egen rullestol?",
                    Svaret="Handicappede kan ha med inntil 2 rullestoler uten kostnader.",
                    Kategori="Spesielle behov"
                },
                new Sporsmal {
                    Sporsmalet = "Kan jeg få medisinsk assistanse om bord?",
                    Svaret="Du kan bestille medisink assistanse om bord ved å logge inn på din brukerkonto og velge 'bestill " +
                                 "medisink assistanse'. Eller du kan snakke med kundeservice og vi vil hjelpe deg.?",
                    Kategori="Spesielle behov"
                }
            };


            foreach (Sporsmal spm in innSpm)
            {
                context.Sporsmaler.Add(spm);
            }
            base.Seed(context);

        }
    } 
}