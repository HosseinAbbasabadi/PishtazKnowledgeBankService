using System;

namespace Framework.Domain
{
    public static class RandomHelper
    {
        public static int GeneratePassword()
        {
            var random = new Random();
            return random.Next(6000, 9999);
        }

        public static int GenerateCcv2()
        {
            var randomCcv2 = new Random();
            return randomCcv2.Next(100, 599);
        }
    }
}