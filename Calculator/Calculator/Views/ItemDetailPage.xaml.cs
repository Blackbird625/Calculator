using Calculator.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Calculator.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}