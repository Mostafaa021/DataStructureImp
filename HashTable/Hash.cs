using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Hash
    {
         public uint Hash32(string str)
        {
            uint OffsetBasis = 2166136261; // Constant for 32bit
            uint FNVPrime = 16777619;// Constatant of FNVPrime for 32 bit 
            var data = Encoding.ASCII.GetBytes(str); // array of bytes

            // FNV-1a Hashing Algorithm Implmentation
            uint hash = OffsetBasis;
            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime; 
            }
            Console.WriteLine(str + "," + hash + ", " + hash.ToString("x")); // hash.ToString("x") => from int to hexadecimal
            return hash; 
        }
        public ulong Hash64(string str)
        {
            ulong OffsetBasis = 14695981039346656037; // Constant for 32bit
            ulong FNVPrime = 1099511628211;// Constatant of FNVPrime for 32 bit 
            var data = Encoding.ASCII.GetBytes(str); // array of bytes

            // FNV-1a Hashing Algorithm Implmentation
            ulong hash = OffsetBasis;
            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }
            Console.WriteLine(str + "," + hash + ", " + hash.ToString("x")); // hash.ToString("x") => from int to hexadecimal
            return hash;
        }
    }
}
