using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Elastic
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * (Mathf.Sin(13 * Mathf.PI / 2 * amount) * Mathf.Pow(2, 10 * (amount - 1))) + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * (Mathf.Sin(-13 * Mathf.PI / 2 * (amount + 1)) * Mathf.Pow(2, -10 * amount) + 1) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;
            amount *= 2;

            if (amount < 1) return delta / 2 * (Mathf.Sin(13 * Mathf.PI / 2 * amount) * Mathf.Pow(2, 10 * (amount - 1))) + from;

            amount -= 1;

            return delta / 2 * (Mathf.Sin(-13 * Mathf.PI / 2 * (amount + 1)) * Mathf.Pow(2, -10 * amount) + 2) + from;
        }
    }
}
