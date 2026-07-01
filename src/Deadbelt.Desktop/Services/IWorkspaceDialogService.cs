using System.Windows;

namespace Deadbelt.Desktop.Services;

public interface IWorkspaceDialogService
{
    WorkspaceDialogResult ShowCreateWorkspaceDialog(Window owner);

    string? ShowOpenWorkspaceDialog(Window owner);
}
