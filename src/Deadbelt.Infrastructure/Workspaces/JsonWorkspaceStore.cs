using System.Text.Json;
using Deadbelt.Application.Workspaces;
using Deadbelt.Domain.Workspaces;

namespace Deadbelt.Infrastructure.Workspaces;

public sealed class JsonWorkspaceStore : IWorkspaceStore
{
    private const string WorkspaceFileName = "workspace.json";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public async Task SaveAsync(
        Workspace workspace,
        CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(workspace.Path);

        var workspaceFilePath = Path.Combine(workspace.Path, WorkspaceFileName);

        if (File.Exists(workspaceFilePath))
        {
            throw new InvalidOperationException(
                $"A workspace already exists at '{workspace.Path}'.");
        }

        var metadata = new WorkspaceMetadata
        {
            Name = workspace.Name,
            Description = workspace.Description,
            CreatedUtc = workspace.CreatedUtc,
            Version = workspace.Version
        };

        await using var stream = File.Create(workspaceFilePath);

        await JsonSerializer.SerializeAsync(
            stream,
            metadata,
            JsonOptions,
            cancellationToken);
    }

    public async Task<Workspace?> LoadAsync(
        string folderPath,
        CancellationToken cancellationToken = default)
    {
        var workspaceFilePath = Path.Combine(folderPath, WorkspaceFileName);

        if (!File.Exists(workspaceFilePath))
            return null;

        await using var stream = File.OpenRead(workspaceFilePath);

        var metadata = await JsonSerializer.DeserializeAsync<WorkspaceMetadata>(
            stream,
            JsonOptions,
            cancellationToken);

        if (metadata is null)
            throw new InvalidOperationException("workspace.json could not be read.");

        if (string.IsNullOrWhiteSpace(metadata.Name))
            throw new InvalidOperationException("workspace.json is missing a workspace name.");

        if (string.IsNullOrWhiteSpace(metadata.Version))
            throw new InvalidOperationException("workspace.json is missing a workspace version.");

        return new Workspace(
            metadata.Name,
            folderPath,
            metadata.Description,
            metadata.CreatedUtc,
            metadata.Version);
    }
}
