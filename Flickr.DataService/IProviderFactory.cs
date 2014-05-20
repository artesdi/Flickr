namespace Flickr.DataService
{
	public interface IProviderFactory
	{
		IPictureProvider CreatePictureProvider();
	}
}