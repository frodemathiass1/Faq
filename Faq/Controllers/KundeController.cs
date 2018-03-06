using Faq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Faq.Controllers
{
    public class KundeController : ApiController
    {
        DB db = new DB();

        // POST api/Kunde
        [HttpPost]
        public List<Kunde> Post(Kunde kundeInn)
        {
            if (ModelState.IsValid)
            {
                db.lagreNyttSporsmal(kundeInn);
                var alleKundeHendvendelser = db.alleNyeSporsmal();
                return alleKundeHendvendelser;
            }
            return null;

        }

        // GET api/Kunde
        public List<Kunde> Get()
        {
            var alleNyeSporsmal = db.alleNyeSporsmal().ToList();
            return alleNyeSporsmal;
        }

    }
}
