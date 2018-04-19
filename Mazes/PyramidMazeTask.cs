namespace Mazes
{
    public static class PyramidMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            var stepsCount = width - 3;
            while (!robot.Finished)
            {
                Move(robot, Direction.Right, stepsCount);
                Move(robot, Direction.Up, 2);
                stepsCount -= 2;
                Move(robot, Direction.Left, stepsCount);
                stepsCount -= 2;

                if (!robot.Finished)
                {
                    Move(robot, Direction.Up, 2);
                }
            }
        }

        private static void Move(Robot robot, Direction direction, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                robot.MoveTo(direction);
            }
        }
    }
}