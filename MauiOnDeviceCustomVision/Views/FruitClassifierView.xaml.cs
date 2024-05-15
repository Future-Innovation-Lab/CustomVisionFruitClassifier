using MauiOnDeviceCustomVision.ViewModels;

namespace MauiOnDeviceCustomVision.Views
{
	public partial class FruitClassifierView : ContentPage
	{
		public FruitClassifierView(FruitClassifierViewModel vm)
		{
			InitializeComponent();

			BindingContext = vm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

		}
	}
}