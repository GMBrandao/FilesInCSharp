using System;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string file;
        string lorem = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit.\n" +
                       "Sed porttitor, nibh id dictum varius, magna libero rutrum nulla, at cursus nisl dolor et libero.\n" +
                       "Duis ac nulla risus. Quisque euismod tortor nec consequat ornare.\n" +
                       "Aliquam auctor aliquam neque. \n" +
                       "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; \n" +
                       "Nulla luctus consectetur nulla ut placerat.\n" +
                       "Phasellus pellentesque nec dolor mollis hendrerit.\n" +
                       "Aliquam gravida sem vulputate massa scelerisque, nec dignissim massa mollis.\n" +
                       "Maecenas a mollis leo. Maecenas fringilla orci mi, in suscipit augue aliquet sit amet.\n" +
                       "Suspendisse fermentum tempus malesuada. Donec nec ante lectus. ";
        Console.WriteLine(lorem);
        WriteFile(lorem);

        Console.Write("\nInforme o nome do arquivo a ser lido: ");
        file = Console.ReadLine();

        Console.WriteLine("Quantas linhas serão lidas?");
        int lines = int.Parse(Console.ReadLine());

        var text = ReadFile(file, lines);
        Console.WriteLine("\n" + text);

        void WriteFile(string text)
        {
            try
            {
                if (File.Exists("loremipsum.txt"))
                {
                    var temp = ReadFile("loremipsum.txt", 0);
                    StreamWriter sw = new("loremipsum.txt");
                    sw.Write(lorem);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("loremipsum.txt");
                    sw.Write(lorem);
                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("\nRegistro criado com sucesso!");
            }
        }

        string ReadFile(string f, int lines)
        {
            string aux = "";
            try
            {
                StreamReader sr = new(f);
                for(int i = 0; i < lines; i++)
                {
                    var verify = sr.ReadLine();
                    if (verify == null)
                        return aux;
                    else
                        aux += verify + "\n";
                }
                sr.Close();
            }
            catch (Exception)
            {
                return "Esse arquivo não existe\nInsira um arquivo válido.";
            }
            return aux;
        }
    }
}