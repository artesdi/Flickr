using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Flickr.Presentation.ViewModels
{
	public class ViewModel : Notifier, IViewModel
	{
		private bool _isBusy;
		
		public bool IsBusy
		{
			get
			{
				return _isBusy;
			}
			protected set
			{
				if (_isBusy) return;

				_isBusy = value;
				RaisePropertyChanged();
			}
		}

		protected bool SetProperty<T>(
			ref T targetPropertyValue,
			T newValue,
			string propertyName = null,
			[CallerMemberName] string callerName = null)
		{
			if (EqualityComparer<T>.Default.Equals(targetPropertyValue, newValue))
				return false;

			targetPropertyValue = newValue;
			RaisePropertyChanged(propertyName ?? callerName);

			return true;
		}
	}
}