using System;
using System.IO;
using Microsoft.Extensions.Configuration.Hjson;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.Configuration
{
	public static class HjsonConfigurationExtensions
	{
		public static IConfigurationBuilder AddHJsonFile(this IConfigurationBuilder builder
			, string path)
		{
			return AddHJsonFile(builder, null, path, false, false);
		}

		public static IConfigurationBuilder AddHJsonFile(this IConfigurationBuilder builder
			, string path, bool optional)
		{
			return AddHJsonFile(builder, null, path, optional, false);
		}

		public static IConfigurationBuilder AddHJsonFile(this IConfigurationBuilder builder
			, string path, bool optional, bool reloadOnChange)
		{
			return AddHJsonFile(builder, null, path, optional, reloadOnChange);
		}

		public static IConfigurationBuilder AddHJsonFile(this IConfigurationBuilder builder
			, IFileProvider provider, string path, bool optional, bool reloadOnChange)
		{
			if (provider == null && Path.IsPathRooted(path))
			{
				provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
				path = Path.GetFileName(path);
			}

			var source = new HjsonConfigurationSource
			{
				FileProvider = provider,
				Path = path,
				Optional = optional,
				ReloadOnChange = reloadOnChange
			};
			builder.Add(source);
			return builder;
		}
	}
}
