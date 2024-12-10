namespace Common.Providers;

/// <summary>
/// Implementation for <see cref="IFileProvider"/>.
/// </summary>
internal class PhysicalFileProvider : IFileProvider
{
	/// <inheritdoc />
	public FileInfo[] GetFiles(string path)
	{
		var info = new DirectoryInfo(path);
		return info.GetFiles();
	}
}