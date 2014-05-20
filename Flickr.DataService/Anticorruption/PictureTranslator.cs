using Flickr.Api.Client.Contracts;
using Flickr.Presentation.Model;

namespace Flickr.DataService.Anticorruption
{
	public sealed class PictureTranslator : IPictureTranslator
	{
		public Picture FromExternalContext(Photography photo)
		{
			return new Picture(
				photo.Url,
				photo.Description,
				photo.Width,
				photo.Height,
				photo.UploadDate);
		}
	}
}