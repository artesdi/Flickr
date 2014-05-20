using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Flickr.Presentation.ViewModels;

namespace Flickr.Bootstrapping
{
	public sealed class PresentationBootstrapper : IBootstrapper
	{
		private readonly WindsorContainer _container;

		public PresentationBootstrapper(WindsorContainer container)
		{
			if (container == null) throw new ArgumentNullException("container");
			_container = container;
		}

		public void Bootstrap()
		{
			RegisterPictureSearchFactory(_container);
		}

		private void RegisterPictureSearchFactory(WindsorContainer container)
		{
			container.Register(Component.For<IPictureSearchViewModelFactory>().ImplementedBy<PictureSearchViewModelFactory>()
				.LifestyleSingleton());
		}
	}
}