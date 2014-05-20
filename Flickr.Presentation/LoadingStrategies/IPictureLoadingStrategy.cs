using System.Collections.Generic;
using System.Threading.Tasks;
using Flickr.Presentation.Model;

namespace Flickr.Presentation.LoadingStrategies
{
	public interface IPictureLoadingStrategy
	{
		Task<IReadOnlyList<Picture>> LoadAsync(string tags);
	}
}