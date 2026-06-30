using System.Windows;
using System.Windows.Input;
using Deadbelt.Desktop.MVVM;

namespace Deadbelt.Desktop.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        CreateWorkspaceCommand = new RelayCommand(CreateWorkspace);
        OpenWorkspaceCommand = new RelayCommand(OpenWorkspace);
    }

    public string ApplicationName => "DEADBELT";

    public string ApplicationSubtitle => "Operations Platform";

    public string WorkspaceStatus => "Workspace: None";

    public string WelcomeMessage => "No workspace is currently open.";

    public string StatusMessage => "Ready";

    public ICommand CreateWorkspaceCommand { get; }

    public ICommand OpenWorkspaceCommand { get; }

    private static void CreateWorkspace()
    {
        MessageBox.Show(
            "Create Workspace is not implemented yet.",
            "Deadbelt",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    private static void OpenWorkspace()
    {
        MessageBox.Show(
            "Open Workspace is not implemented yet.",
            "Deadbelt",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}