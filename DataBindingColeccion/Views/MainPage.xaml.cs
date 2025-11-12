using DataBindingColeccion.Models;
using Microsoft.Maui.Platform;
namespace DataBindingColeccion.Views; 
public partial class MainPage : ContentPage
{
    private List<OrigenDePaquete> _Origenes; 
    public MainPage() 
    { 
        
        InitializeComponent();
        OrigenDePaquete? origenSeleccionado = null;

        _Origenes = new List<OrigenDePaquete>(); 
        CargarDatos(); OrigenesListView.ItemsSource = _Origenes; 
        if ( _Origenes.Count > 0) 
        { 
            origenSeleccionado = _Origenes[0];
        }

        OrigenesListView.ItemsSource = _Origenes;
        OrigenesListView.SelectedItem = origenSeleccionado;
    }

    
    public void CargarDatos() 
    { 
        _Origenes.Add
            (new OrigenDePaquete 
            {
                Nombre = "nuget.org", 
                Origen = "https://api.nuget.org/vs3/index.json", 
                EstaHabilitado = true,
            });
        
                _Origenes.Add(new OrigenDePaquete 
                { 
                    Nombre = "Microsft Visual Studio Offline Packages", 
                    Origen = "C:\\Program Files (x86)\\Microsoft SDKs\\NugetPackages\"", 
                    EstaHabilitado = false,
                }); 
    }
    private void OnAgregarButtonClicked(object sender, EventArgs e) 
    {
        var origen = new OrigenDePaquete 
        { 
            Nombre = "Origen del paquete", 
            Origen = "URL o ruta del origen del paquete", 
            EstaHabilitado = false,
        };
        _Origenes.Add(origen);
        OrigenesListView.ItemsSource = null; 
        OrigenesListView.ItemsSource = _Origenes; 
        OrigenesListView.SelectedItem = origen; }
    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {

        OrigenDePaquete seleccionado = (OrigenDePaquete)OrigenesListView.SelectedItem; 
        if (seleccionado != null)
        {
            var índice = _Origenes.IndexOf(seleccionado); 
            OrigenDePaquete? nuevoSeleccionado;
            if (_Origenes.Count > 1)
            { 
                //Hay mas de un elemento
                if (índice < _Origenes.Count - 1) 
                { 
                    //El elemento seleccionado no es el último
                    nuevoSeleccionado = _Origenes[índice + 1]; } 
                else 
                { 
                    //El elemento seleccionado es el último
                    nuevoSeleccionado = _Origenes[índice - 1]; }
            } 
            else 
            { 
                //Solo hay un elemento
                nuevoSeleccionado= null; 
            } 
            _Origenes.Remove(seleccionado); 
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _Origenes; 
            OrigenesListView.SelectedItem = nuevoSeleccionado; 
        }
    } 



    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OrigenDePaquete origenSeleccionado =
           (OrigenDePaquete)OrigenesListView.SelectedItem;

        if (origenSeleccionado != null)
        {
            NombreEntry.Text = origenSeleccionado.Nombre;
            OrigenEnty.Text = origenSeleccionado.Origen;

        }
        else
        {
            NombreEntry.Text = String.Empty;
            OrigenEnty.Text = String.Empty;
        }

    }

    private void OnActualizarButton_Clicked(object sender, EventArgs e)
    {
        OrigenDePaquete ? origenSeleccionado=
            OrigenesListView.SelectedItem as OrigenDePaquete;
        if(origenSeleccionado != null)
        {
            origenSeleccionado.Nombre=NombreEntry.Text;
            origenSeleccionado.Origen= OrigenEnty.Text;
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _Origenes;
            OrigenesListView.SelectedItem = origenSeleccionado;
        }
    }
}





