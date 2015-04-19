using System.Threading.Tasks;
using System.Web.Http;
using Orleans.Interfaces;

namespace Orleans.Selfhost.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public async Task<string> Get()
		{
			var helloGrain = HelloFactory.GetGrain(0);
			return await helloGrain.SayHello("YOLO");

		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
