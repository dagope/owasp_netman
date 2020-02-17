using System.Web.Http;
using System.Xml;
using Victima.Entities;

namespace Victima.Controllers
{
    public class XmlController : ApiController
    {
        // POST api/xml
        public void Post([FromBody]Order order)
        {
            XmlDocument xmlDoc = new XmlDocument();
            // xmlDoc.XmlResolver = null;
            xmlDoc.LoadXml(order.Content);
        }
    }
}