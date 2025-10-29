namespace DataBinding.XamlElement
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnteredTextLabel.Text=TextEntry.Text;
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }

}
