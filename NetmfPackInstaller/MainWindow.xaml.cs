using CMSIS.Pack;
using System.Windows;
using System.Windows.Controls;

namespace NetmfPackInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            InitializeComponent( );
        }

        protected override async void OnActivated( System.EventArgs e )
        {
            base.OnActivated( e );
            if( DataContext != null )
                return;

            var viewModel = new PackRepositoryViewModel( RepositoryProvider.Repository );
            DataContext = viewModel;
            await viewModel.LoadAsync( );
        }

        private void ToolBar_Loaded( object sender, RoutedEventArgs e )
        {
            var toolBar = ( ToolBar )sender;
            foreach( FrameworkElement a in toolBar.Items ) 
                ToolBar.SetOverflowMode(a, OverflowMode.Never);

            var overflowGrid = toolBar.Template.FindName( "OverflowGrid", toolBar ) as FrameworkElement;

            if( overflowGrid != null )
                overflowGrid.Visibility = Visibility.Collapsed;
        }

        // For now there is only one provider of repositories for an installed MDK
        // eventually others may be supported if more third party tools start supporting
        // the CMSIS-PACK format.
        private IRepositoryProvider RepositoryProvider = new MDKRepositoryProvider( );
    }
}
