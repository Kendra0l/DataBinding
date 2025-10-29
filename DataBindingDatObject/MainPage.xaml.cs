using DataBindingDatObject.Models;

namespace DataBindingDatObject
{
    public partial class MainPage : ContentPage
    {
        private Contador contador;

        public MainPage()
        {
            InitializeComponent();
            contador = new Contador();
            BindingContext = contador;           
        }

        private void OnReiniciarButtonClicked(object sender, EventArgs e)
        {
            contador.Reiniciar();
        }

        private void OnContarButtonClicked(object sender, EventArgs e)
        {
            contador.Contar();
        }
    }

}
