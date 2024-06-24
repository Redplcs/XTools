namespace Common.Tests;

public static class AssertHelper
{
	public static void StartsWith<T>(IEnumerable<T> collection, IEnumerable<T> value)
	{
		// Ensuring that enumerable are not null
		Assert.NotNull(collection);
		Assert.NotNull(value);
		
		// Ensuring that value is not bigger than collection
		Assert.True(collection.Count() > value.Count());

		// Ensuring that collection starts with value
		for (int i = 0; i < value.Count(); i++)
		{
			var collectionItem = collection.ElementAt(i);
			var valueItem = value.ElementAt(i);

			Assert.Equal(collectionItem, valueItem);
		}
	}
}