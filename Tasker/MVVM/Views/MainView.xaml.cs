using PropertyChanged;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

[AddINotifyPropertyChangedInterface]
public partial class MainView : ContentPage
{
	private MainViewModel mainViewModel = new MainViewModel();
	public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        mainViewModel.UpdateData();
    }
}