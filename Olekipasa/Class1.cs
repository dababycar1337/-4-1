using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace App5
{
    class Onedimensional<T>
    {
        private T[] _array;
        private int _capacity;
        private int _size;

        public Onedimensional(int capacity)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _size = 0;
        }

        public Onedimensional() : this(7)
        {
        }

        public void Add(T item)
        {
            if (_size >= _capacity)
            {
                _capacity = _capacity * 2 + 1;
                Array.Resize(ref _array, _capacity);
              
            }
            _array[_size] = item;
            _size++;
        }

        public void Remove(T item, Func<T, T, bool> deleg)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("В массиве ничего нет");
            }
            T[] newArray = new T[_size];
            int mark = 0;
            for(int i = 0; i < _size; i++)
            {
                if (!deleg(item, _array[i]))
                {
                    newArray[i] = _array[i];
                }
                else
                {
                    mark = i;
                }
            }
            Array.Copy(newArray, 0, _array, 0, _size - 1);
            for (int i = mark; i < _size; i++)
            {
                _array[i] = _array[i + 1];
            }
            _size--;

        }

        public void Reverse()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("В массиве ничего нет");
            }
            //Array.Reverse(_array);
            T[] newArray = new T[_capacity];
            for(int i = _size - 1; i >= 0; i--)
            {
                newArray[i] = _array[_size - i - 1];
            }
            Array.Copy(newArray, 0, _array, 0, _size);
        }

        public T[] ByCondition(Func<T, bool> condition)
        {
            T[] newArray = new T[_size];
            int count = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (condition(_array[i]))
                {
                    newArray[count] = _array[i];
                    count++;
                }
            }
            Array.Resize(ref newArray, count);
            return newArray;
        } 

        public void ActionForAll(Func<T, T> condition)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("В массиве ничего нет");
            }

            T[] newArray = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                _array[i] = condition(_array[i]);
            }

            for(int i = 0; i < _size; i++)
            {
                Console.Write(_array[i] + " ");
            }
            Console.WriteLine("");
        }

        
        public bool ConditionForOne(Func<T, bool> condition)
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("В массиве ничего нет");
            }
            T[] newArray = ByCondition(condition);
            if (newArray.Length > 0)
            {
                return true;
            }
            return false;
        }

        public bool ConditionForAll(Func<T, bool> condition)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("В массиве ничего нет");
            }
            T[] newArray = ByCondition(condition);
            if (newArray.Length == _size)
            {
                return true;
            }
            return false;
        }

        public int Size()
        {
            return _size;
        }

        public int AmountByCondition(Func<T, bool> condition)
        {
            T[] newArray = ByCondition(condition);
            return newArray.Length;
        }

        public void Print()
        {
            for(int i = 0; i < _size; i++)
            {
                Console.Write(_array[i] + " ");
            }
            Console.WriteLine("");
        }
    }
}
