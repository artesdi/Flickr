using System;
using Flickr.Presentation.Model;

namespace Flickr.Presentation.ViewModels
{
	public sealed class PictureViewModel : ViewModel, IPictureViewModel
	{
		private readonly Picture _picture;

		public PictureViewModel(Picture picture)
		{
			if (picture == null) throw new ArgumentNullException("picture");

			_picture = picture;
		}

		public string Url
		{
			get { return _picture.Url; }
		}

		public string Description
		{
			get { return _picture.Description; }
		}

		public int Width
		{
			get { return _picture.Width; }
		}

		public int Height
		{
			get { return _picture.Height; }
		}

		public DateTime UploadDate
		{
			get { return _picture.UploadDate; }
		}
	}
}