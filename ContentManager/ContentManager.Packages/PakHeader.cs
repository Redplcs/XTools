namespace ContentManager.Packages;

internal struct PakHeader
{
	public Compression Compression;
	public GameVersion Version;
	public uint Unknown;
	public uint EntryCount;

	public static bool TryRead(BinaryReader reader, out PakHeader header)
	{
		header = default;

		if (CheckSignature() == false)
			return false;

		header.Compression = (Compression)reader.ReadByte();
		header.Version = (GameVersion)reader.ReadUInt32();
		header.Unknown = reader.ReadUInt32();
		header.EntryCount = reader.ReadUInt32();

		return true;

		bool CheckSignature()
		{
			Span<byte> uint24 = stackalloc byte[3];
			_ = reader.Read(uint24);
			return uint24[0] == 0x50 && uint24[1] == 0x41 && uint24[2] == 0x4B;
		}
	}
}