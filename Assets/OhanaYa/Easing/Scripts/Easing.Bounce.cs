using UnityEngine;

namespace OhanaYa.Easing
{
    public static class Bounce
    {
        public static float In(float t)
        {
            return 1 - Out(1 - t);
        }

        public static float Out(float t)
        {
            const float
                A = 4.0f / 11.0f,
                B = 8.0f / 11.0f,
                C = 9.0f / 10.0f,
                D = 363.0f / 40.0f,
                E = 99.0f / 10.0f,
                F = 17.0f / 5.0f,
                G = 4356.0f / 361.0f,
                H = 35442.0f / 1805.0f,
                I = 16061.0f / 1805.0f,
                J = 54.0f / 5.0f,
                K = 513.0f / 25.0f,
                L = 268.0f / 25.0f;

            if (t < A) return (121.0f * t * t) / 16.0f;

            if (t < B) return (D * t * t) - (E * t) + F;

            if (t < C) return (G * t * t) - (H * t) + I;

            return (J * t * t) - (K * t) + L;
        }

        public static float InOut(float t)
        {
            return (t < 0.5f)
                ? 0.5f * In(2 * t)
                : 0.5f * Out(2 * t - 1) + 0.5f;
        }

        public static float OutIn(float t)
        {
            return (t < 0.5f)
                ? 0.5f * Out(2 * t)
                : 0.5f * In(2 * t - 1) + 0.5f;
        }
    }
}
