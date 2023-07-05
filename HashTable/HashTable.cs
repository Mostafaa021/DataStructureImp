using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
     
    public class HashTable<Tkey, TValue> where Tkey : class
    {
        KeyValuePair[] enteries;
        int InitialSize;
        int enteriesCount;

        public HashTable()
        {
            this.InitialSize = 3; // if starting with prime number possibality to collision  happen is low
            this.enteriesCount = 0;
            this.enteries = new KeyValuePair[this.InitialSize];
        }
         int Hash(Tkey key)
        {
            uint FNVOffsetBasis = 2166136261; // Constant for 32bit
            uint FNVPrime = 16777619;// Constatant of FNVPrime for 32 bit 
            byte [] data = Encoding.ASCII.GetBytes(key.ToString()); // array of bytes
            // FNV-1a Hashing Algorithm Implmentation
            uint hash = FNVOffsetBasis;
            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }
            Console.WriteLine(" Hashing as Following => "+ key.ToString() 
                +","+ hash + " " + hash.ToString("x") +"," + hash % (uint)this.enteries.Length ); // hash.ToString("x") => from int to hexadecimal
            return (int)(hash % (uint)this.enteries.Length);
        }

         int CollisionHandling(Tkey key , int hash , bool Set)
        {
            int NewHash;
            for (int i = 1; i < this.enteries.Length; i++)
            {
                NewHash = (hash + i) % this.enteries.Length;
                Console.WriteLine("[coll] " + key.ToString()
                 + " " + hash + ", new hash: " + NewHash);
                if (Set && (this.enteries[NewHash]==null || this.enteries[NewHash].Key==key))
                {
                    return NewHash;
                }
                else if(!Set && this.enteries[NewHash].Key == key)
                {
                    return NewHash;
                }
            }
            return -1;
        }
         void AddtoEntries(Tkey key , TValue value) // Part of Set Implmentation
          {
            int index =this.Hash(key);
            if (this.enteries[index] != null && this.enteries[index].Key != key )
            {
                index = this.CollisionHandling(key, index, true);
            }
            if (index == -1)
                throw new Exception("Invalid HashTable!!");
            if (this.enteries[index] == null)
            {
                KeyValuePair keyValuePair = new KeyValuePair(key, value);
                this.enteries[index] = keyValuePair;
                this.enteriesCount++;
            }
            else if (this.enteries[index].Key == key)
            {
                this.enteries[index].Value = value;
            }
            else
                throw new Exception("Invalid HashTable!!");

         }
         void ResizeOrNot()
        {
            if (this.enteriesCount < this.enteries.Length) return; // if not Resizing Will Happen 
            // If Resizing will Occurs
            int NewSize = this.enteries.Length * 2;
            Console.WriteLine($"Resized From {this.enteries.Length} to {NewSize}");
            KeyValuePair [] entriesCopy = new KeyValuePair [this.enteries.Length]; // Make Array with the same length 
            Array.Copy(this.enteries, entriesCopy, entriesCopy.Length);// Copy Arrays element to enteries copy 
            this.enteries = new KeyValuePair[NewSize]; // let enteries array be with the new size and garbage collector will remove old elements
            this.enteriesCount = 0; 
            for (int i = 0; i < entriesCopy.Length; i++)  // Rehashing Every Element in Array 
            {
                if (entriesCopy[i] == null) continue;
                this.AddtoEntries(entriesCopy[i].Key, entriesCopy[i].Value); // this Function will be responsible for Rehashing and collision handling
            }
        }

        public void Set (Tkey key , TValue value)
        {
            // here we implement each function outside to solve Problem of Circular Dependency (like Recursion)
            // Set Call ResizeOrNot and AddtoEnteries functions , ResizeOrNot Call AddToEnteries , AddtoEnteries not call any one of them 
            this.ResizeOrNot();
            this.AddtoEntries(key, value);
        }
        public TValue Get(Tkey key)
        {
            var index = this.Hash(key);
            if (this.enteries[index] != null && this.enteries[index].Key != key)
            {
                index = this.CollisionHandling(key, index, false);
                return this.enteries[index].Value;
            }
            else if (index == -1 || this.enteries[index] == null) 
                return default(TValue);
            else if (this.enteries[index].Key == key)
                return this.enteries[index].Value;
            else
                throw new Exception("Invalid HashTable!!");
        }
        public int Size()
        {
            return this.enteriesCount;
        }
        public void Print()
        {
            Console.WriteLine("----------");
            Console.WriteLine("[size] " + this.Size());
            for (int i = 0; i < this.enteries.Length; i++)
            {
                if (this.enteries[i] == null)
                {
                    Console.WriteLine("[" + i + "] = Null");
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
             Tkey _key;
             TValue _value;

            public Tkey Key
            {
                get { return this._key; }
            }
            public TValue Value
            {
                get { return this._value; }
                set { this._value = value; }
            }
            public KeyValuePair(Tkey key, TValue val)
            {
                _key = key;
                _value = val;
            }
        }
    }
}
