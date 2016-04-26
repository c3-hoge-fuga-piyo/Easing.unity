using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Quintic
    {
        public static float In(float t)
        {
            return t * t * t * t * t;
        }

        public static float Out(float t)
        {
            var x = t - 1;

            return x * x * x * x * x + 1;
        }

        public static float InOut(float t)
        {
            return (t < 0.5f)
                ? 16 * t * t * t * t * t
                : 16 * (t - 1) * (t - 1) * (t - 1) * (t - 1) * (t - 1) + 1;
        }

        public static float OutIn(float t)
        {
            var x = 2 * t - 1;

            return 0.5f * (x * x * x * x * x + 1);
        }
    }
}
