namespace ContentManager.Packages;

internal struct PakEntry
{
	public string? Path;
	public uint DataStartPosition;
	public uint DataSize;
	public ulong Unknown;

	public static PakEntry Read(BinaryReader reader)
	{
		return new PakEntry()
		{
			Path = reader.ReadNullTerminatedString(),
			DataStartPosition = reader.ReadUInt32(),
			DataSize = reader.ReadUInt32(),
			Unknown = reader.ReadUInt64(),
		};
	}
}