using System;

namespace Utility.Pooling
{
	[Serializable]
	public class PoolEntry<T> where T : IPoolableObject
	{
		public string name;
		public T prefab;
		public int startSize;
	}
}