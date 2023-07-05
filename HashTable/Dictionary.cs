using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public  class Dictionary <Tkey, TValue> where Tkey: class
    {
        KeyValuePair[] enteries;
        int InitialSize;
        int enteriesCount;

        public Dictionary()
        {
            this.InitialSize = 3;
            this.enteriesCount = 0;
            this.enteries = new KeyValuePair[this.InitialSize];
        }
        // Create 5 Functions ( ResizeOrNot-Size - Set - Get - Remove - Print )

        public void ResizeOrNot()
        {
            if (this.enteriesCount < this.enteries.Length) return;
            int NewSize = this.InitialSize + this.enteries.Length;
            Console.WriteLine($"Resized From {this.enteries.Length} to {NewSize}");

            KeyValuePair[] NewArray = new KeyValuePair[NewSize];
            Array.Copy(this.enteries , NewArray , this.enteries.Length);
            this.enteries = NewArray;

        }
        public int Size()
        {
            return this.enteriesCount;
        }

        public void Set (Tkey key , TValue value)
        {
            for (int i = 0; i < this.enteries.Length-1; i++)
            {
                if (this.enteries[i] != null && this.enteries[i].Key == key)
                {
                    this.enteries[i].Value = value;
                    return;
                }
            }
            this.ResizeOrNot();
            KeyValuePair NewPair = new KeyValuePair(key, value);
            this.enteries[this.enteriesCount] = NewPair;
            this.enteriesCount++;
        }
        public TValue Get(Tkey key)
        {
            for (int i = 0; i < this.enteries.Length; i++)
            {
                if (this.enteries[i] != null && this.enteries[i].Key == key)
                {
                    return this.enteries[i].Value;
                }
            }
            return default;
        }

        public bool Remove (Tkey key)
        {
            for(int i = 0; i < this.enteries.Length; i++)
            {
                if (this.enteries[i] != null && this.enteries[i].Key == key)
                {
                    this.enteries[i] = this.enteries[enteriesCount - 1];
                    this.enteries[enteriesCount - 1] = null;
                    this.enteriesCount--;
                    return true; 
                }
            }
            return false; 
        }
        public void Print()
        {
            Console.WriteLine("----------");
            Console.WriteLine("[size] " + this.Size());
            for (int i = 0; i < this.enteries.Length; i++)
            {
                if (this.enteries[i] == null)
                {
                    Console.WriteLine("[" + i + "]");
                    continue;
                }
                else
                {
                    Console.WriteLine("[" + i + "]" + this.enteries[i].Key
                      + ":" + this.enteries[i].Value);
                }
            }
            Console.WriteLine("==========");
        }

        class KeyValuePair
        {
            private Tkey _key;
            private TValue _value;

            public Tkey Key
            {
                get { return _key; }
            }
            public TValue Value
            {
                get { return _value; }
                set { _value = value; }
            }
            public KeyValuePair(Tkey key, TValue val)
            {
                _key = key;
                _value = val;
            }
        }
    }
    
}
