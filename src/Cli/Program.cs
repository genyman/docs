using Genyman.Cli.Implementation;
using Genyman.Core;

namespace Genyman.Cli
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			GenymanApplication.Run<Configuration, NewTemplate, Generator>(args);
		}
	}
}