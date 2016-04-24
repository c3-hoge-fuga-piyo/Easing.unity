using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Qubic
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * Mathf.Pow(amount, 3) + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * (Mathf.Pow(amount - 1, 3) + 1) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;
            amount *= 2;

            if (amount < 1) return delta / 2 * Mathf.Pow(amount, 3) + from;

            return delta / 2 * (Mathf.Pow(amount - 2, 3) + 2) + from;
        }
    }
}
