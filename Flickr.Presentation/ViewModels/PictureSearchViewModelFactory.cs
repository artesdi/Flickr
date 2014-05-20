using System;
using Flickr.DataService;
using Flickr.Presentation.LoadingStrategies;

namespace Flickr.Presentation.ViewModels
{
	public sealed class PictureSearchViewModelFactory : IPictureSearchViewModelFactory
	{
		private readonly IProviderFactory _providerFactory;

		public PictureSearchViewModelFactory(IProviderFactory providerFactory)
		{
			if (providerFactory == null) throw new ArgumentNullException("providerFactory");

			_providerFactory = providerFactory;
		}

		public IPictureSearchViewModel Create()
		{
			var pictureProvider = _providerFactory.CreatePictureProvider();
			var loadingStrategy = new PictureLoadingStrategy(pictureProvider);

			return new PictureSearchViewModel(loadingStrategy);
		}
	}
}