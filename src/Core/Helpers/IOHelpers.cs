using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ServiceStack;

namespace Genyman.Core.Helpers
{
	public static class IOHelpers
	{
		public static string EnsureFolderExists(this string fileName)
		{
			string path = null;
			try
			{
				var fi = new FileInfo(fileName);
				path = fi.DirectoryName;

				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				return path;
			}
			catch (Exception e)
			{
				Log.Error($"Could not create folder {path}");
				throw;
			}
		}


		internal static List<(string Identifier, string Path)> GetEmbeddedResources(this object caller)
		{
			var result = new List<(string Identifier, string Path)>();

			var assembly = caller.GetType().GetTypeInfo().Assembly;

			var allResources = assembly.GetManifestResourceNames();
			foreach (var resource in allResources)
			{
				var identifier = resource;

				// Genyman.Cli.Templates.


				const string templatesFolderName = "Templates";
				
				var separator = Path.DirectorySeparatorChar.ToString();
				var pathParts = resource.SafeSubstring(resource.IndexOf(templatesFolderName, StringComparison.CurrentCulture) + templatesFolderName.Length + 1).Split('.');
				var path = string.Empty;
				for (var index = 0; index < pathParts.Length; index++)
				{

					var separatorToUse = separator;
					if (index == 0)
						separatorToUse = "";
					
						

					path += $"{separatorToUse}{pathParts[index]}";
					
				}

				path = path.Replace("$" + separator, ".");

				result.Add((identifier, path));
			}

			return result;
		}
	}
}