using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Quadratic
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * amount * amount + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;

            return -delta * amount * (amount - 2) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;
            amount *= 2;

            if (amount < 1) return delta / 2 * amount * amount + from;

            amount -= 1;

            return -delta / 2 * (amount * (amount - 2) - 1) + from;
        }
    }
}
