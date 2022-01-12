namespace _0I._Prototype_Pattern
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Letuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Tyrkey"] = new Sandwich("Rye", "Tyrkey", "Swiss", "Lettuce, Onion, Tomato");

            Sandwich oneSandwiches = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich twoSandwiches = sandwichMenu["PB&J"].Clone() as Sandwich;
            Sandwich thirdSandwiches = sandwichMenu["Tyrkey"].Clone() as Sandwich;
        }
    }
}
