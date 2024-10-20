namespace Utility.Pooling
{
	/// <summary>
	/// Interface for implementing poolable objects
	/// </summary>
	public interface IPoolableObject
	{
		int poolIndex { get; set; }
		bool activeInScene { get; }

		/// <summary></summary>
		/// <param name="duration">When minor or equal to 0, time counter isn't triggered.</param>
		void Activate(float duration);
		void Deactivate();
	}
}