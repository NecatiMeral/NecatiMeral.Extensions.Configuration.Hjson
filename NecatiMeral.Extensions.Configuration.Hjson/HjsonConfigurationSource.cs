using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration.Json;

namespace Microsoft.Extensions.Configuration.Hjson
{
	class HjsonConfigurationSource : JsonConfigurationSource
	{
		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			FileProvider = FileProvider ?? builder.GetFileProvider();
			return new HjsonConfigurationProvider(this);
		}
	}
}
