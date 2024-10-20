using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.Pooling
{
	/// <summary>
	/// Class of Object Pooling. Each instance contains a different pool.
	/// </summary>
	public class ObjectPooler<T> where T : MonoBehaviour, IPoolableObject
	{
		private Dictionary<int, T> pool = new Dictionary<int, T>();

		/// <summary>
		/// Prefab to be cloned.
		/// </summary>
		public T prefab { get; private set; }
		/// <summary>
		/// Parent object in scene that hold all pool's object
		/// </summary>
		public Transform poolParent { get; private set; }
		/// <summary>
		/// Current number of elements in pool.
		/// </summary>
		public int currentSize { get { return pool.Count; } }
		/// <summary>
		/// Can pool increase in size?
		/// </summary>
		public bool canResize { get; private set; }

		/// <summary>
		/// Constructor for later startup of the pool.
		/// </summary>
		/// <param name="prefab">Prefab to be cloned.</param>
		/// <param name="canResize">Pool could grow in the future.</param>
		/// <param name="poolParent">Parent to hold pool's objects.</param>
		public ObjectPooler(T prefab, bool canResize = false, Transform poolParent = null)
		{
			this.prefab = prefab;
			this.canResize = canResize;
			this.poolParent = poolParent;
		}

		/// <summary>
		/// Constructor to initialize pool immediately.
		/// </summary>
		/// <param name="prefab">Prefab to be cloned.</param>
		/// <param name="startSize">Initial pool size (min. value is 1).</param>
		/// <param name="canResize">Pool could grow in the future.</param>
		/// <param name="poolParent">Parent to hold pool's objects.</param>
		public ObjectPooler(T prefab, int startSize, Vector2 startPosition, 
			bool canResize = false, Transform poolParent = null)
		{
			this.prefab = prefab;
			this.canResize = canResize;
			this.poolParent = poolParent;
			CreatePool(startSize, startPosition);
		}

		/// <summary>
		/// Initialize objects, within a clear pool, out of screen.
		/// </summary>
		/// <param name="size">Number of objects to initialize. Can't be greater than "maxSize".</param>
		/// <param name="active">Set objects to run Start().</param>
		public void CreatePool(int size, Vector2 position)
		{
			if (currentSize > 0)
			{ PrintConsole.Error("Can't initialize a pool already in use"); return; }

			size = (size < 1) ? 1 : size;

			T n;
			for (int i = 0; i < size; ++i)
			{
				Vector3 p = position;
				p.z = prefab.transform.position.z;
				n = MonoBehaviour.Instantiate(prefab, p, Quaternion.identity, poolParent);

				n.Deactivate();

				n.poolIndex = pool.Count;
				pool.Add(n.poolIndex, n);
			}
		}

		/// <summary>
		/// Destroys all elements and clear the pool.
		/// </summary>
		public void DeletePool()
		{
			T t = null;
			for (int i = pool.Count; i >= 0; --i)
			{
				if (pool.TryGetValue(i, out t))
				{
					MonoBehaviour.Destroy(t.gameObject);
				}
			}
			pool.Clear();
		}

		/// <summary>
		/// Add new element, considering an expansion of the pool.
		/// </summary>
		/// <returns>Returns the new element.</returns>
		T Add()
		{
			if(!canResize)
			{ return null; }
			
			T n = MonoBehaviour.Instantiate(prefab, poolParent);
			n.Deactivate();

			n.poolIndex = pool.Count;
			pool.Add(n.poolIndex, n);
			return n;
		}

		/// <summary>
		/// Get first available element in the pool.
		/// </summary>
		/// <returns></returns>
		public T GetObject()
		{
			if (currentSize == 0)
			{ PrintConsole.Error("Empty pool"); return null; }

			T t = null;
			for (int i = 0; i < pool.Count; ++i)
			{
				if (!pool[i].activeInScene)
				{ t = pool[i]; break; }
			}

			if (t == null)
			{ t = Add(); }
			return t;
		}

		/// <summary>
		/// Get a specific element from the pool, if it's available.
		/// </summary>
		/// <param name="index">Element index in the pool.</param>
		/// <returns></returns>
		public T GetObject(int index)
		{
			if (index < 0 || index > currentSize - 1)
			{ PrintConsole.Error("Index out of range"); return null; }
			if (currentSize == 0)
			{ PrintConsole.Error("Empty pool"); return null; }

			T t;
			if (pool.ContainsKey(index))
			{
				if (pool.TryGetValue(index, out t))
				{ return t; }
			}
			PrintConsole.Error("Enable to find index/object");
			return null;
		}

		/// <summary>
		/// Return pool as array.
		/// </summary>
		/// <returns></returns>
		public T[] AsArray()
		{
			T[] t = new T[pool.Count];

			for (int i = 0; i < pool.Count; ++i)
			{ t[i] = GetObject(i); }

			return t;
		}
	}
}