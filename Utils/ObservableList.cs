// Copyright 2008-2010 Andrej Repin aka Gremlin2
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gremlin.FB2Librarian.Import.Utils
{
    internal enum NotifyListChangedAction
    {
        Added,
        Removed,
        Replaced,
        Cleared
    }

    internal class NotifyListChangedEventArgs<T> : EventArgs
    {
        private readonly NotifyListChangedAction action;
        private readonly T item;

        public NotifyListChangedEventArgs(NotifyListChangedAction action)
        {
            this.action = action;
        }

        public NotifyListChangedEventArgs(NotifyListChangedAction action, T item)
        {
            this.action = action;
            this.item = item;
        }

        public NotifyListChangedAction Action
        {
            get
            {
                return this.action;
            }
        }

        public T Item
        {
            get
            {
                return this.item;
            }
        }
    }

    internal delegate void NotifyListChangedEventHandler<T>(object sender, NotifyListChangedEventArgs<T> e);

    internal class ObservableList<T> : IList<T>
    {
        private readonly IList<T> innerList;

        public event NotifyListChangedEventHandler<T> ListChanged;

        public ObservableList()
        {
            this.innerList = new List<T>();
        }

        public ObservableList(IList<T> innerList)
        {
            if (innerList == null)
            {
                throw new ArgumentNullException("innerList");
            }

            this.innerList = innerList;
        }

        public ObservableList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.innerList = new List<T>(collection);
        }

        protected virtual void OnListChanged(NotifyListChangedEventArgs<T> e)
        {
            if(ListChanged != null)
            {
                ListChanged(this, e);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in innerList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            this.innerList.Add(item);
            OnListChanged(new NotifyListChangedEventArgs<T>(NotifyListChangedAction.Added, item));
        }

        public void Clear()
        {
            this.innerList.Clear();
            OnListChanged(new NotifyListChangedEventArgs<T>(NotifyListChangedAction.Cleared));
        }

        public bool Contains(T item)
        {
             return this.innerList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.innerList.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if(this.innerList.Remove(item))
            {
                OnListChanged(new NotifyListChangedEventArgs<T>(NotifyListChangedAction.Removed, item));
                return true;
            }

            return false;
        }

        public int Count
        {
            get
            {
                return this.innerList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.innerList.IsReadOnly;
            }
        }

        public int IndexOf(T item)
        {
            return this.innerList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.innerList.Insert(index, item);
            OnListChanged(new NotifyListChangedEventArgs<T>(NotifyListChangedAction.Added, item));
        }

        public void RemoveAt(int index)
        {
            T item = this.innerList[index];
            this.innerList.RemoveAt(index);
            OnListChanged(new NotifyListChangedEventArgs<T>(NotifyListChangedAction.Removed, item));
        }

        public T this[int index]
        {
            get
            {
                 return this.innerList[index];
            }
            set
            {
                this.innerList[index] = value;
                OnListChanged(new NotifyListChangedEventArgs<T>(NotifyListChangedAction.Replaced, value));
            }
        }
    }
}
