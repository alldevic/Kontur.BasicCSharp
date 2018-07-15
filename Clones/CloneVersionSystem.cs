using System;
using System.Collections.Generic;

namespace Clones
{
    public class CloneVersionSystem : ICloneVersionSystem
    {
        List<Clone> clones = new List<Clone>(new[] {new Clone(1)});

        public string Execute(string query)
        {
            var parsed = query.Split();

            switch (parsed[0])
            {
                case "learn":
                {
                    var t = Convert.ToInt32(parsed[1]);
                    if (!clones.Exists(x => x.Id == t)) clones.Add(new Clone(t));
                    return clones[t - 1].Learn(parsed[2]);
                }
                case "rollback": return clones[Convert.ToInt32(parsed[1]) - 1].Rollback();
                case "relearn": return clones[Convert.ToInt32(parsed[1]) - 1].Relearn();
                case "clone":
                {
                    clones.Add(clones[Convert.ToInt32(parsed[1]) - 1].CloneCmd(clones.Count + 1));
                    return null;
                }
                case "check": return clones[Convert.ToInt32(parsed[1]) - 1].Check();
            }

            return null;
        }
    }


    class Clone
    {
        private LinkedStack<string> learned;
        private LinkedStack<string> history;
        private bool isRollbacked;
        public int Id { get; }

        public Clone(int id)
        {
            learned = new LinkedStack<string>();
            history = new LinkedStack<string>();
            isRollbacked = false;
            Id = id;
        }

        public string Learn(string program)
        {
            if (isRollbacked)
            {
                history.Clear();
                isRollbacked = false;
            }

            learned.Push(program);
            return null;
        }

        public string Rollback()
        {
            history.Push(learned.Pop());
            isRollbacked = true;
            return null;
        }

        public Clone CloneCmd(int newId) => new Clone(newId)
        {
            isRollbacked = isRollbacked,
            learned = LinkedStack<string>.Clone(learned),
            history = LinkedStack<string>.Clone(history)
        };

        public string Relearn()
        {
            learned.Push(history.Pop());
            return null;
        }

        public string Check() => learned.Count == 0 ? "basic" : learned.Peek();
    }

    class StackItem<T>
    {
        public StackItem<T> Prev { get; set; }
        public T Value { get; set; }
    }

    class LinkedStack<T>
    {
        public int Count { get; private set; }
        private StackItem<T> head;
        public bool IsEmpty => head == null;

        public void Push(T value)
        {
            var t = new StackItem<T>
            {
                Value = value,
                Prev = head
            };

            head = t;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException();
            var res = head.Value;
            head = head.Prev;
            Count--;
            return res;
        }

        public T Peek() => (IsEmpty) ? throw new InvalidOperationException() : head.Value;

        public void Clear() => head = null;

        public static LinkedStack<T> Clone(LinkedStack<T> source) => new LinkedStack<T>()
        {
            Count = source.Count,
            head = source.head,
        };
    }
}