
namespace _05.SliceAFile
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            int pieceCount = 4;
            using (FileStream stream = new FileStream("../../../Slice.txt", 
                FileMode.Open))
            {
                long size = stream.Length / pieceCount;
                for (int i = 0; i < pieceCount; i++)
                {

                    using (FileStream pieceStrea = new FileStream($"../../../part-{i + 1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[1];
                        int count = -4;
                        while (count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            pieceStrea.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                        }
                    }
                }
            }
        }
    }
}
