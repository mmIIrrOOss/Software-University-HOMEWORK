namespace _04.Hotel_Reservation.IO
{
    using System;
    using Contracts;
   

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
