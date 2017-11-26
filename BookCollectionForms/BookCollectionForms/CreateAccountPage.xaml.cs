using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookCollectionForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAccountPage : ContentPage
	{
		public CreateAccountPage ()
		{
			InitializeComponent ();
		}

	    private async void OnClick_CreateAccountBtn(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new WelcomePage());
	    }
    }
}