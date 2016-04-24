using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Back
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * (amount * amount * amount - amount * Mathf.Sin(amount * Mathf.PI)) + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;
            amount = 1 - amount;

            return -delta * (amount * amount * amount - amount * Mathf.Sin(amount * Mathf.PI) - 1) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;
            amount *= 2;

            if (amount < 1) return delta / 2 * (amount * amount * amount - amount * Mathf.Sin(amount * Mathf.PI)) + from;
            amount = 2 - amount;

            return -delta / 2 * (amount * amount * amount - amount * Mathf.Sin(amount * Mathf.PI) - 2) + from;
        }
    }
}
