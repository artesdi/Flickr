using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Flickr.Api.Client;
using Flickr.DataService;
using Flickr.DataService.Anticorruption;

namespace Flickr.Bootstrapping
{
	public sealed class DataServiceBootstrapper : IBootstrapper
	{
		private readonly WindsorContainer _container;

		public DataServiceBootstrapper(WindsorContainer container)
		{
			if (container == null) throw new ArgumentNullException("container");
			_container = container;
		}

		public void Bootstrap()
		{
			RegisterPictureTranslator(_container);
			RegisterProviderFactory(_container);
		}

		private void RegisterPictureTranslator(WindsorContainer container)
		{
			container.Register(Component.For<IPictureTranslator>().ImplementedBy<PictureTranslator>()
				.LifestyleSingleton());
		}

		private void RegisterProviderFactory(WindsorContainer container)
		{
			container.Register(Component.For<IFlickrApiClientFactory>().ImplementedBy<FlickrApiClientFactory>()
				.LifestyleSingleton());
			container.Register(Component.For<IProviderFactory>().ImplementedBy<ProviderFactory>()
				.LifestyleSingleton());
		}
	}
}