using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Flickr.Presentation.Commands;
using Flickr.Presentation.LoadingStrategies;
using Flickr.Presentation.Model;

namespace Flickr.Presentation.ViewModels
{
	public sealed class PictureSearchViewModel : ViewModel, IPictureSearchViewModel
	{
		private const string InitialSearchTags = "Moscow";
		private string _searchTags;

		private readonly IPictureLoadingStrategy _loadingStrategy;
		private readonly IReadOnlyCollection<IPictureViewModel> _pictures;
		private readonly ObservableCollection<IPictureViewModel> _picturesInternal;
		private readonly ICommand _forceSearchCommand;
		private readonly ICommand _clearSearchCommand;

		public PictureSearchViewModel(IPictureLoadingStrategy loadingStrategy)
		{
			if (loadingStrategy == null) throw new ArgumentNullException("loadingStrategy");

			_loadingStrategy = loadingStrategy;

			_picturesInternal = new ObservableCollection<IPictureViewModel>();
			_pictures = new ReadOnlyObservableCollection<IPictureViewModel>(_picturesInternal);

			_clearSearchCommand = new RelayCommand(ClearchSearchTags);
			_forceSearchCommand = new RelayCommand(Search);
			_searchTags = InitialSearchTags;
			_forceSearchCommand.Execute(null);
		}

		private void ClearchSearchTags()
		{
			SearchTags = string.Empty;
			ForceSearchCommand.Execute(null);
		}

		private async void Search()
		{
			try
			{
				await SearchBy(_searchTags);
			}
			catch (Exception)
			{
				#warning Unhandled execption
			}
		}

		private async Task SearchBy(string tags)
		{
			var pictures = await _loadingStrategy.LoadAsync(tags);
			UpdatePictureCollection(pictures);
		}

		private void UpdatePictureCollection(IEnumerable<Picture> pictures)
		{
			_picturesInternal.Clear();

			foreach (var picture in pictures)
				AddToPicturesInternal(picture);
		}

		private void AddToPicturesInternal(Picture picture)
		{
			_picturesInternal.Add(new PictureViewModel(picture));
		}

		public string SearchTags
		{
			get { return _searchTags; }
			set { SetProperty(ref _searchTags, value); }
		}

		public IEnumerable<IPictureViewModel> Pictures
		{
			get { return _pictures; }
		}

		public ICommand ForceSearchCommand
		{
			get { return _forceSearchCommand; }
		}

		public ICommand ClearSearchCommand
		{
			get { return _clearSearchCommand; }
		}
	}
}