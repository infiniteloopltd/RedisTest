using System;
using System.Threading;
using StackExchange.Redis;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string endpoint = "redis-15557.c72.eu-west-1-2.ec2.cloud.redislabs.com:15557,password=JU455eaOlQZjVYExorUl1oFouO509Ptu";

            var redis = ConnectionMultiplexer.Connect(endpoint);
            

            var db = redis.GetDatabase();

            

            const string setValue = "abcdefg";
            db.StringSet("mykey", setValue, TimeSpan.FromSeconds(2));
    
            string getValue = db.StringGet("mykey");
            Console.WriteLine(getValue); // writes: "abcdefg"

            Thread.Sleep(TimeSpan.FromSeconds(3));

            string getValue2 = db.StringGet("mykey");
            Console.WriteLine(getValue2); // writes nothing
        }
    }
}
