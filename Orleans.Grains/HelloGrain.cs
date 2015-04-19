using System.Threading.Tasks;
using Orleans.Interfaces;

namespace Orleans.Grains
{
	/// <summary>
	/// Orleans grain implementation class HelloGrain.
	/// </summary>
	public class HelloGrain : Grain, IHello
	{
		public Task<string> SayHello(string greeting)
		{
			return Task.FromResult("You said: '" + greeting + "', I say: Hello!");
		}
	}
}
