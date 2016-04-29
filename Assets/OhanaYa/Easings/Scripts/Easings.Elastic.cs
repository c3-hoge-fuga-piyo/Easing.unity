using UnityEngine;

namespace OhanaYa.Easings
{
    public static class Elastic
    {
        public static float In(float t)
        {
            const float HALF_PI = Mathf.PI / 2;
            const float A = 13 * HALF_PI;

            return Mathf.Sin(A * t) * Mathf.Pow(2, 10 * (t - 1));
        }

        public static float Out(float t)
        {
            const float HALF_PI = Mathf.PI / 2;
            const float A = -13 * HALF_PI;

            return Mathf.Sin(A * (t + 1)) * Mathf.Pow(2, -10 * t) + 1;
        }

        public static float InOut(float t)
        {
            const float HALF_PI = Mathf.PI / 2;
            const float A = 13 * HALF_PI;

            var x = A * 2 * t;
            var y = 10 * (2 * t - 1);
            var z = Mathf.Sin(x);

            return (t < 0.5f)
                ? 0.5f * (z * Mathf.Pow(2, y))
                : 0.5f * (-z * Mathf.Pow(2, -y) + 2);
        }

        public static float OutIn(float t)
        {
            const float HALF_PI = Mathf.PI / 2;
            const float A = 13 * HALF_PI;

            var x = A * 2 * t;
            var y = 20 * t;

            return (t < 0.5f)
                ? 0.5f * (Mathf.Sin(-x - A) * Mathf.Pow(2, -y) + 1)
                : 0.5f * (Mathf.Sin(x - A) * Mathf.Pow(2, y - 20) + 1);
        }
    }
}
