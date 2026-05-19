using Syncfusion.Windows.Shared;

namespace iAthena {
    public partial class MainWindow : ChromelessWindow {
        public MainWindow() {
            InitializeComponent();
            DataContext = App.myMainWVM;
        }
    }
}
