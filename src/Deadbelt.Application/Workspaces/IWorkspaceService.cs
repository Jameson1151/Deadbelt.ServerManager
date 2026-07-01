namespace Deadbelt.Application.Workspaces;

public interface IWorkspaceService
{
    Task<CreateWorkspaceResult> CreateWorkspaceAsync(
        CreateWorkspaceRequest request,
        CancellationToken cancellationToken = default);

    Task<OpenWorkspaceResult> OpenWorkspaceAsync(
        OpenWorkspaceRequest request,
        CancellationToken cancellationToken = default);
}