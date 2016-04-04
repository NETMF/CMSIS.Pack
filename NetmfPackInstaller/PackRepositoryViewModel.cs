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
        public PackRepositoryViewModel()
        {
            // for now, just hard code location of local repository
            // and use the default cloud URL
            Repository = new PackRepository(@"c:\Keil_v5\ARM\Pack");
            State = LoadState.LoadingIndex;
            Packs = new ObservableCollection<PackReferenceViewModel>( );
            RefreshIndexCommand_ = new RelayCommand( RefreshIndexAsync, CanRefreshIndex );
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

        public ICommand RefreshIndexCommand
        {
            get { return RefreshIndexCommand_; }
        }
        private readonly RelayCommand RefreshIndexCommand_;

        public DateTime LastUpdated { get { return Repository.LastUpdatedTimeUTC.ToLocalTime(); } }

        public ObservableCollection<PackReferenceViewModel> Packs { get; private set; }

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

        private bool CanRefreshIndex( )
        {
            return State == LoadState.Ready;
        }

        private async void RefreshIndexAsync( )
        {
            await Repository.UpdateLocalFromSourceAsync( );
        }

        private readonly PackRepository Repository;
        private readonly Dispatcher Dispatcher = Dispatcher.CurrentDispatcher;
    }
}
