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
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}

	    private async void OnClick_AddBookBtn(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new AddEditBookPage());
	    }
    }
}