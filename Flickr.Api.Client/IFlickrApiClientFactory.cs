namespace Flickr.Api.Client
{
	public interface IFlickrApiClientFactory
	{
		IFlickrApiClient Create();
	}
}