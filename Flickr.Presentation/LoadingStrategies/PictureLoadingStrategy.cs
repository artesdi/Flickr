using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flickr.DataService;
using Flickr.Presentation.Model;

namespace Flickr.Presentation.LoadingStrategies
{
	public sealed class PictureLoadingStrategy : IPictureLoadingStrategy
	{
		private readonly IPictureProvider _provider;

		public PictureLoadingStrategy(IPictureProvider provider)
		{
			if (provider == null) throw new ArgumentNullException("provider");
			_provider = provider;
		}

		public async Task<IReadOnlyList<Picture>> LoadAsync(string tags)
		{
			return await Task.Run(() => _provider.GetSuperPicture(tags));
		}
	}
}