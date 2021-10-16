namespace _04.Copy_Binary_File
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (FileStream reader = new FileStream("../../../1452223_578521412235096_1374018500_n.jpg", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../newFile.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (reader.CanRead)
                    {
                        int byteRead = reader.Read(buffer, 0, buffer.Length);
                        if (byteRead == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }


        }
    }
}
