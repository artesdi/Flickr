using System.Collections.Generic;
using Flickr.Api.Client.Contracts;

namespace Flickr.Api.Client
{
	public interface IFlickrApiClient
	{
		IEnumerable<Photography> GetPhotoByTags(string tags);
	}
}