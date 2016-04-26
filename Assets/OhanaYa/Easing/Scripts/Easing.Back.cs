using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Back
    {
        public static float In(float t)
        {
            return t * t * t - t * Mathf.Sin(t * Mathf.PI);
        }

        public static float Out(float t)
        {
            var x = 1 - t;

            return 1 - (x * x * x - x * Mathf.Sin(x * Mathf.PI));
        }

        public static float InOut(float t)
        {
            return (t < 0.5f)
                ? 4 * t * t * t - t * Mathf.Sin(2 * t * Mathf.PI)
                : 1 - (4 * (1 - t) * (1 - t) * (1 - t) - (1 - t) * Mathf.Sin(2 * (1 - t) * Mathf.PI));
        }

        public static float OutIn(float t)
        {
            var x = 2 * t - 1;
            var y = Mathf.Sin(x * Mathf.PI);

            return (t < 0.5f)
                ? 0.5f * (1 + (x * x * x + x * y))
                : 0.5f * (x * x * x - x * y + 1);
        }
    }
}
