using System;

namespace Flickr.Api.Client.Contracts
{
	public class Photography
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public int? Width { get; set; }
		public int? Height { get; set; }
		public DateTime UploadDate { get; set; }
	}
}