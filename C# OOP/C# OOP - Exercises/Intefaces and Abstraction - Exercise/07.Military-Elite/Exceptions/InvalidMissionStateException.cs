namespace _07.Military_Elite.Exceptions
{
    using System;


    public class InvalidMissionStateException : Exception
    {
        private const string Invalid_Mission_State_Excepton_Message = "Invalid mission state!";
        public InvalidMissionStateException()
            :base(Invalid_Mission_State_Excepton_Message)
        {
        }
    }
}
