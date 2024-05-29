namespace Core;

/// <summary>
/// Soft delete interface
/// </summary>
public interface ISoftDelete
{
    /// <summary>
    /// Is deleted flag
    /// </summary>
    public bool IsDeleted { get; set; }
    /// <summary>
    /// Mark obj as deleted
    /// </summary>
    public void SoftDelete();
}