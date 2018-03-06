using Faq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Faq.Controllers
{
    public class SporsmalController : ApiController
    {
        DB db = new DB();

        public List<Sporsmal> Get()
        {
            var alleSporsmal = db.alleSporsmal().ToList();
            return alleSporsmal;
        }

    }
}
