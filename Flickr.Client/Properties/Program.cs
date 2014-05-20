using System;
using Castle.Windsor;
using Flickr.Presentation.ViewModels;

namespace Flickr.Client.Properties
{
	public class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			using (var container = new WindsorContainer())
			{
				var bootstrapper = new ClientBootstrapper(container);
				bootstrapper.Bootstrap();

				var app = new FlickrApp(container.Resolve<IPictureSearchViewModelFactory>());
				app.Run();
			}
		} 
	}
}