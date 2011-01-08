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

using Gremlin.FB2Librarian.Import.Utils;

namespace Gremlin.FB2Librarian.Import
{
    public interface IMetrizable<T>
    {
        int DistanceTo(T other);
    }

    public delegate int DistanceComparer<T1, T2>(T1 x, T2 y);

    public abstract class Node<T> : IEnumerable<T> where T : class, IMetrizable<T>
    {
        private readonly IList<T> values;
        private readonly Dictionary<int, Node<T>> children;
        private readonly Node<T> parent;

        protected Node(IEnumerable<T> items, Node<T> parent)
        {
            this.parent = parent;
            this.values = new List<T>();
            this.children = new Dictionary<int, Node<T>>();

            if (items != null)
            {
                BuildTree(items);
            }
        }

        private void BuildTree(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Insert(item);
            }
        }

        public IList<T> RangeSearch(T item, int min, int max)
        {
            List<T> result = new List<T>();
            Stack<Node<T>> candidates = new Stack<Node<T>>(new[] { this });
            while (candidates.Count > 0)
            {
                Node<T> node = candidates.Pop();
                int distance = node.DistanceTo(item);
                if (distance >= min && distance <= max)
                {
                    result.AddRange(node.values);
                }

                foreach (Node<T> child in new Iterator<Node<T>>(node.GetChildCandidates(distance, min, max)))
                {
                    candidates.Push(child);
                }
            }

            return result;
        }

        public IList<T> RangeSearch<R>(R item, DistanceComparer<T, R> comparer, int min, int max)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            List<T> result = new List<T>();
            Stack<Node<T>> candidates = new Stack<Node<T>>(new[] { this });
            while (candidates.Count > 0)
            {
                Node<T> node = candidates.Pop();
                int distance = node.DistanceTo(item, comparer);
                if (distance >= min && distance <= max)
                {
                    result.AddRange(node.values);
                }

                foreach (Node<T> child in new Iterator<Node<T>>(node.GetChildCandidates(distance, min, max)))
                {
                    candidates.Push(child);
                }
            }

            return result;
        }

        public IList<T> Values
        {
            get
            {
                return values;
            }
        }

        public IDictionary<int, Node<T>> Children
        {
            get
            {
                return children;
            }
        }

        public Node<T> Parent
        {
            get
            {
                return this.parent;
            }
        }

        public int DistanceTo(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (values.Count == 0)
            {
                throw new InvalidOperationException("Node is empty.");
            }

            return values[0].DistanceTo(item);
        }

        public int DistanceTo<T2>(T2 item, DistanceComparer<T, T2> comparer)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            if (values.Count == 0)
            {
                throw new InvalidOperationException("Node is empty.");
            }

            return comparer(values[0], item);
        }

        public abstract void Insert(T item);
        public abstract IEnumerator<Node<T>> GetChildCandidates(int distance, int min, int max);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T value in values)
            {
                yield return value;
            }

            foreach (Node<T> tree in children.Values)
            {
                foreach (T value in tree)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BKTree<T> : Node<T> where T : class, IMetrizable<T>
    {
        public BKTree(IEnumerable<T> items, Node<T> parent)
            : base(items, parent)
        {
        }

        public override void Insert(T item)
        {
            if (Values.Count == 0)
            {
                Values.Add(item);
                return;
            }

            Node<T> node = this;
            while (true)
            {
                int distance = node.DistanceTo(item);
                if (distance == 0)
                {
                    node.Values.Add(item);
                    break;
                }

                Node<T> child = null;
                if (!node.Children.TryGetValue(distance, out child))
                {
                    child = new BKTree<T>(new[] { item }, node);
                    node.Children[distance] = child;
                    break;
                }

                node = child;
            }
        }

        public override IEnumerator<Node<T>> GetChildCandidates(int distance, int min, int max)
        {
            foreach (KeyValuePair<int, Node<T>> pair in Children)
            {
                if (pair.Key >= (distance - max) && pair.Key <= (distance + max))
                {
                    yield return pair.Value;
                }
            }
        }
    }
}