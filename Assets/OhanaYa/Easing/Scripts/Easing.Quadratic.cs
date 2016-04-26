using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Quadratic
    {
        public static float In(float t)
        {
            return t * t;
        }

        public static float Out(float t)
        {
            return -t * (t - 2);
        }

        public static float InOut(float t)
        {
            return (t < 0.5f)
                ? 2 * t * t
                : (-2 * t * t) + (4 * t) - 1;
        }

        public static float OutIn(float t)
        {
            return (t < 0.5f)
                ? (-2 * t * t) + (2 * t)
                : (2 * t * t) - (2 * t) + 1;
        }
    }
}
