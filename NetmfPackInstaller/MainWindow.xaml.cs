using System.Windows;
using System.Windows.Controls;
using CMSIS.Pack;

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

            var viewModel = new PackRepositoryViewModel( );
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
    }
}
