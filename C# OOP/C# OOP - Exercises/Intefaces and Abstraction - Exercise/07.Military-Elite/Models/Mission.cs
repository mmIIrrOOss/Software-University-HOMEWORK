namespace _07.Military_Elite.Models
{
    using _07.Military_Elite.Contracts;
    using _07.Military_Elite.Enumerations;
    using _07.Military_Elite.Exceptions;
    using System;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            this.State = State.Finished;
        }
        private State TryParseState(string stateStr)
        {
            State state;
            bool parsed = Enum.TryParse<State>(stateStr, out state);
            if (!parsed)
            {
                throw new InvalidMissionStateException();
            }
            return state;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
