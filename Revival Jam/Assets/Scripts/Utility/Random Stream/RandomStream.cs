using System;
using UnityEngine;

namespace Utility.Random
{
	/// <summary>
	/// Wrapper class for RNG objects and methods.
	/// Instances of this class have their own number generation flow, 
	/// <br>and do not interfere with the use of other instances. 
	/// Static methods uses Unity's RNG class.</br>
	/// </summary>
	public class RandomStream
	{
		/// <summary>
		/// Seed used to initialize the current instance.
		/// </summary>
		public int seed { get; private set; }

		/// <summary>
		/// Object of the system's Random class, used to separate the generation of numbers 
		/// <br>from other instances of this class.</br>
		/// </summary>
		private System.Random rand;

		/// <summary>
		/// Instantiate object with default seed (Environment.TickCount).
		/// </summary>
		public RandomStream()
		{
			this.seed = Environment.TickCount;
			rand = new System.Random(seed);
		}

		/// <summary>
		/// Instantiate object with desired seed.
		/// </summary>
		public RandomStream(int seed)
		{
			this.seed = seed;
			rand = new System.Random(seed);
		}

		/// <summary>
		/// Resets object to its initial state.
		/// </summary>
		public void Restart()
		{
			rand = new System.Random(seed);
		}

		/*****     Primitive Types     *****/
		#region Primitives

		/// <summary>
		/// Returns a random boolean state.
		/// </summary>
		/// <returns>Boolean state.</returns>
		public bool nextBool()
		{
			int i = rand.Next(0, 2);
			if (i == 1)
			{ return true; }
			return false;
		}

		/// <summary>
		/// Returns a random boolean state. This method uses global RNG.
		/// </summary>
		/// <returns>Boolean state.</returns>
		public static bool NextBool()
		{
			int i = UnityEngine.Random.Range(0, 2);
			if (i == 1)
			{ return true; }
			return false;
		}

		/// <summary>
		/// Returns a random integer. Min inclusive, Max exclusive.
		/// </summary>
		/// <returns>Random integer.</returns>
		public int nextInt(int min, int max)
		{
			return rand.Next(min, max);
		}

		/// <summary>
		/// Returns a random integer. Min inclusive, Max exclusive. This method uses global RNG.
		/// </summary>
		/// <returns>Random integer.</returns>
		public static int NextInt(int min, int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		/// <summary>
		/// Returns a random float. Min inclusive, Max exclusive.
		/// </summary>
		/// <returns>Random float.</returns>
		public float nextFloat(float min, float max, int decimalPlaces = 8)
		{
			return (float)(Math.Round(rand.NextDouble() * (max - min) + min, decimalPlaces));
		}

		/// <summary>
		/// Returns a random float, within a inclusive range. This method uses global RNG.
		/// </summary>
		/// <returns>Random float.</returns>
		public static float NextFloat(float min, float max, int decimalPlaces = 8)
		{
			return (float)(Math.Round(UnityEngine.Random.Range(min, max), decimalPlaces));
		}

		/// <summary>
		/// Returns a value neighboring the original floating point, based on a rate of deviation.
		/// </summary>
		/// <param name="original">Original value.</param>
		/// <param name="negDeviation">Decrement deviation.</param>
		/// <param name="posDeviation">Increment deviation.</param>
		/// <returns>Noised floating point.</returns>
		public float noisedFloat(float original, float negDeviation, float posDeviation)
		{
			return original + nextFloat(negDeviation, posDeviation, 4);
		}

		/// <summary>
		/// Returns a value neighboring the original floating point, based on a rate of deviation.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="original">Original value.</param>
		/// <param name="negDeviation">Decrement deviation.</param>
		/// <param name="posDeviation">Increment deviation.</param>
		/// <returns>Noised floating point.</returns>
		public static float NoisedFloat(float original, float negDeviation, float posDeviation)
		{
			return original + NextFloat(negDeviation, posDeviation, 4);
		}

		#endregion

		/*****     Directions     *****/
		#region Directions

		/// <summary>
		/// Returns a random 2D direction (normalized).
		/// </summary>
		/// <returns>Random Vector2.</returns>
		public Vector2 direction2D()
		{
			float x = nextFloat(-1f, 1f, 4);
			float y = nextFloat(-1f, 1f, 4);
			return new Vector2(x, y).normalized;
		}

		/// <summary>
		/// Returns a random 2D direction (normalized).
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <returns>Random Vector2.</returns>
		public static Vector2 Direction2D()
		{
			float x = NextFloat(-1f, 1f, 4);
			float y = NextFloat(-1f, 1f, 4);
			return new Vector2(x, y).normalized;
		}

		public static Vector2 NextVector2(float min, float max)
		{
			float x = NextFloat(min, max, 4);
			float y = NextFloat(min, max, 4);
			return new Vector2(x, y);
		}

		public static Vector2 NextVector2(Vector2 min, Vector2 max)
		{
			float x = NextFloat(min.x, max.x, 4);
			float y = NextFloat(min.y, max.y, 4);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Returns a random 3D direction (normalized).
		/// </summary>
		/// <returns>Random Vector3.</returns>
		public Vector3 direction3D()
		{
			float x = nextFloat(-1f, 1f, 4);
			float y = nextFloat(-1f, 1f, 4);
			float z = nextFloat(-1f, 1f, 4);
			return new Vector3(x, y, z).normalized;
		}

		/// <summary>
		/// Returns a random 3D direction (normalized).
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <returns>Random Vector3.</returns>
		public static Vector3 Direction3D()
		{
			float x = NextFloat(-1f, 1f, 4);
			float y = NextFloat(-1f, 1f, 4);
			float z = NextFloat(-1f, 1f, 4);
			return new Vector3(x, y, z).normalized;
		}

		public static Vector3 NextVector3(float min, float max)
		{
			float x = NextFloat(min, max, 4);
			float y = NextFloat(min, max, 4);
			float z = NextFloat(min, max, 4);
			return new Vector3(x, y, z);
		}

		public static Vector3 NextVector3(Vector3 min, Vector3 max)
		{
			float x = NextFloat(min.x, max.x, 4);
			float y = NextFloat(min.y, max.y, 4);
			float z = NextFloat(min.z, max.z, 4);
			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Returns a direction neighboring the original vector, based on a rate of angle deviation.
		/// </summary>
		/// <param name="direction">Original vector.</param>
		/// <param name="negDeviation">Decrement deviation.</param>
		/// <param name="posDeviation">Increment deviation.</param>
		/// <returns>Noised Vector2.</returns>
		public Vector2 noiseDirection(Vector2 direction, float negDeviation, float posDeviation)
		{
			float finalAngle = nextFloat(negDeviation, posDeviation, 4);
			Vector2 n = Quaternion.Euler(0, 0, finalAngle) * direction;
			return n;
		}

		/// <summary>
		/// Returns a direction neighboring the original vector, based on a rate of angle deviation.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="direction">Original vector.</param>
		/// <param name="negDeviation">Decrement deviation.</param>
		/// <param name="posDeviation">Increment deviation.</param>
		/// <returns>Noised Vector2.</returns>
		public static Vector2 NoiseDirection(Vector2 direction, float negDeviation, float posDeviation)
		{
			float finalAngle = NextFloat(negDeviation, posDeviation, 4);
			Vector2 n = Quaternion.Euler(0, 0, finalAngle) * direction;
			return n;
		}

		/// <summary>
		/// Returns a direction neighboring the original vector, based on a rate of angle deviation.
		/// </summary>
		/// <param name="direction">Original vector.</param>
		/// <param name="axis">Axis to generate noise.</param>
		/// <param name="negDeviation">Decrement deviation.</param>
		/// <param name="posDeviation">Increment deviation.</param>
		/// <returns>Noised Vector3.</returns>
		public Vector3 noiseDirection(Vector3 direction, Vector3 axis, float negDeviation, float posDeviation)
		{
			float finalAngle = nextFloat(negDeviation, posDeviation, 4);
			Vector3 n = Quaternion.Euler(axis * finalAngle) * direction;
			return n;
		}

		/// <summary>
		/// Returns a direction neighboring the original vector, based on a rate of angle deviation.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="direction">Original vector.</param>
		/// <param name="axis">Axis to generate noise.</param>
		/// <param name="negDeviation">Decrement deviation.</param>
		/// <param name="posDeviation">Increment deviation.</param>
		/// <returns>Noised Vector3.</returns>
		public static Vector3 NoiseDirection(Vector3 direction, Vector3 axis, float negDeviation, float posDeviation)
		{
			float finalAngle = NextFloat(negDeviation, posDeviation, 4);
			Vector3 n = Quaternion.Euler(axis * finalAngle) * direction;
			return n;
		}

		#endregion

		/*****     Positions     *****/
		#region Positions

		/// <summary>
		/// Returns a random position on the surface of a circle.
		/// </summary>
		/// <param name="ray">Ray of the circle.</param>
		/// <returns>Vector2 position.</returns>
		public Vector2 circlePosition(float ray)
		{
			return direction2D() * ray;
		}

		/// <summary>
		/// Returns a random position on the surface of a circle.
		/// </summary>
		/// <param name="origin">Center position of the circle.</param>
		/// <param name="ray">Ray of the circle.</param>
		/// <returns>Vector2 position.</returns>
		public Vector2 circlePosition(Vector2 origin, float ray)
		{
			return origin + circlePosition(ray);
		}

		/// <summary>
		/// Returns a random position on the surface of a circle.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="ray">Ray of the circle.</param>
		/// <returns>Vector2 position.</returns>
		public static Vector2 CirclePosition(float ray)
		{
			return Direction2D() * ray;
		}

		/// <summary>
		/// Returns a random position in a circle range.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="innerRay">Minimum "range" of the circle.</param>
		/// <param name="outerRay">Maximum "range" of the circle.</param>
		/// <returns>Vector2 position.</returns>
		public static Vector2 CirclePosition(float innerRay, float outerRay)
		{
			return Direction2D() * NextFloat(innerRay, outerRay);
		}

		/// <summary>
		/// Returns a random position on the surface of a circle.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="origin">Center position of the circle.</param>
		/// <param name="ray">Ray of the circle.</param>
		/// <returns>Vector2 position.</returns>
		public static Vector2 CirclePosition(Vector2 origin, float ray)
		{
			return origin + CirclePosition(ray);
		}

		/// <summary>
		/// Returns a random position in a circle range.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="origin">Center position of the circle.</param>
		/// <param name="innerRay">Minimum "range" of the circle.</param>
		/// <param name="outerRay">Maximum "range" of the circle.</param>
		/// <returns>Vector2 position.</returns>
		public static Vector2 CirclePosition(Vector2 origin, float innerRay, float outerRay)
		{
			return origin + CirclePosition(innerRay, outerRay);
		}

		/// <summary>
		/// Returns a random position on the surface of a sphere.
		/// </summary>
		/// <param name="ray">Ray of the sphere.</param>
		/// <returns>Vector3 position.</returns>
		public Vector3 spherePosition(float ray)
		{
			return direction3D() * ray;
		}

		/// <summary>
		/// Returns a random position on the surface of a sphere.
		/// </summary>
		/// <param name="origin">Center position of the sphere.</param>
		/// <param name="ray">Ray of the sphere.</param>
		/// <returns>Vector3 position.</returns>
		public Vector3 spherePosition(Vector3 origin, float ray)
		{
			return origin + spherePosition(ray);
		}

		/// <summary>
		/// Returns a random position on the surface of a sphere.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="ray">Ray of the sphere.</param>
		/// <returns>Vector3 position.</returns>
		public static Vector3 SpherePosition(float ray)
		{
			return Direction3D() * ray;
		}

		/// <summary>
		/// Returns a random position on the surface of a sphere.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="origin">Center position of the sphere.</param>
		/// <param name="ray">Ray of the sphere.</param>
		/// <returns>Vector3 position.</returns>
		public static Vector3 SpherePosition(Vector3 origin, float ray)
		{
			return origin + SpherePosition(ray);
		}

		/// <summary>
		/// Returns a random position within a rectangle.
		/// </summary>
		/// <param name="minLimit">Vertex that defines the negative boundary of the rectangle area.</param>
		/// <param name="maxLimit">Vertex that defines the positive boundary of the rectangle area.</param>
		/// <returns>Random Vector2.</returns>
		public Vector2 rectanglePosition(Vector2 minLimit, Vector2 maxLimit)
		{
			float x = nextFloat(minLimit.x, maxLimit.x, 4);
			float y = nextFloat(minLimit.y, maxLimit.y, 4);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Returns a random position within a rectangle.
		/// </summary>
		/// <param name="origin">Center of the rectangle.</param>
		/// <param name="semiWidth">Semiwidth of the rectangle, starting from center.</param>
		/// <param name="semiHeight">Semiheight of the rectangle, starting from center.</param>
		/// <returns>Random Vector2.</returns>
		public Vector2 rectanglePosition(Vector2 origin, float semiWidth, float semiHeight)
		{
			Vector2 leftDown = new Vector2(origin.x - semiWidth, origin.y - semiHeight);
			Vector2 rightUp = new Vector2(origin.x + semiWidth, origin.y + semiHeight);
			return rectanglePosition(leftDown, rightUp);
		}

		/// <summary>
		/// Returns a random position within a rectangle.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="minLimit">Vertex that defines the negative boundary of the rectangle area.</param>
		/// <param name="maxLimit">Vertex that defines the positive boundary of the rectangle area.</param>
		/// <returns>Random Vector2.</returns>
		public static Vector2 RectanglePosition(Vector2 minLimit, Vector2 maxLimit)
		{
			float x = NextFloat(minLimit.x, maxLimit.x, 4);
			float y = NextFloat(minLimit.y, maxLimit.y, 4);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Returns a random position within a rectangle.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="origin">Center of the rectangle.</param>
		/// <param name="semiWidth">Semiwidth of the rectangle, starting from center.</param>
		/// <param name="semiHeight">Semiheight of the rectangle, starting from center.</param>
		/// <returns>Random Vector2.</returns>
		public static Vector2 RectanglePosition(Vector2 origin, float semiWidth, float semiHeight)
		{
			Vector2 leftDown = new Vector2(origin.x - semiWidth, origin.y - semiHeight);
			Vector2 rightUp = new Vector2(origin.x + semiWidth, origin.y + semiHeight);
			return RectanglePosition(leftDown, rightUp);
		}

		/// <summary>
		/// Returns a random position within a cuboid.
		/// </summary>
		/// <param name="minLimit">Vertex that defines the negative boundary of the cuboid area.</param>
		/// <param name="maxLimit">Vertex that defines the positive boundary of the cuboid area.</param>
		/// <returns>Random Vector3.</returns>
		public Vector3 cuboidPosition(Vector3 minLimit, Vector3 maxLimit)
		{
			float x = nextFloat(minLimit.x, maxLimit.x, 4);
			float y = nextFloat(minLimit.y, maxLimit.y, 4);
			float z = nextFloat(minLimit.z, maxLimit.z, 4);
			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Returns a random position within a cuboid.
		/// </summary>
		/// <param name="origin">Center of the cuboid.</param>
		/// <param name="semiWidth">Semiwidth of the cuboid, starting from center.</param>
		/// <param name="semiHeight">Semiheight of the cuboid, starting from center.</param>
		/// <param name="semiDepth">Semihdepth of the cuboid, starting from center.</param>
		/// <returns>Random Vector3.</returns>
		public Vector3 cuboidPosition(Vector3 origin, float semiWidth, float semiHeight, float semiDepth)
		{
			Vector3 leftDownBack = new Vector3(origin.x - semiWidth, origin.y - semiHeight, origin.z - semiDepth);
			Vector3 rightUpFront = new Vector3(origin.x + semiWidth, origin.y + semiHeight, origin.z + semiDepth);
			return cuboidPosition(leftDownBack, rightUpFront);
		}

		/// <summary>
		/// Returns a random position within a cuboid.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="minLimit">Vertex that defines the negative boundary of the cuboid area.</param>
		/// <param name="maxLimit">Vertex that defines the positive boundary of the cuboid area.</param>
		/// <returns>Random Vector3.</returns>
		public static Vector3 CuboidPosition(Vector3 minLimit, Vector3 maxLimit)
		{
			float x = NextFloat(minLimit.x, maxLimit.x, 4);
			float y = NextFloat(minLimit.y, maxLimit.y, 4);
			float z = NextFloat(minLimit.z, maxLimit.z, 4);
			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Returns a random position within a cuboid.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="origin">Center of the cuboid.</param>
		/// <param name="semiWidth">Semiwidth of the cuboid, starting from center.</param>
		/// <param name="semiHeight">Semiheight of the cuboid, starting from center.</param>
		/// <param name="semiDepth">Semihdepth of the cuboid, starting from center.</param>
		/// <returns>Random Vector3.</returns>
		public static Vector3 CuboidPosition(Vector3 origin, float semiWidth, float semiHeight, float semiDepth)
		{
			Vector3 leftDownBack = new Vector3(origin.x - semiWidth, origin.y - semiHeight, origin.z - semiDepth);
			Vector3 rightUpFront = new Vector3(origin.x + semiWidth, origin.y + semiHeight, origin.z + semiDepth);
			return CuboidPosition(leftDownBack, rightUpFront);
		}

		#endregion

		/*****     Non-Uniform Number    *****/
		#region Non-Uniform

		/// <summary>
		/// Returns a random value from a Standard Normal Distribution
		/// <br>using Marsaglia Polar Method.</br> 
		/// </summary>
		/// <returns>Random floating point.</returns>
		public float standardNormalDistribuitionNumber()
		{
			//A normal distribution with a mean of 0 and a standard deviation of 1 
			//is called Standard Normal Distribution.

			//Sorteia um par (X, Y) enquanto S for >= 1
			float x = -1, y = -1, s = 1;
			while (s >= 1)
			{
				x = nextFloat(-1f, 1f, 4);
				y = nextFloat(-1f, 1f, 4);
				s = (x * x) + (y * y);//hipotenusa²
			}
			//sqrt(-2 * Log e(s)/s)
			float sq = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
			if (nextBool())
			{ return x * sq; }
			else
			{ return y * sq; }
		}

		/// <summary>
		/// Returns a random value from a Standard Normal Distribution using
		/// <br>Marsaglia Polar Method. This method uses global RNG.</br> 
		/// </summary>
		/// <returns>Random floating point.</returns>
		public static float StandardNormalDistribuitionNumber()
		{
			//Sorteia um par (X, Y) enquanto S for >= 1
			float x = -1, y = -1, s = 1;
			while (s >= 1)
			{
				x = NextFloat(-1f, 1f, 4);
				y = NextFloat(-1f, 1f, 4);
				s = (x * x) + (y * y);//hipotenusa²
			}
			//sqrt(-2 * Log e(s)/s)
			float sq = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
			if (NextBool())
			{ return x * sq; }
			else
			{ return y * sq; }
		}

		/// <summary>
		/// Returns a number from Normal Distribution, in range [min, max] (inclusive).
		/// <br>The mean value is equal to "(max + min) / 2".</br>
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff. Lower it is, 
		/// higher the standard deviation is 
		/// (spreader from mean the result may be).</param>
		/// <returns>A random value within a Normal Distribuition.</returns>
		public float normalDistributionRange(float min, float max, float cutOff = 3)
		{
			//Calcula a média, baseada no intervalo [min, max] inclusivo
			float mean = 0.5f * (min + max);
			//Cálculo do desvio padrão dividido pelo fator de corte (aumenta ou diminui)
			float sigma = (max - mean) / cutOff;
			//Pega um valor aleatório de uma distribuição normal
			float rand = standardNormalDistribuitionNumber();
			//Transforma a distribuição criada: valor original vem com a média posicinada em 0, e desvio padrão de 1
			//Reposicina a "média" para a média escolhida (mean) e 
			//escala o desvio padrão (1) com o valor desejado (sigma)
			rand = (rand * sigma) + mean;
			//Retorna o valor sorteado e transformado de uma "curva do sino", 
			//ajustado dentro do intervalo [min, max] inclusivo
			return Mathf.Clamp(rand, min, max);
		}

		/// <summary>
		/// Returns a number from Normal Distribution, 
		/// in range [min, max] (inclusive). The mean value
		/// <br> is equal to "(max + min) / 2". This method uses global RNG.</br>
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff. Lower it is, 
		/// higher the standard deviation is 
		/// (spreader from mean the result may be).</param>
		/// <returns>A random value within a Normal Distribuition.</returns>
		public static float NormalDistributionRange(float min, float max, float cutOff = 3)
		{
			//Calcula a média, baseada no intervalo [min, max] inclusivo
			float mean = 0.5f * (min + max);
			//Cálculo do desvio padrão dividido pelo fator de corte (aumenta ou diminui)
			float sigma = (max - mean) / cutOff;
			//Pega um valor aleatório de uma distribuição normal
			float rand = StandardNormalDistribuitionNumber();
			//Transforma a distribuição criada: valor original vem com a média posicinada em 0, e desvio padrão de 1
			//Reposicina a "média" para a média escolhida (mean) e 
			//escala o desvio padrão (1) com o valor desejado (sigma)
			rand = (rand * sigma) + mean;
			//Retorna o valor sorteado e transformado de uma "curva do sino", 
			//ajustado dentro do intervalo [min, max] inclusivo
			return Mathf.Clamp(rand, min, max);
		}

		/*****     Non-Uniform Vector    *****/

		/// <summary>
		/// Returns a random Vector2 from a Standard Normal Distribuition.
		/// </summary>
		/// <returns>Random Vector2.</returns>
		public Vector2 standardNormalDistribuition2D()
		{
			float x = -1, y = -1, s = 1;
			while (s >= 1)
			{
				x = nextFloat(-1f, 1f, 4);
				y = nextFloat(-1f, 1f, 4);
				s = (x * x) + (y * y);
			}

			float sq = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
			return new Vector2(x * sq, y * sq);
		}

		/// <summary>
		/// Returns a Vector2 from a Standard Normal Distribuition.
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <returns>Random Vector2.</returns>
		public static Vector2 StandardNormalDistribuition2D()
		{
			float x = -1, y = -1, s = 1;
			while (s >= 1)
			{
				x = NextFloat(-1f, 1f, 4);
				y = NextFloat(-1f, 1f, 4);
				s = (x * x) + (y * y);
			}

			float sq = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
			return new Vector2(x * sq, y * sq);
		}

		/// <summary>
		/// Generates a Vector2 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector2 format.</returns>
		public Vector2 normalDistributionRange2D(Vector2 min, Vector2 max, float cutOff = 3)
		{
			float x = normalDistributionRange(min.x, max.x, cutOff);
			float y = normalDistributionRange(min.y, max.y, cutOff);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Generates a Vector2 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector2 format.</returns>
		public static Vector2 NormalDistributionRange2D(Vector2 min, Vector2 max, float cutOff = 3)
		{
			float x = NormalDistributionRange(min.x, max.x, cutOff);
			float y = NormalDistributionRange(min.y, max.y, cutOff);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Generates a Vector2 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff split in X and Y. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector2 format.</returns>
		public Vector2 normalDistributionRange2D(Vector2 min, Vector2 max, Vector2 cutOff)
		{
			float x = normalDistributionRange(min.x, max.x, cutOff.x);
			float y = normalDistributionRange(min.y, max.y, cutOff.y);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Generates a Vector2 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff split in X and Y. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector2 format.</returns>
		public static Vector2 NormalDistributionRange2D(Vector2 min, Vector2 max, Vector2 cutOff)
		{
			float x = NormalDistributionRange(min.x, max.x, cutOff.x);
			float y = NormalDistributionRange(min.y, max.y, cutOff.y);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Generates a Vector3 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector3 format.</returns>
		public Vector3 normalDistributionRange3D(Vector3 min, Vector3 max, float cutOff = 3)
		{
			float x = normalDistributionRange(min.x, max.x, cutOff);
			float y = normalDistributionRange(min.y, max.y, cutOff);
			float z = normalDistributionRange(min.z, max.z, cutOff);
			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Generates a Vector3 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector3 format.</returns>
		public static Vector3 NormalDistributionRange3D(Vector3 min, Vector3 max, float cutOff = 3)
		{
			float x = NormalDistributionRange(min.x, max.x, cutOff);
			float y = NormalDistributionRange(min.y, max.y, cutOff);
			float z = NormalDistributionRange(min.z, max.z, cutOff);
			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Generates a Vector3 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff spit in X, Y and Z. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector3 format.</returns>
		public Vector3 normalDistributionRange3D(Vector3 min, Vector3 max, Vector3 cutOff)
		{
			float x = normalDistributionRange(min.x, max.x, cutOff.x);
			float y = normalDistributionRange(min.y, max.y, cutOff.y);
			float z = normalDistributionRange(min.z, max.z, cutOff.z);
			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Generates a Vector3 from a Normal Distribution, 
		/// in range [min, max] (inclusive).
		/// <br>This method uses global RNG.</br>
		/// </summary>
		/// <param name="min">Minimum value possible.</param>
		/// <param name="max">Maximum value possible.</param>
		/// <param name="cutOff">Deviation cutOff spit in X, Y and Z. Lower it is, 
		/// spreader from mean the result may be.</param>
		/// <returns>A value in Vector3 format.</returns>
		public static Vector3 NormalDistributionRange3D(Vector3 min, Vector3 max, Vector3 cutOff)
		{
			float x = NormalDistributionRange(min.x, max.x, cutOff.x);
			float y = NormalDistributionRange(min.y, max.y, cutOff.y);
			float z = NormalDistributionRange(min.z, max.z, cutOff.z);
			return new Vector3(x, y, z);
		}

		#endregion
	}
}