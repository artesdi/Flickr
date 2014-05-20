using System;
using Castle.Windsor;
using Flickr.Bootstrapping;

namespace Flickr.Client
{
	public class ClientBootstrapper : IBootstrapper
	{
		private readonly WindsorContainer _container;

		public ClientBootstrapper(WindsorContainer container)
		{
			if (container == null) throw new ArgumentNullException("container");

			_container = container;
		}

		public void Bootstrap()
		{
			new DataServiceBootstrapper(_container).Bootstrap();
			new PresentationBootstrapper(_container).Bootstrap();
		}
	}
}