namespace ContentManager.Packages.Tests;

public class PakEntryTests
{
	[Fact]
	public void Read()
	{
		using var stream = File.OpenRead("Resources/GlobalRU.pak");
		using var reader = new BinaryReader(stream);
		_ = PakHeader.TryRead(reader, out _);

		var entry = PakEntry.Read(reader);

		Assert.Equal("Gfx/Interfaz.txt", entry.Path);
		Assert.Equal(13u, entry.DataStartPosition);
		Assert.Equal(44261u, entry.DataSize);
		Assert.Equal(127846410028233750u, entry.Unknown);
	}
}