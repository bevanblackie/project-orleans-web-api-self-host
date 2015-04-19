using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Interfaces
{
	/// <summary>
	/// Orleans grain communication interface IHello
	/// </summary>
	public interface IHello : IGrainWithIntegerKey
	{
		Task<string> SayHello(string greeting);
	}
}
