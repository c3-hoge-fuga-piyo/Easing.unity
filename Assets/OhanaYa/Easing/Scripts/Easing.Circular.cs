using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Circular
    {
        public static float In(float t)
        {
            return -Mathf.Sqrt(1 - (t * t)) + 1;
        }

        public static float Out(float t)
        {
            var x = t - 1;

            return Mathf.Sqrt(1 - (x * x));
        }

        public static float InOut(float t)
        {
            return (t < 0.5f)
                ? 0.5f * (-Mathf.Sqrt(1 - (4 * t * t)) + 1)
                : 0.5f * (Mathf.Sqrt(1 - (4 * (t - 1) * (t - 1))) + 1);
        }

        public static float OutIn(float t)
        {
            var x = (2 * t - 1);
            var y = 1 - (x * x);

            return (t < 0.5f)
                ? 0.5f * (Mathf.Sqrt(y))
                : 0.5f * -Mathf.Sqrt(y) + 1;
        }
    }
}
