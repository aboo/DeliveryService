using AmazonDeliveryService;
using NFluent;
using Xunit;

namespace AmazonDeliveryServiceTests
{
	public class DeliveryServiceTests
	{
		[Fact]
		public void MinimuDistanceReturnsCorrectValue1()
		{
			// arrange
			const int numberOfColumns = 3;
			const int numberOfRows = 3;
			var area = new[,]
			{
				{1,0,0 },
				{1,0,0 },
				{1,9,0 }
			};
			const int expected = 3;
			var service = new DeliveryService();

			// act
			var actual = service.MinimumDistance(numberOfColumns, numberOfRows, area);

			// assert
			Check.That(actual).Equals(expected);
		}

		[Fact]
		public void MinimuDistanceReturnsCorrectValue2()
		{
			// arrange
			const int numberOfColumns = 3;
			const int numberOfRows = 3;
			var area = new[,]
			{
				{1,1,1 },
				{1,0,1 },
				{1,0,9 }
			};
			const int expected = 4;
			var service = new DeliveryService();

			// act
			var actual = service.MinimumDistance(numberOfColumns, numberOfRows, area);

			// assert
			Check.That(actual).Equals(expected);
		}

		[Fact]
		public void MinimuDistanceReturnsCorrectValue3()
		{
			// arrange
			const int numberOfColumns = 6;
			const int numberOfRows = 6;
			var area = new[,]
			{
				{1,1,1,1,1,1 },
				{1,0,0,0,0,1 },
				{1,0,1,9,1,1 },
				{1,0,1,0,0,1 },
				{1,0,1,0,0,0 },
				{1,1,1,0,0,0 }
			};
			const int expected = 9;
			var service = new DeliveryService();

			// act
			var actual = service.MinimumDistance(numberOfColumns, numberOfRows, area);

			// assert
			Check.That(actual).Equals(expected);
		}

		[Fact]
		public void MinimuDistanceReturnsCorrectValue4()
		{
			// arrange
			const int numberOfColumns = 6;
			const int numberOfRows = 1;
			var area = new[,]
			{
				{1 },
				{1 },
				{1 },
				{1 },
				{1 },
				{9 },
			};
			const int expected = 5;
			var service = new DeliveryService();

			// act
			var actual = service.MinimumDistance(numberOfColumns, numberOfRows, area);

			// assert
			Check.That(actual).Equals(expected);
		}

		[Fact]
		public void MinimuDistanceReturnsCorrectValue5()
		{
			// arrange
			const int numberOfColumns = 6;
			const int numberOfRows = 6;
			var area = new[,]
			{
				{1,9,1,1,1,1 },
				{1,1,0,0,0,1 },
				{1,1,1,1,1,1 },
				{1,1,1,0,0,1 },
				{1,1,1,0,0,0 },
				{1,1,1,0,0,0 }
			};
			const int expected = 1;
			var service = new DeliveryService();

			// act
			var actual = service.MinimumDistance(numberOfColumns, numberOfRows, area);

			// assert
			Check.That(actual).Equals(expected);
		}

		[Fact]
		public void MinimuDistanceReturnsCorrectValue6()
		{
			// arrange
			const int numberOfColumns = 10;
			const int numberOfRows = 10;
			var area = new[,]
			{
				{1,1,1,1,1,1,1,1,1,1 },
				{1,0,1,0,1,0,1,0,1,1 },
				{1,0,1,0,1,0,1,0,0,1 },
				{1,0,1,0,1,0,1,0,1,1 },
				{1,0,1,0,1,0,1,0,0,1 },
				{1,0,1,0,1,0,1,0,1,1 },
				{1,0,1,0,1,0,1,0,0,1 },
				{1,0,1,0,1,0,1,0,1,1 },
				{1,0,1,0,1,0,1,0,0,1 },
				{1,1,1,1,1,1,1,1,1,9 },
			};
			const int expected = 18;
			var service = new DeliveryService();

			// act
			var actual = service.MinimumDistance(numberOfColumns, numberOfRows, area);

			// assert
			Check.That(actual).Equals(expected);
		}
	}
}
