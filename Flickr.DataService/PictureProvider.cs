using System;
using System.Linq;
using System.Collections.Generic;
using Flickr.Api.Client;
using Flickr.Api.Client.Contracts;
using Flickr.DataService.Anticorruption;
using Flickr.Presentation.Model;

namespace Flickr.DataService
{
	public sealed class PictureProvider : IPictureProvider
	{
		private readonly IPictureTranslator _translator;
		private readonly IFlickrApiClient _apiClient;

		public PictureProvider(
			IPictureTranslator translator,
			IFlickrApiClientFactory apiClientFactory)
		{
			if (translator == null) throw new ArgumentNullException("translator");
			if (apiClientFactory == null) throw new ArgumentNullException("apiClientFactory");

			_translator = translator;
			_apiClient = apiClientFactory.Create();
		}

		public IReadOnlyList<Picture> GetSuperPicture(string tags)
		{
			return _apiClient
				.GetPhotoByTags(tags)
				.Select(TranslateToPicture)
				.ToList();
		}

		private Picture TranslateToPicture(Photography photo)
		{
			return _translator.FromExternalContext(photo);
		}
	}
}