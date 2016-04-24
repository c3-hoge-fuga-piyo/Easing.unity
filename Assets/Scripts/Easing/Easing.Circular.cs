using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Circular
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return -delta * (Mathf.Sqrt(1 - amount * amount) - 1) + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;
            amount -= 1;

            return delta * Mathf.Sqrt(1 - amount * amount) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;
            amount *= 2;

            if (amount < 1) return -delta / 2 * (Mathf.Sqrt(1 - amount * amount) - 1) + from;
            amount -= 2;

            return delta / 2 * (Mathf.Sqrt(1 - amount * amount) + 1) + from;
        }
    }
}
