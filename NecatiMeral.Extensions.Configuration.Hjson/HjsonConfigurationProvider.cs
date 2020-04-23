using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Hjson;
using Microsoft.Extensions.Configuration.Json;

namespace Microsoft.Extensions.Configuration.Hjson
{
	class HjsonConfigurationProvider : JsonConfigurationProvider
	{
		public HjsonConfigurationProvider(HjsonConfigurationSource source)
			: base(source) { }

		public override void Load(Stream stream)
		{
			var jsonString = HjsonValue.Load(stream).ToString();
			var bytes = Encoding.Default.GetBytes(jsonString);
			using (var memStream = new MemoryStream(bytes))
			{
				base.Load(memStream);
			}
		}
	}
}
