using System.Windows;

namespace Main.Views
{
    /// <summary>
    /// Interaction logic for ProjectEditWindow.xaml
    /// </summary>
    public partial class ProjectEditWindow : Window
    {
        public ProjectEditWindow()
        {
            InitializeComponent();
        }
        private void Button_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("何で押したん？");
        }
    }
}
