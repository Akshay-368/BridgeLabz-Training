using System;
using System.Collections.Generic;
using System.Reflection;

public class cacheSys 
{
    // custom cache attribute
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute
    {
        // no extra fields needed
    }

    public class ExpensiveCalculator
    {
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

        [CacheResult]
        public int computePower(int baseNum,int exp)
        {
            // simulate expensive computation
            int result = 1;
            for(int i=0; i<exp ; i++)
            {
                result *= baseNum;
                // slow down
                // Thread.Sleep(10);
            }

            return result;
        }
    }

    public static object callWithCache(object instance,string methodName,params object[] args)
    {
        MethodInfo method = instance.GetType().GetMethod(methodName);

        if(method == null)
        {
            Console.WriteLine("method not found");
            return null;
        }

        // check if has CacheResult
        object[] attrs = method.GetCustomAttributes(typeof(CacheResultAttribute), false);
        if(attrs.Length == 0)
        {
            return method.Invoke(instance, args);
        }

        // create cache key (simple - method name + args)
        string cacheKey = methodName;
        foreach(object arg in args)
        {
            cacheKey += "_" + arg.ToString();
        }

        if(cache.ContainsKey(cacheKey))
        {
            Console.WriteLine("cache hit!");
            return cache[cacheKey];
        }

        object result = method.Invoke(instance, args);

        cache[cacheKey] = result;
        Console.WriteLine("cached result for " + cacheKey);

        return result;
    }

    public static void Main(string[] args) 
    {
        /*
        7️⃣ Implement a Custom Caching System with CacheResult
        Problem Statement: Define CacheResult to store method return values and avoid repeated execution.
        Requirements:
        * Apply CacheResult to a computationally expensive method.
        * Implement a cache (Dictionary) to store previously computed results.
        * If a method is called with the same input, return the cached result instead of recomputation.
        */

        Console.WriteLine("Custom Method Caching Demo\n");

        ExpensiveCalculator calc = new ExpensiveCalculator();

        Console.WriteLine("First call (should compute):");
        int res1 = (int)callWithCache(calc, "computePower", 2, 10);

        Console.WriteLine("\nSecond call (should be cached):");
        int res2 = (int)callWithCache(calc, "computePower", 2, 10);

        Console.WriteLine("\nThird call with different input:");
        int res3 = (int)callWithCache(calc, "computePower", 3, 5);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
