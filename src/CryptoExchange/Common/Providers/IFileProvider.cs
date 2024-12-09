namespace Common.Providers
{
	/// <summary>
	/// Represents a file provider.
	/// </summary>
	public interface IFileProvider
	{
		/// <summary>
		/// Gets all files for a path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		FileInfo[] GetFiles(string path);
	}
}
