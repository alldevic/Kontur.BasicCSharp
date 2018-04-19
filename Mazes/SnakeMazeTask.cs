namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (!robot.Finished)
            {
                Move(robot, Direction.Right, width - 2 - robot.X);
                Move(robot, Direction.Down, 2);
                Move(robot, Direction.Left, width - 3);

                if (!robot.Finished)
                {
                    Move(robot, Direction.Down, 2);
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