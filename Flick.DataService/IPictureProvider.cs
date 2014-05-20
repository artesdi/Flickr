using System.Threading.Tasks;
using Flickr.Presentation.Model;

namespace Flick.DataService
{
	public interface IPictureProvider
	{
		Task<Picture> GetSuperPictureAsync();
//		Picture GetSuperPictureAsync();
	}
}