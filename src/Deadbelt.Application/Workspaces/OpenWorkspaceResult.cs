using Deadbelt.Domain.Workspaces;

namespace Deadbelt.Application.Workspaces;

public sealed class OpenWorkspaceResult
{
    private OpenWorkspaceResult(
        bool succeeded,
        Workspace? workspace,
        string? errorMessage)
    {
        Succeeded = succeeded;
        Workspace = workspace;
        ErrorMessage = errorMessage;
    }

    public bool Succeeded { get; }

    public Workspace? Workspace { get; }

    public string? ErrorMessage { get; }

    public static OpenWorkspaceResult Success(Workspace workspace)
    {
        return new OpenWorkspaceResult(true, workspace, null);
    }

    public static OpenWorkspaceResult Failure(string errorMessage)
    {
        return new OpenWorkspaceResult(false, null, errorMessage);
    }
}