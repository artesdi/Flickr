using System;

namespace Flickr.Presentation.ViewModels
{
	public interface IPictureViewModel
	{
		string Url { get; }
		string Description { get; }
		int Width { get; }
		int Height { get; }
		DateTime UploadDate { get; }
	}
}