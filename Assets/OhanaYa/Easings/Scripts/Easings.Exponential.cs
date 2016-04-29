using UnityEngine;

namespace OhanaYa.Easings
{
    public static class Exponential
    {
        public static float In(float t)
        {
            return Mathf.Pow(2, 10 * (t - 1));
        }

        public static float Out(float t)
        {
            return -Mathf.Pow(2, -10 * t) + 1;
        }

        public static float InOut(float t)
        {
            var x = 2 * t - 1;

            return (t < 0.5f)
                ? 0.5f * Mathf.Pow(2, 10 * x)
                : 0.5f * -Mathf.Pow(2, -10 * x) + 1;
        }

        public static float OutIn(float t)
        {
            return (t < 0.5f)
                ? 0.5f * (-Mathf.Pow(2, -20 * t) + 1)
                : 0.5f * (Mathf.Pow(2, 20 * (t - 1)) + 1);
        }
    }
}
