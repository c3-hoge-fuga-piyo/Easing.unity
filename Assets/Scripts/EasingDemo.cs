using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace OhanaYa.Demo
{
    using Easing;
    using EasingFunction = System.Func<float, float>;

    public sealed class EasingDemo : MonoBehaviour
    {
        static readonly Dictionary<string, EasingFunction> Functions = new Dictionary<string, EasingFunction>
            {
                {"Linear", Linear.Evaluate},

                {"Sinusoidal-In", Sinusoidal.In},
                {"Sinusoidal-Out", Sinusoidal.Out},
                {"Sinusoidal-InOut", Sinusoidal.InOut},
                {"Sinusoidal-OutIn", Sinusoidal.OutIn},

                {"Quadratic-In", Quadratic.In},
                {"Quadratic-Out", Quadratic.Out},
                {"Quadratic-InOut", Quadratic.InOut},
                {"Quadratic-OutIn", Quadratic.OutIn},

                {"Cubic-In", Cubic.In},
                {"Cubic-Out", Cubic.Out},
                {"Cubic-InOut", Cubic.InOut},
                {"Cubic-OutIn", Cubic.OutIn},

                {"Quartic-In", Quartic.In},
                {"Quartic-Out", Quartic.Out},
                {"Quartic-InOut", Quartic.InOut},
                {"Quartic-OutIn", Quartic.OutIn},

                {"Quintic-In", Quintic.In},
                {"Quintic-Out", Quintic.Out},
                {"Quintic-InOut", Quintic.InOut},
                {"Quintic-OutIn", Quintic.OutIn},

                {"Exponential-In", Exponential.In},
                {"Exponential-Out", Exponential.Out},
                {"Exponential-InOut", Exponential.InOut},
                {"Exponential-OutIn", Exponential.OutIn},

                {"Circular-In", Circular.In},
                {"Circular-Out", Circular.Out},
                {"Circular-InOut", Circular.InOut},
                {"Circular-OutIn", Circular.OutIn},

                {"Back-In", Back.In},
                {"Back-Out", Back.Out},
                {"Back-InOut", Back.InOut},
                {"Back-OutIn", Back.OutIn},

                {"Elastic-In", Elastic.In},
                {"Elastic-Out", Elastic.Out},
                {"Elastic-InOut", Elastic.InOut},
                {"Elastic-OutIn", Elastic.OutIn},

                {"Bounce-In", Bounce.In},
                {"Bounce-Out", Bounce.Out},
                {"Bounce-InOut", Bounce.InOut},
                {"Bounce-OutIn", Bounce.OutIn},
            };

        static readonly Color[] Colors = new Color[]
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            Color.magenta,
            Color.cyan,
        };

        #region Unity Inspectors
        [SerializeField]
        Dropdown dropdown;

        [SerializeField]
        Text text;

        [SerializeField]
        Image[] points;
        #endregion

        #region Unity Messages
        void OnEnable()
        {
            Assert.IsNotNull(this.dropdown);
            this.dropdown.onValueChanged.AddListener(this.OnValueChanged);
        }

        void OnDisable()
        {
            Assert.IsNotNull(this.dropdown);
            this.dropdown.onValueChanged.RemoveListener(this.OnValueChanged);
        }

        void Start()
        {
            Assert.IsNotNull(this.dropdown);
            this.dropdown.AddOptions(Functions.Keys.ToList());

            this.dropdown.value = Random.Range(0, Functions.Count);
        }
        #endregion

        #region Events
        void OnValueChanged(int value)
        {
            var key = Functions.Keys.ElementAt(value);
            this.text.text = key;
            var easingFunction = Functions[key];
            var l = this.points.Length;

            {
                this.routines.ForEach(x => this.StopCoroutine(x));
                this.routines.Clear();
            }

            var fromColorIndex = Random.Range(0, Colors.Length);
            var toColorIndex = Random.Range(0, Colors.Length);
            var fromColor = Colors[fromColorIndex];

            var toColor = (fromColorIndex != toColorIndex) ? Colors[toColorIndex] : Color.white;

            for (var i = 0; i < l; ++i)
            {
                var routine = StartEasing(
                    easingFunction,
                    this.points,
                    i,
                    fromColor,
                    toColor);

                this.StartCoroutine(routine);

                this.routines.Add(routine);
            }
        }
        #endregion

        readonly List<IEnumerator> routines = new List<IEnumerator>();

        static IEnumerator StartEasing(EasingFunction easingFunction, Image[] targets, int index, Color baseFromColor, Color baseToColor)
        {
            Assert.IsNotNull(easingFunction);
            Assert.IsNotNull(targets);
            Assert.IsTrue(index >= 0);
            Assert.IsTrue(index < targets.Length);

            const float Duration = 0.5f;

            var target = targets[index];
            var rectTransform = target.rectTransform;
            Assert.IsNotNull(target);
            Assert.IsNotNull(rectTransform);

            var d = Mathf.Clamp01((float)index / Mathf.Max(1, targets.Length - 1));
            var size = new Vector2(1000.0f / targets.Length, 1000.0f / targets.Length);
            rectTransform.sizeDelta = size;
            var minY = size.y * 5;
            var maxY = 720 - minY - size.y;

            var fromPosition = new Vector2(size.x * index, rectTransform.anchoredPosition.y);
            var toY = Mathf.LerpUnclamped(minY, maxY, easingFunction(d));

            var fromColor = target.color;
            var toColor = Color.Lerp(baseFromColor, baseToColor, d);

            var startTime = Time.time;
            while (true)
            {
                var amount = Mathf.Clamp01((Time.time - startTime) / Duration);
                var y = Mathf.LerpUnclamped(fromPosition.y, toY, easingFunction(amount));

                rectTransform.anchoredPosition = new Vector2(fromPosition.x, y);

                target.color = Color.Lerp(
                    fromColor,
                    toColor,
                    amount);

                if (Mathf.Approximately(amount, 1)) break;

                yield return null;
            }
        }
    }
}
