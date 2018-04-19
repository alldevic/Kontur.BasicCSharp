namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			Direction bigDirection = Direction.Right, smallDirection = Direction.Down;
			var step = (width - 1) / (height - 2);

			if (width < height)
			{
				step = (height - 1) / (width - 2);
				bigDirection = Direction.Down;
				smallDirection = Direction.Right;
			}

			while (!robot.Finished)
			{
				Move(robot, bigDirection, step);
				if (!robot.Finished)
				{
					Move(robot, smallDirection, 1);
				}
			}
		}

		private static void Move(Robot robot, Direction direction, int count)
		{
			for (var i = 0; i < count; i++)
			{
				robot.MoveTo(direction);
			}
		}
	}
}