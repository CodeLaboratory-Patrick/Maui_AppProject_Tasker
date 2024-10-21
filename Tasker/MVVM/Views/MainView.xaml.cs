using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}