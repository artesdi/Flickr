using System.Collections.Generic;
using Flickr.Presentation.Model;

namespace Flickr.DataService
{
	public interface IPictureProvider
	{
		IReadOnlyList<Picture> GetSuperPicture(string tags);
	}
}