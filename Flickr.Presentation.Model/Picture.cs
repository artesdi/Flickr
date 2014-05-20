using System;

namespace Flickr.Presentation.Model
{
	public class Picture
	{
		private readonly string _url;
		private readonly string _description;
		private readonly int _width;
		private readonly int _height;
		private readonly DateTime _uploadDate;

		public Picture(string url, string description, int? width, int? height, DateTime uploadDate)
		{
			if (string.IsNullOrEmpty(url)) throw new ArgumentException("url should not be empty");

			_url = url;
			_description = description;
			_width = width ?? 0;
			_height = height ?? 0;
			_uploadDate = uploadDate;
		}

		public string Url
		{
			get { return _url; }
		}

		public string Description
		{
			get { return _description; }
		}

		public int Width
		{
			get { return _width; }
		}

		public int Height
		{
			get { return _height; }
		}

		public DateTime UploadDate
		{
			get { return _uploadDate; }
		}
	}
}