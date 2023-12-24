using System;
using System.Collections.Generic;

namespace GrayHoodT.Pool
{
    public class Pooler<T> : IDisposable, IPooler<T> where T : class
    {
        #region Fields

        private readonly int maxSize;
        private readonly bool isInitiallyCreated;
        private readonly bool isCollectionCheck;

        private readonly List<T> borrowedList;
        private readonly List<T> returnedList;

        #endregion

        #region Properties

        public int AllCount { get; private set; }
        public int BorrowedCount => borrowedList.Count;
        public int ReturnedCount => returnedList.Count;

        #endregion

        #region Events

        private readonly Func<T> created;
        private readonly Action<T> got;
        private readonly Action<T> released;
        private readonly Action<T> destroyed;

        #endregion

        #region Constructors

        public Pooler(Func<T> createCall, Action<T> gotCall = null, Action<T> releasedCall = null, Action<T> destroyedCall = null, bool isCollectionCheck = true, int defaultCapacity = 10, int maxSize = 10000, bool isInitiallyCreated = false)
        {
            if (createCall == null)
                throw new ArgumentNullException("createFunc");

            if (maxSize <= 0)
                throw new ArgumentException("Max Size must be greater than 0", "maxSize");

            this.maxSize = maxSize;
            this.isInitiallyCreated = isInitiallyCreated;
            this.isCollectionCheck = isCollectionCheck;

            borrowedList = new List<T>(defaultCapacity);
            returnedList = new List<T>(defaultCapacity);
            created = createCall;
            got = gotCall;
            released = releasedCall;
            destroyed = destroyedCall;

            if(this.isInitiallyCreated == true)
            {
                for(var i = 0; i < defaultCapacity; i++)
                {
                    T value = created();
                    returnedList.Add(value);
                    AllCount++;
                }
            }
        }

        #endregion

        #region Public Methods

        public T Take()
        {
            T value;
            if (returnedList.Count == 0)
            {
                value = created();
                AllCount++;
            }
            else
            {
                int index = returnedList.Count - 1;
                value = returnedList[index];
                returnedList.RemoveAt(index);
            }

            borrowedList.Add(value);
            got?.Invoke(value);
            return value;
        }

        public bool Take(out T value)
        {
            value = Take();
            return value != null;
        }

        public void Return()
        {
            foreach(T element in borrowedList)
            {
                borrowedList.Remove(element);
                released?.Invoke(element);
                
                if (BorrowedCount < maxSize)
                    returnedList.Add(element);
                else
                    destroyed?.Invoke(element);
            }
        }

        public void Return(T element)
        {
            if (isCollectionCheck)
            {
                bool isAlreadyReleased = (returnedList.Contains(element) == true && returnedList.Count > 0) && (borrowedList.Contains(element) == false && borrowedList.Count > 0);
                
                if (isAlreadyReleased == true)
                    throw new InvalidOperationException("Trying to release an object that has already been released to the pool.");
            }

            borrowedList.Remove(element);
            released?.Invoke(element);

            if (BorrowedCount < maxSize)
                returnedList.Add(element);
            else
                destroyed?.Invoke(element);
        }

        public void Clear()
        {
            if(destroyed != null)
            {
                foreach (T element in borrowedList)
                {
                    destroyed(element);
                }

                foreach(T element in returnedList)
                {
                    destroyed(element);
                }
            }

            borrowedList.Clear();
            returnedList.Clear();
            AllCount = 0;
        }

        #endregion

        public void Dispose()
        {
            Clear();
        }
    }
}

