﻿using DataServices;
using DataServices.Models;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using Windows.UI.Core;
using System.Windows.Input;
using Prism.Commands;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;

namespace ThinkWiseMan.ViewModels
{
    public class FavouritesPageViewModel : ViewModelBase
    {
        SqlDataService SqlDataService;
        public FavouritesPageViewModel(SqlDataService sqlDataService)
        {
            SqlDataService = sqlDataService;
        }
        public ICommand CopySelectedWiseIdea => new DelegateCommand<WiseIdeaPresentModel>((_currentWiseIdea) =>
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_currentWiseIdea.Content);
            sb.AppendLine(_currentWiseIdea.Author);
            dataPackage.SetText(sb.ToString());
            Clipboard.SetContent(dataPackage);

        });

        public ICommand ShareCommand => new DelegateCommand<WiseIdeaPresentModel>((_currentWiseIdea) =>
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();

            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(
                (DataTransferManager sender, DataRequestedEventArgs args) =>
                {
                    DataRequest request = args.Request;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(_currentWiseIdea.Content);
                    sb.AppendLine(_currentWiseIdea.Author);
                    request.Data.SetText(sb.ToString());
                    request.Data.Properties.Title = "Поделиться мудростью";
                }
                    );
            DataTransferManager.ShowShareUI();

        });

        public ICommand DeleteFavorite => new DelegateCommand<WiseIdeaPresentModel>(async (_currentWiseIdea) =>
        {
            await SqlDataService.UpdateFavoritePropery(_currentWiseIdea.Id, false);
            FavoritesIdeas.Remove(_currentWiseIdea);

        });
        private ObservableCollection<WiseIdeaPresentModel> _favoritesIdeas = new ObservableCollection<WiseIdeaPresentModel>();
        public ObservableCollection<WiseIdeaPresentModel> FavoritesIdeas
        {
            get
            {
                return _favoritesIdeas;
            }
            set
            {
                _favoritesIdeas = value;
                OnPropertyChanged("FavoritesIdeas");
            }
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            var list = await SqlDataService.GetFavouritesThoughts();
            foreach (var item in list)
            {
                _favoritesIdeas.Add(item);
            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            base.OnNavigatedTo(e, viewModelState);
        }

    }
}
