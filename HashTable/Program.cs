namespace HashTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region HashTable
            //Hash hash = new Hash();
            //hash.Hash32("This is Original Text");
            //hash.Hash64("This is Original Text");
            HashTable<string, string> table = new HashTable<string, string>();
            table.Print();
            table.Set("Sinar", "sinar@gmail.com");
            table.Set("Elvis", "elvis@gmail.com");
            table.Set("Tane", "tane@gmail.com");
            table.Print();
            //Console.WriteLine("[get] " + table.Get("Sinar"));
            //Console.WriteLine("[get] " + table.Get("Tane"));
            table.Set("Gerti", "gerti@gmail.com");
            table.Set("Arist", "arist@gmail.com");
            table.Print();
            //Console.WriteLine("[get] " + table.Get("Sinar"));
            #endregion
            #region  Dictionary
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Print();

            //dic.Set("Sinar", "sinar@gmail.com");
            //dic.Set("Elvis", "elvis@gmail.com");
            //dic.Print();

            //dic.Set("Tane", "tane@gmail.com");
            //dic.Set("Gerti", "gerti@gmail.com");
            //dic.Set("Arist", "arist@gmail.com");
            //dic.Print();

            ////dic.Set("Bist", "rarist@gmail.com");
            ////dic.Set("Trist", "tarist@gmail.com");
            ////dic.Set("Srist", "yarist@gmail.com");
            ////dic.Print();

            ////Console.WriteLine(dic.Get("Tane"));
            ////Console.WriteLine(dic.Get("Sinar"));
            ////Console.WriteLine(dic.Get("Elviaaa"));

            //dic.Remove("Sinar");
            //dic.Remove("Elvis");
            //dic.Remove("Tane");
            //dic.Remove("Gerti");
            //dic.Remove("Arist");
            //dic.Print();
            //dic.Set("Sinar", "sinar@gmail.com");
            //dic.Print();
            #endregion

        }
    }
}