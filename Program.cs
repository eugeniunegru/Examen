
using Examen;

class Program
{
    static void Main()
    {
        int inputtype = 0;
        int inputformat = 0;
        int outputtype = 0;
        int outputformat = 0;
        Console.WriteLine("Input type");
        Console.WriteLine("1 memory\r\n2 file\r\n3 http");
        inputtype= int.Parse(Console.ReadLine().ToString());

        Console.WriteLine("Input format");
        Console.WriteLine("1 string\r\n2 json\r\n3 xml");
        inputformat= int.Parse(Console.ReadLine().ToString());

        Console.WriteLine("Output type");
        Console.WriteLine("1 Console\r\n2 File");
        outputtype= int.Parse(Console.ReadLine().ToString());

        Console.WriteLine("Output format");
        Console.WriteLine("1 string\r\n2 json \r\n3 xml");
        outputformat= int.Parse(Console.ReadLine().ToString());

        Manipulator manipulator=new Manipulator(inputtype, inputformat, outputtype,outputformat);
        manipulator.Show();
    }
}