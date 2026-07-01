using System.Windows;
using Deadbelt.Desktop.ViewModels;
using Deadbelt.Desktop.Views;
using Microsoft.Win32;

namespace Deadbelt.Desktop.Services;

public sealed class WorkspaceDialogService : IWorkspaceDialogService
{
    public WorkspaceDialogResult ShowCreateWorkspaceDialog(Window owner)
    {
        var viewModel = new CreateWorkspaceViewModel();

        var window = new CreateWorkspaceWindow(viewModel)
        {
            Owner = owner
        };

        var result = window.ShowDialog();

        if (result != true)
            return WorkspaceDialogResult.Cancelled();

        return WorkspaceDialogResult.Success(
            viewModel.WorkspaceName,
            viewModel.FolderPath,
            viewModel.Description);
    }

    public string? ShowOpenWorkspaceDialog(Window owner)
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Select Deadbelt Workspace Folder"
        };

        return dialog.ShowDialog(owner) == true
            ? dialog.FolderName
            : null;
    }
}
