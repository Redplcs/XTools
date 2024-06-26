namespace ContentManager.Packages.Tests;

public class PakHeaderTests
{
	[Fact]
	public void TryRead()
	{
		using var stream = File.OpenRead("Resources/GlobalRU.pak");
		using var reader = new BinaryReader(stream);

		var read = PakHeader.TryRead(reader, out var header);

		Assert.True(read);
		Assert.Equal(Compression.None, header.Compression);
		Assert.Equal(GameVersion.Release, header.Version);
		Assert.Equal(1u, header.Unknown);
		Assert.Equal(326u, header.EntryCount);
	}
}