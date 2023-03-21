using System.Runtime.CompilerServices;
using FilesInCSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        string file;

        Person person1 = CreatePerson();
        Person person2 = CreatePerson();

        WriteFile(person1);
        WriteFile(person2);

        Thread.Sleep(1000);
        Console.Clear();

        Console.Write("Informe o nome do arquivo a ser lido: ");
        file = Console.ReadLine();
        var text = ReadFile(file);
        Console.WriteLine("\n" + text);
        Person CreatePerson()
        {
            string name;
            char gender;

            do
            {
                Console.Write("Informe o nome da pessoa: ");
                name = Console.ReadLine();
                if (name == "")
                    Console.WriteLine("Nome inválido");
            } while (name == "");

            Console.Write("\nInforme o gênero da pessoa: ");
            gender = char.Parse(Console.ReadLine());

            return new(name, gender);
        }

        void WriteFile(Person person)
        {
            try
            {
                if (File.Exists("backup.txt"))
                {
                    var temp = ReadFile("backup.txt");
                    StreamWriter sw = new("backup.txt");
                    sw.WriteLine(temp + "\n" + person.ToString());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("backup.txt");
                    sw.WriteLine(person.ToString());
                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Registro criado com sucesso!");
            }
        }

        string ReadFile(string f)
        {
            string aux = "";
            try
            {
                StreamReader sr = new(f);
                aux = sr.ReadToEnd();
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