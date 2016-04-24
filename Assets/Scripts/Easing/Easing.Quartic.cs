using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Quartic
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * amount * amount * amount * amount + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;
            amount -= 1;

            return -delta * (amount * amount * amount * amount - 1) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;
            amount *= 2;

            if (amount < 1) return delta / 2 * amount * amount * amount * amount + from;

            amount -= 2;

            return -delta / 2 * (amount * amount * amount * amount - 2) + from;
        }
    }
}
