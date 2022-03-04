namespace _03.Telephony
{
    using _03.Telephony.ExceptionMessages;
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] webSites = Console.ReadLine().Split();

            
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }
            foreach (var website in webSites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(website));
                }
                catch (InvalidURLException message)
                {
                    Console.WriteLine(message.Message);
                }
            }


        }
    }
}
