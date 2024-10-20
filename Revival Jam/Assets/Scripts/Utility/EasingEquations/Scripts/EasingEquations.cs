using UnityEngine;

namespace Utility.EasingEquations
{
	public static class EasingFloatEquations
	{
		public static float Linear(float start, float end, float value)
		{
			return (end - start) * value + start;
		}

		public static float Spring(float start, float end, float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value))
				* Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
			return start + (end - start) * value;
		}

		public static float EaseInExpo(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
		}

		public static float EaseOutExpo(float start, float end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
		}

		public static float EaseInOutExpo(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * Mathf.Pow(2, 10 * (value - 1)) + start;
			value--;
			return end / 2 * (-Mathf.Pow(2, -10 * value) + 2) + start;
		}

		public static float EaseInCirc(float start, float end, float value)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
		}

		public static float EaseOutCirc(float start, float end, float value)
		{
			value--;
			end -= start;
			return end * Mathf.Sqrt(1 - value * value) + start;
		}

		public static float EaseOutBack(float start, float end, float value)
		{
			float s = 1.70158f;
			end -= start;
			value = (value / 1) - 1;
			return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
		}

		public static float Punch(float amplitude, float value)
		{
			float s = 9;
			if (value == 0)
			{
				return 0;
			}
			if (value == 1)
			{
				return 0;
			}
			float period = 1 * 0.3f;
			s = period / (2 * Mathf.PI) * Mathf.Asin(0);
			return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
		}

		public static float EaseInElastic(float start, float end, float value)
		{
			end -= start;

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0)
				return start;

			if ((value /= d) == 1)
				return start + end;

			if (a == 0 || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4;
			}
			else
			{
				s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
			}

			return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
		}

		public static float EaseOutElastic(float start, float end, float value)
		{
			end -= start;

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0)
				return start;

			if ((value /= d) == 1)
				return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4;
			}
			else
			{
				s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
			}

			return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
		}

		public static float EaseInOutElastic(float start, float end, float value)
		{
			end -= start;

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0)
				return start;

			if ((value /= d / 2) == 2)
				return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4;
			}
			else
			{
				s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
			}

			if (value < 1)
				return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
			return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
		}
	}

	public static class EasingVector2Equations
	{
		public static Vector2 Linear(Vector2 start, Vector2 end, float value)
		{
			return (end - start) * value + start;
		}

		public static Vector2 Spring(Vector2 start, Vector2 end, float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value))
				* Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
			return start + (end - start) * value;
		}

		public static Vector2 EaseInExpo(Vector2 start, Vector2 end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
		}

		public static Vector2 EaseOutExpo(Vector2 start, Vector2 end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
		}

		public static Vector2 EaseInCirc(Vector2 start, Vector2 end, float value)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
		}

		public static Vector2 EaseInOutExpo(Vector2 start, Vector2 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * Mathf.Pow(2, 10 * (value - 1)) + start;
			value--;
			return end / 2 * (-Mathf.Pow(2, -10 * value) + 2) + start;
		}

		public static Vector2 EaseOutCirc(Vector2 start, Vector2 end, float value)
		{
			value--;
			end -= start;
			return end * Mathf.Sqrt(1 - value * value) + start;
		}

		public static Vector2 EaseOutBack(Vector2 start, Vector2 end, float value)
		{
			float s = 1.70158f;
			end -= start;
			value = (value / 1) - 1;
			return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
		}

		public static Vector2 Punch(Vector2 amplitude, float value)
		{
			float s = 9;
			if (value == 0)
			{
				return Vector2.zero;
			}
			if (value == 1)
			{
				return Vector2.zero;
			}
			float period = 1 * 0.3f;
			s = period / (2 * Mathf.PI) * Mathf.Asin(0);
			return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
		}
	}

	public static class EasingVector3Equations
	{
		public static Vector3 Linear(Vector3 start, Vector3 end, float value)
		{
			return (end - start) * value + start;
		}

		public static Vector3 Spring(Vector3 start, Vector3 end, float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value))
				* Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
			return start + (end - start) * value;
		}

		public static Vector3 EaseInQuad(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * value * value + start;
		}

		public static Vector3 EaseOutQuad(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return -end * value * (value - 2) + start;
		}

		public static Vector3 EaseInOutQuad(Vector3 start, Vector3 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * value * value + start;
			value--;
			return -end / 2 * (value * (value - 2) - 1) + start;
		}

		public static Vector3 EaseInCubic(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * value * value * value + start;
		}

		public static Vector3 EaseOutCubic(Vector3 start, Vector3 end, float value)
		{
			value--;
			end -= start;
			return end * (value * value * value + 1) + start;
		}

		public static Vector3 EaseInOutCubic(Vector3 start, Vector3 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * value * value * value + start;
			value -= 2;
			return end / 2 * (value * value * value + 2) + start;
		}

		public static Vector3 EaseInQuart(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * value * value * value * value + start;
		}

		public static Vector3 EaseOutQuart(Vector3 start, Vector3 end, float value)
		{
			value--;
			end -= start;
			return -end * (value * value * value * value - 1) + start;
		}

		public static Vector3 EaseInOutQuart(Vector3 start, Vector3 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * value * value * value * value + start;
			value -= 2;
			return -end / 2 * (value * value * value * value - 2) + start;
		}

		public static Vector3 EaseInQuint(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * value * value * value * value * value + start;
		}

		public static Vector3 EaseOutQuint(Vector3 start, Vector3 end, float value)
		{
			value--;
			end -= start;
			return end * (value * value * value * value * value + 1) + start;
		}

		public static Vector3 EaseInOutQuint(Vector3 start, Vector3 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * value * value * value * value * value + start;
			value -= 2;
			return end / 2 * (value * value * value * value * value + 2) + start;
		}

		public static Vector3 EaseInSine(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return -end * Mathf.Cos(value / 1 * (Mathf.PI / 2)) + end + start;
		}

		public static Vector3 EaseOutSine(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * Mathf.Sin(value / 1 * (Mathf.PI / 2)) + start;
		}

		public static Vector3 EaseInOutSine(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return -end / 2 * (Mathf.Cos(Mathf.PI * value / 1) - 1) + start;
		}

		public static Vector3 EaseInExpo(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
		}

		public static Vector3 EaseOutExpo(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
		}

		public static Vector3 EaseInOutExpo(Vector3 start, Vector3 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return end / 2 * Mathf.Pow(2, 10 * (value - 1)) + start;
			value--;
			return end / 2 * (-Mathf.Pow(2, -10 * value) + 2) + start;
		}

		public static Vector3 EaseInCirc(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
		}

		public static Vector3 EaseOutCirc(Vector3 start, Vector3 end, float value)
		{
			value--;
			end -= start;
			return end * Mathf.Sqrt(1 - value * value) + start;
		}

		public static Vector3 EaseInOutCirc(Vector3 start, Vector3 end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1)
				return -end / 2 * (Mathf.Sqrt(1 - value * value) - 1) + start;
			value -= 2;
			return end / 2 * (Mathf.Sqrt(1 - value * value) + 1) + start;
		}

		public static Vector3 EaseInBounce(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			float d = 1f;
			return end - EaseOutBounce(Vector3.zero, end, d - value) + start;
		}

		public static Vector3 EaseOutBounce(Vector3 start, Vector3 end, float value)
		{
			value /= 1f;
			end -= start;
			if (value < (1 / 2.75f))
			{
				return end * (7.5625f * value * value) + start;
			}
			else if (value < (2 / 2.75f))
			{
				value -= (1.5f / 2.75f);
				return end * (7.5625f * (value) * value + .75f) + start;
			}
			else if (value < (2.5 / 2.75))
			{
				value -= (2.25f / 2.75f);
				return end * (7.5625f * (value) * value + .9375f) + start;
			}
			else
			{
				value -= (2.625f / 2.75f);
				return end * (7.5625f * (value) * value + .984375f) + start;
			}
		}

		public static Vector3 EaseInOutBounce(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			float d = 1f;
			if (value < d / 2)
				return EaseInBounce(Vector3.zero, end, value * 2) * 0.5f + start;
			else
				return EaseOutBounce(Vector3.zero, end, value * 2 - d) * 0.5f + end * 0.5f + start;
		}

		public static Vector3 EaseInBack(Vector3 start, Vector3 end, float value)
		{
			end -= start;
			value /= 1;
			float s = 1.70158f;
			return end * (value) * value * ((s + 1) * value - s) + start;
		}

		public static Vector3 EaseOutBack(Vector3 start, Vector3 end, float value)
		{
			float s = 1.70158f;
			end -= start;
			value = (value / 1) - 1;
			return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
		}

		public static Vector3 EaseInOutBack(Vector3 start, Vector3 end, float value)
		{
			float s = 1.70158f;
			end -= start;
			value /= .5f;
			if ((value) < 1)
			{
				s *= (1.525f);
				return end / 2 * (value * value * (((s) + 1) * value - s)) + start;
			}
			value -= 2;
			s *= (1.525f);
			return end / 2 * ((value) * value * (((s) + 1) * value + s) + 2) + start;
		}

		public static Vector3 Punch(Vector3 amplitude, float value)
		{
			float s = 9;
			if (value == 0)
			{
				return Vector3.zero;
			}
			if (value == 1)
			{
				return Vector3.zero;
			}
			float period = 1 * 0.3f;
			s = period / (2 * Mathf.PI) * Mathf.Asin(0);
			return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
		}

		public static Vector3 EaseInElastic(Vector3 start, Vector3 end, float value)
		{
			Vector3 t = new Vector3
				(EasingFloatEquations.EaseInElastic(start.x, end.x, value),
				 EasingFloatEquations.EaseInElastic(start.y, end.y, value),
				 EasingFloatEquations.EaseInElastic(start.z, end.z, value));
			return t;
		}

		public static Vector3 EaseOutElastic(Vector3 start, Vector3 end, float value)
		{
			Vector3 t = new Vector3
				(EasingFloatEquations.EaseOutElastic(start.x, end.x, value),
				 EasingFloatEquations.EaseOutElastic(start.y, end.y, value),
				 EasingFloatEquations.EaseOutElastic(start.z, end.z, value));
			return t;
		}

		public static Vector3 EaseInOutElastic(Vector3 start, Vector3 end, float value)
		{
			Vector3 t = new Vector3
				(EasingFloatEquations.EaseInOutElastic(start.x, end.x, value),
				 EasingFloatEquations.EaseInOutElastic(start.y, end.y, value),
				 EasingFloatEquations.EaseInOutElastic(start.z, end.z, value));
			return t;
		}
	}

	public static class EasingColorEquations
	{
		public static Color Linear(Color start, Color end, float value)
		{
			return (end - start) * value + start;
		}

		public static Color Spring(Color start, Color end, float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value))
				* Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
			return start + (end - start) * value;
		}
		public static Color EaseInExpo(Color start, Color end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
		}

		public static Color EaseOutExpo(Color start, Color end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
		}
	}
}