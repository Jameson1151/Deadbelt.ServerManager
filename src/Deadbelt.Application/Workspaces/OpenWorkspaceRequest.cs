namespace Deadbelt.Application.Workspaces;

public sealed class OpenWorkspaceRequest
{
    public required string FolderPath { get; init; }
}