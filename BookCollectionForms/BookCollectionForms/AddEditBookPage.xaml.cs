using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookCollectionForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEditBookPage : ContentPage
	{
		public AddEditBookPage ()
		{
			InitializeComponent ();
		}

	    private async void OnClick_SaveBookBtn(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new CollectionPage());
	    }
    }
}