using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonDeliveryService
{
	public class DeliveryService
	{
		private enum Direction
		{
			Left,
			Right,
			Up,
			Down
		}

		public int MinimumDistance(int columns, int rows, int[,] area)
		{
			const int currentRow = 0;
			const int currentColumn = 0;
			var result = int.MaxValue;
			int? shortestDistance = int.MaxValue;

			var resultRight = FindMinDistance(Direction.Right, currentColumn, currentRow, columns, rows, area, 0, new List<int[]>(), ref shortestDistance);
			if (resultRight != -1)
			{
				result = Math.Min(resultRight, resultRight);
			}

			var resultDown = FindMinDistance(Direction.Down, currentColumn, currentRow, columns, rows, area, 0, new List<int[]>(), ref shortestDistance);
			if (resultDown != -1)
			{
				result = Math.Min(resultDown, result);
			}
			return result;
		}

		private static int FindMinDistance(Direction direction, int currentColumn, int currentRow, int columns, int rows, int[,] area, int currentDistance, IReadOnlyCollection<int[]> path, ref int? shortestDistance)
		{
			var result = int.MaxValue;
			var thisRow = currentRow;
			var thisColumn = currentColumn;

			switch (direction)
			{
				case Direction.Left:
					thisColumn--;
					break;
				case Direction.Right:
					thisColumn++;
					break;
				case Direction.Up:
					thisRow--;
					break;
				case Direction.Down:
					thisRow++;
					break;
			}

			if (path.Any(x => x[0] == thisColumn && x[1] == thisRow)) // avoid loop, circuit breaker
			{
				return -1;
			}

			if (thisColumn >= columns || thisRow >= rows || thisColumn < 0 || thisRow < 0) // out of area
			{
				return -1;
			}

			if (shortestDistance.HasValue && shortestDistance <= currentDistance) // there is a shorter rout alreaedy
			{
				return -1;
			}

			if (area[thisColumn, thisRow] == 9) // we reached
			{
				var finalDistance = currentDistance + 1;
				if (shortestDistance > finalDistance)
				{
					shortestDistance = finalDistance;
				}

				return finalDistance;
			}

			if (area[thisColumn, thisRow] == 0) // no way
			{
				return -1;
			}

			var directions = GetDirections();
			foreach (var newDirection in directions)
			{
				var newPath = Combine(path, thisColumn, thisRow);
				var distance = FindMinDistance(newDirection, thisColumn, thisRow, columns, rows, area, currentDistance + 1, newPath, ref shortestDistance);
				if (distance != -1)
				{
					result = Math.Min(distance, result);
				}
			}

			return result;
		}
		
		private static List<int[]> Combine(IEnumerable<int[]> list, int x, int y)
		{
			var result = new List<int[]>(list) { new[] { x, y } };
			return result;
		}

		private static IEnumerable<Direction> GetDirections()
		{
			return Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
		}
	}
}
