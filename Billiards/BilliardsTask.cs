namespace Billiards
{
    public static class BilliardsTask
    {
        public static double BounceWall(double directionRadians, double wallInclinationRadians) =>
            2 * wallInclinationRadians - directionRadians;
    }
}