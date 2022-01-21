﻿namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int InitialBreadPortion = 245;

        public Cake(string name, decimal price)
            : base(name, InitialBreadPortion, price)
        { 

        }
    }
}

