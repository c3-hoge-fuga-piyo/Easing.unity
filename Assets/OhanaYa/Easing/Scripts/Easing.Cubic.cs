using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Cubic
    {
        public static float In(float t)
        {
            return Mathf.Pow(t, 3);
        }

        public static float Out(float t)
        {
            return Mathf.Pow(t - 1, 3) + 1;
        }

        public static float InOut(float t)
        {
            var x = 2 * t;

            return (t < 0.5f)
                ? 0.5f * Mathf.Pow(x, 3)
                : 0.5f * Mathf.Pow(x - 2, 3) + 1;
        }

        public static float OutIn(float t)
        {
            var x = 2 * t - 1;

            return (t < 0.5f)
                ? 0.5f * Mathf.Pow(x, 3) + 0.5f
                : 0.5f * (Mathf.Pow(x, 3) + 1);
        }
    }
}
