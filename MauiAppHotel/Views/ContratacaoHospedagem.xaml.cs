using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{

    List<Quarto> lista_quartos = new()
    {
        new Quarto {Nome = "Quarto Duplo", ValorAdultos = 200.0, ValorCriancas = 100.0},
        new Quarto {Nome = "Quarto Triplo", ValorAdultos = 250.0, ValorCriancas = 150.0},
        new Quarto {Nome = "Quarto Quadruplo", ValorAdultos = 275.0, ValorCriancas = 150.0},
        new Quarto {Nome = "Suite Master", ValorAdultos = 300.0, ValorCriancas = 175.0}
    };
   
	public ContratacaoHospedagem()
	{
        InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6);
    }
    
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new()
            {
                QtdAdultos = Convert.ToInt32(stp_adultos.Value),
                QtdCriancas = Convert.ToInt32(stp_criancas.Value),
                QuartoEscolhido = (Quarto) pck_quarto.SelectedItem,
                DataCheckin = dtpck_checkin.Date.Value,
                DataCheckout = dtpck_checkout.Date.Value,
            };

            Navigation.PushAsync (new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops!", ex.Message, "OK");
        }
    }
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = e.NewDate?.AddDays(1);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync (new Informacoes());
    }
}