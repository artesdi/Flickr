using Flickr.Api.Client.Contracts;
using Flickr.Presentation.Model;

namespace Flickr.DataService.Anticorruption
{
	public interface IPictureTranslator
	{
		Picture FromExternalContext(Photography photo);
	}
}