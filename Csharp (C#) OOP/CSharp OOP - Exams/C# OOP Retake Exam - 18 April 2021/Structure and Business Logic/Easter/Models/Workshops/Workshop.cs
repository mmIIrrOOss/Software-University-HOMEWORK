namespace Easter.Models.Workshops
{
    using System.Linq;

    using Contracts;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (egg.IsDone() == false)
            {
                if (bunny.Energy == 0 || bunny.Dyes.All(d => d.IsFinished()))
                {
                    break;
                }

                egg.GetColored();
                bunny.Work();
            }
        }
    }
}
