using static Extensions.StreamWriterExtensions;

public class Program
{
    public static void Main()
    {
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        int N = Convert.ToInt32(reader.ReadLine());
        string text = reader.ReadToEnd();
        writer.Write(text: text, justificationLimit: N);

        reader.Close();
        writer.Close();
    }
}