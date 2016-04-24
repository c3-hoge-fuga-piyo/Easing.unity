using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Sinusoidal
    {
        public static float In(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * (1 - Mathf.Cos(amount * Mathf.PI / 2)) + from;
        }

        public static float Out(float from, float to, float amount)
        {
            var delta = to - from;

            return delta * Mathf.Sin(amount * Mathf.PI / 2) + from;
        }

        public static float InOut(float from, float to, float amount)
        {
            var delta = to - from;

            return delta / 2 * (1 - Mathf.Cos(amount * Mathf.PI)) + from;
        }
    }
}
