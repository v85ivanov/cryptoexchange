namespace Common.Providers
{
	internal class PhysicalFileProvider : IFileProvider
	{
		/// <inheritdoc />
		public FileInfo[] GetFiles(string path)
		{
			var info = new DirectoryInfo(path);
			return info.GetFiles();
		}
	}
}
