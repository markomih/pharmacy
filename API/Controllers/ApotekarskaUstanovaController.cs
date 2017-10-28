using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class ApotekarskaUstanovaController : ApiController
    {
        public IEnumerable<ApotekarskaUstanova> Get()
        {
            var aps = ServiceProvider.Get<ApotekarskaUstanovaService>().GetAll();
            aps.ForEach(o => { o.ProdajnoMestoList = null; });

            return aps;
        }

        // GET api/bolest/5
        public ApotekarskaUstanova Get(int id)
        {
            var o = ServiceProvider.Get<ApotekarskaUstanovaService>().Get(id);

            if (o == null)
                return null;

            o.ProdajnoMestoList = null;

            return o;
        }

        // POST api/bolest
        public bool Post([FromBody] ApotekarskaUstanova obj)
        {
            try
            {
                ServiceProvider.Get<ApotekarskaUstanovaService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/bolest/5
        public void Put(int id, [FromBody] ApotekarskaUstanova obj)
        {
            ServiceProvider.Get<ApotekarskaUstanovaService>().Update(id, obj);
        }

        // DELETE api/bolest/5
        public void Delete(int id)
        {
            ServiceProvider.Get<ApotekarskaUstanovaService>().Delete(id);
        }
    }
}