namespace MauiAppHotel.Views;

public partial class Informacoes : ContentPage
{
    public Informacoes()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Identifica qual botão foi pressionado pelo usuário
        Button botao = (Button)sender;

        // Verifica o texto do botão e identifica qual página será aberta
        if (botao.Text == "Sobre o aplicativo")
        {
            await Navigation.PushAsync(new Sobre());
        }
        else if (botao.Text == "Fale Conosco")
        {
            await Navigation.PushAsync(new FaleConosco());
        }
        else if (botao.Text == "Localização")
        {
            await Navigation.PushAsync(new Localizacao());
        }
        else if (botao.Text == "Política de cancelamento")
        {
            await Navigation.PushAsync(new PoliticaCancelamento());
        }
    }
}