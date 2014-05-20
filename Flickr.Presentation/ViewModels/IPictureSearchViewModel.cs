using System.Collections.Generic;
using System.Windows.Input;

namespace Flickr.Presentation.ViewModels
{
	public interface IPictureSearchViewModel
	{
		string SearchTags { get; set; }
		IEnumerable<IPictureViewModel> Pictures { get; }
		
		ICommand ForceSearchCommand { get; }
		ICommand ClearSearchCommand { get; }
	}
}