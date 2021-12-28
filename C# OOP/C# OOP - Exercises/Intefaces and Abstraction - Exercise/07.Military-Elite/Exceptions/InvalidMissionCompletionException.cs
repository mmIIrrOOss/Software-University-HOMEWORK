namespace _07.Military_Elite.Exceptions
{
    using System;

    public class InvalidMissionCompletionException : Exception
    {
        private const string Invalid_MissionCompletion = "Mission already completed!";
        public InvalidMissionCompletionException()
            :base()
        {
        }
    }
}
