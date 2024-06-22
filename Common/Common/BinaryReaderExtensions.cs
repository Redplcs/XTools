using System.Text;

namespace System.IO;

public static class BinaryReaderExtensions
{
	private static readonly StringBuilder s_nullTerminatedStringBuilder = new();

	public static string ReadNullTerminatedString(this BinaryReader reader)
	{
		s_nullTerminatedStringBuilder.Clear();

		while (true)
		{
			var character = reader.Read();

			if (character is '\0')
				break;

			if (character is -1)
				throw new EndOfStreamException();

			s_nullTerminatedStringBuilder.Append((char)character);
		}

		return s_nullTerminatedStringBuilder.ToString();
	}
}