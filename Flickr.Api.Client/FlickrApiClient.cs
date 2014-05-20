using System;
using System.Collections.Generic;
using System.Linq;
using Flickr.Api.Client.Contracts;
using FlickrNet;
using FlickrApi = FlickrNet.Flickr;

namespace Flickr.Api.Client
{
	public class FlickrApiClient : IFlickrApiClient
	{
		private readonly FlickrApi _flickrApi;

		public FlickrApiClient(FlickrApi flickrApi)
		{
			if (flickrApi == null) throw new ArgumentNullException("flickrApi");

			_flickrApi = flickrApi;
		}

		public IEnumerable<Photography> GetPhotoByTags(string tags)
		{
			var searchOption = new PhotoSearchOptions
			{
				Tags = tags
			};

			PhotoCollection photoCollection;
			try
			{
				photoCollection = _flickrApi.PhotosSearch(searchOption);
			}
			catch (Exception)
			{
				#warning Unhanled exception
				return Enumerable.Empty<Photography>();
			}

			return photoCollection
				.Select(CreatePhoto);
		}

		private static Photography CreatePhoto(Photo photo)
		{
			return new Photography
				{
					Title = photo.Title,
					Description = photo.Description,
					Url = photo.Small320Url,
					Width = photo.Small320Width,
					Height = photo.Small320Height,
					UploadDate = photo.DateUploaded
				};
		}
	}
}