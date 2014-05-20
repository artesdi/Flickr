using System;
using System.Windows;
using Flickr.Presentation.View;
using Flickr.Presentation.ViewModels;

namespace Flickr.Client
{
	public sealed class FlickrApp : Application
	{
		private readonly IPictureSearchViewModelFactory _pictureSearchFactory;

		public FlickrApp(IPictureSearchViewModelFactory pictureSearchFactory)
		{
			if (pictureSearchFactory == null) throw new ArgumentNullException("pictureSearchFactory");

			_pictureSearchFactory = pictureSearchFactory;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var startWindow = new PictureSearchView();
			startWindow.DataContext = _pictureSearchFactory.Create();
			startWindow.Show();
		}
	}
}