using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollectionForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private async void OnClick_CreateAccountBtn(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new CreateAccountPage());
        }

	    private async void OnClick_LoginBtn(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new LoginPage());
	    }
    }
}
