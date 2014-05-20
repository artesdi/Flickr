using System;
using Flickr.Api.Client;
using Flickr.DataService.Anticorruption;

namespace Flickr.DataService
{
	public sealed class ProviderFactory : IProviderFactory
	{
		private readonly IPictureTranslator _pictureTranslator;
		private readonly IFlickrApiClientFactory _apiClientFactory;

		public ProviderFactory(IPictureTranslator pictureTranslator, IFlickrApiClientFactory apiClientFactory)
		{
			if (pictureTranslator == null) throw new ArgumentNullException("pictureTranslator");
			if (apiClientFactory == null) throw new ArgumentNullException("apiClientFactory");

			_pictureTranslator = pictureTranslator;
			_apiClientFactory = apiClientFactory;
		}

		public IPictureProvider CreatePictureProvider()
		{
			return new PictureProvider(_pictureTranslator, _apiClientFactory);
		}
	}
}