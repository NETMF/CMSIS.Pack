using System.Windows.Input;
using CMSIS.Pack;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight.CommandWpf;

namespace NetmfPackInstaller
{
    public enum LoadState
    {
        LoadingIndex,
        ParsingDescriptions,
        Ready,
    }

    public class PackRepositoryViewModel 
        : ViewModelBase
    {
        public PackRepositoryViewModel( IRepository repository )
        {
            Repository = repository;
            State = LoadState.LoadingIndex;
            Packs = new ObservableCollection<PackReferenceViewModel>( );
            RefreshIndexCommand = new RelayCommand( RefreshIndexAsync, CanRefreshIndex );
        }

        internal async Task LoadAsync( )
        {
            await Repository.LoadFromLocalAsync( );

            State = LoadState.ParsingDescriptions;
            foreach( var pack in Repository.Packs )
            {
                var packVm = new PackReferenceViewModel( pack );
                await packVm.LoadAndParseDescriptionAsync( );
                Packs.Add( packVm );
            }

            State = LoadState.Ready;
        }

        public ICommand RefreshIndexCommand { get; }

        public DateTime LastUpdated => Repository.LastUpdatedTimeUTC.ToLocalTime( );

        public ObservableCollection<PackReferenceViewModel> Packs { get; }

        public LoadState State
        {
            get { return State__; }
            private set
            {
                State__ = value;
                RaisePropertyChanged( );
            }
        }
        private LoadState State__;

        private bool CanRefreshIndex( ) => State == LoadState.Ready;

        private async void RefreshIndexAsync( )
        {
            await Repository.UpdateLocalFromSourceAsync( );
        }

        private readonly IRepository Repository;
        private readonly Dispatcher Dispatcher = Dispatcher.CurrentDispatcher;
    }
}
