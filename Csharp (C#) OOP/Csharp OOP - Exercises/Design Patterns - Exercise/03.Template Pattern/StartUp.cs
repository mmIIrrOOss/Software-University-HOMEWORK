namespace _03.Template_Pattern
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            Sourdough oneSourdough = new Sourdough();
            oneSourdough.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
                
        }
    }
}
