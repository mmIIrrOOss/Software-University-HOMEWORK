using System;

namespace OnTimeFortheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrive = int.Parse(Console.ReadLine());
            int minuteArrive = int.Parse(Console.ReadLine());

            int examInMinutes = hourExam * 60 + minuteExam;
            int arriveInMinutes = hourArrive * 60 + minuteArrive;

            if (arriveInMinutes > examInMinutes)
            {
                Console.WriteLine("Late");
                int lateInMinutes = arriveInMinutes - examInMinutes; ;
                if (lateInMinutes < 60)
                {
                    Console.WriteLine($"{lateInMinutes} minutes after the start");
                }
                else
                {
                    int lateHour = lateInMinutes / 60;
                    int lateMinutes = lateInMinutes % 60;
                    Console.WriteLine($"{lateHour}:{lateMinutes:d2} hours after the start");
                }
            }
            else if (arriveInMinutes == examInMinutes || examInMinutes - arriveInMinutes <= 30)
            {
                Console.WriteLine("On time");
                if (arriveInMinutes != examInMinutes)
                {
                    Console.WriteLine($"{examInMinutes - arriveInMinutes} minutes before the start");
                }
            }
            else if (examInMinutes - arriveInMinutes > 30)
            {
                Console.WriteLine("Early");
                int earlyInMinutes = examInMinutes - arriveInMinutes;
                if (earlyInMinutes < 60)
                {
                    Console.WriteLine($"{earlyInMinutes} minutes before the start");
                }
                else
                {
                    int earlyHour = earlyInMinutes / 60;
                    int earlyMinutes = earlyInMinutes % 60;
                    Console.WriteLine($"{earlyHour}:{earlyMinutes:d2} hours before the start");
                }

            }


        }
    }
}
