namespace System.IO;

public static class BinaryWriterExtensions
{
	public static void WriteNullTerminatedString(this BinaryWriter writer, string value)
	{
		foreach (var character in value)
		{
			writer.Write(character);
		}

		writer.Write('\0');
	}
}