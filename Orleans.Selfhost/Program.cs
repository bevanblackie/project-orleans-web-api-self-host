using System;
using Microsoft.Owin.Hosting;

namespace Orleans.Selfhost
{
	class Program
	{
		private static OrleansHostWrapper hostWrapper;
		private const string baseAddress = "http://localhost:9000/";

		static void Main(string[] args)
		{
			AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
			{
				AppDomainInitializer = InitSilo,
				AppDomainInitializerArguments = args,
			});

			// Start OWIN host 
			using (WebApp.Start<Startup>(baseAddress))
			{
				if (!GrainClient.IsInitialized)
				{
					GrainClient.Initialize("ClientConfiguration.xml");
				}

				Console.ReadLine();
			}
			hostDomain.DoCallBack(ShutdownSilo);
		}

		static void InitSilo(string[] args)
		{
			hostWrapper = new OrleansHostWrapper(args);

			if (!hostWrapper.Run())
			{
				Console.Error.WriteLine("Failed to initialize Orleans silo");
			}
		}

		static void ShutdownSilo()
		{
			if (hostWrapper != null)
			{
				hostWrapper.Dispose();
				GC.SuppressFinalize(hostWrapper);
			}
		}
	}
}
