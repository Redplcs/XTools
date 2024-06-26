namespace ContentManager.Packages;

public enum Compression : byte
{
	Unknown = 0,
	None = 0x41,
	Deflate = 0x43,
}