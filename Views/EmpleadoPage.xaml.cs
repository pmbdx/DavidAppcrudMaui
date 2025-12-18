using DavidAppCrud.ViewModels;

namespace DavidAppCrud.Views;

public partial class EmpleadoPage : ContentPage
{
	public EmpleadoPage(EmpleadoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}