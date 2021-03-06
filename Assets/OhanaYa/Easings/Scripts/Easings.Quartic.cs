﻿using UnityEngine;

namespace OhanaYa.Easings
{
    public static class Quartic
    {
        public static float In(float t)
        {
            return t * t * t * t;
        }

        public static float Out(float t)
        {
            var x = t - 1;

            return x * x * x * (1 - t) + 1;
        }

        public static float InOut(float t)
        {
            return (t < 0.5f)
                ? 8 * t * t * t * t
                : -8 * (t - 1) * (t - 1) * (t - 1) * (t - 1) + 1;
        }

        public static float OutIn(float t)
        {
            var x = 2 * t - 1;

            return (t < 0.5f)
                ? 0.5f * (-x * x * x * x + 1)
                : 0.5f * (x * x * x * x + 1);
        }
    }
}
