using System.Text;

namespace Common.Tests;

public class BinaryWriterExtensionsTests
{
	private const string Source = "Foo";

	private static BinaryWriter CreateBinaryWriter(out byte[] buffer, Encoding? encoding = null, int capacity = 16)
	{
		encoding ??= Encoding.UTF8;

		buffer = new byte[capacity];
		return new BinaryWriter(output: new MemoryStream(buffer), encoding);
	}

	private static byte[] GetEncodingBytes(string str, Encoding encoding, int capacity)
	{
		var buffer = new byte[capacity];
		encoding.GetBytes(str, buffer);
		return buffer;
	}

	[Fact]
	public void WriteNullTerminatedString_String_WritesSameString()
	{
		var encoding = Encoding.UTF8;
		using var writer = CreateBinaryWriter(out var bytes, encoding);

		writer.WriteNullTerminatedString(Source);

		AssertHelper.StartsWith(bytes, GetEncodingBytes(Source, encoding, Source.Length + 1));
	}
}