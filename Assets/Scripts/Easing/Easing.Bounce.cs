using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Bounce
    {
        public static float In(float amount)
        {
            return 1 - Out(1 - amount);
        }

        public static float Out(float amount)
        {
            if (amount < 4.0f / 11.0f) return (121.0f * amount * amount) / 16.0f;

            if (amount < 8.0f / 11.0f) return (363.0f / 40.0f * amount * amount) - (99.0f / 10.0f * amount) + 17.0f / 5.0f;

            if (amount < 9.0f / 10.0f) return (4356.0f / 361.0f * amount * amount) - (35442.0f / 1805.0f * amount) + 16061.0f / 1805.0f;

            return (54.0f / 5.0f * amount * amount) - (513.0f / 25.0f * amount) + (268.0f / 25.0f);
        }

        public static float InOut(float amount)
        {
            return (amount < 0.5f)
                ? 0.5f * In(2 * amount)
                : 0.5f * Out(2 * amount - 1) + 0.5f;
        }

        public static float In(float from, float to, float amount)
        {
            return Mathf.LerpUnclamped(from, to, In(amount));
        }

        public static float Out(float from, float to, float amount)
        {
            return Mathf.LerpUnclamped(from, to, Out(amount));
        }

        public static float InOut(float from, float to, float amount)
        {
            return Mathf.LerpUnclamped(from, to, InOut(amount));
        }
    }
}
