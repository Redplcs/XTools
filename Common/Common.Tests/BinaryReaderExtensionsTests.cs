using System.Text;

// ReSharper disable ConvertToLocalFunction

namespace Common.Tests;

public class BinaryReaderExtensionsTests
{
	private const string Source = "Foo";

	private static BinaryReader CreateBinaryReaderFromString(string value, int? capacity = null, Encoding? encoding = null)
	{
		capacity ??= value.Length + 1;
		encoding ??= Encoding.UTF8;

		var bytes = new byte[capacity.Value];

		encoding.GetBytes(chars: value.AsSpan(), bytes.AsSpan());

		return new BinaryReader(input: new MemoryStream(bytes), encoding);
	}

	[Fact]
	public void ReadNullTerminatedString_EndsWithEOF_ThrowsEndOfStreamException()
	{
		using var reader = CreateBinaryReaderFromString(Source, capacity: Source.Length);

		Action actual = () => reader.ReadNullTerminatedString();

		Assert.Throws<EndOfStreamException>(actual);
	}

	[Fact]
	public void ReadNullTerminatedString_String_ReturnsSameString()
	{
		using var reader = CreateBinaryReaderFromString(Source);

		var actual = reader.ReadNullTerminatedString();

		Assert.Equal(Source, actual);
	}

	[Fact]
	public void ReadNullTerminatedString_StringWithBiggerCapacity_ReturnsSameString()
	{
		const int defaultCapacity = 16;
		using var reader = CreateBinaryReaderFromString(Source, defaultCapacity);

		var actual = reader.ReadNullTerminatedString();

		Assert.Equal(Source, actual);
	}
}