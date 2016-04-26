using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Sinusoidal
    {
        public static float In(float t)
        {
            const float HALF_PI = Mathf.PI / 2;

            return 1 - Mathf.Cos(t * HALF_PI);
        }

        public static float Out(float t)
        {
            const float HALF_PI = Mathf.PI / 2;

            return Mathf.Sin(t * HALF_PI);
        }

        public static float InOut(float t)
        {
            return (1 - Mathf.Cos(t * Mathf.PI)) / 2;
        }

        public static float OutIn(float t)
        {
            const float HALF_PI = Mathf.PI / 2;
            var x = 2 * t * HALF_PI;

            return (t < 0.5f)
                ? 0.5f * Mathf.Sin(x)
                : 0.5f * (-Mathf.Cos(x - HALF_PI) + 2);
        }
    }
}
