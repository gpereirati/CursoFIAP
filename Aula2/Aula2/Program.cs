public class Program
{
    static void Main(string[] args)
    {
        Curso c1 = new Curso(1, "Curso 1");
        Curso c2 = new Curso(2, "Curso 2");
        Curso c3 = new Curso(3, "Curso 3");
        // Criando um lista de objeto na estrutura chave + valor
        Dictionary<string, Curso> dicionario = new Dictionary<String, Curso>();
        dicionario.Add(c1.NomeCurso, c1);
        dicionario.Add(c2.NomeCurso, c2);
        dicionario.Add(c3.NomeCurso, c3);
        // procurando um determinado elemento
        Console.Write("Encontrou o Curso 2: ");
        Console.WriteLine(dicionario.ContainsKey("Curso 4s"));
        Console.WriteLine("");
        // Navegando pela coleção e imprimindo os objetos.
        foreach (KeyValuePair<string, Curso> itemCurso in dicionario)
        {
            string chave = itemCurso.Key;
            Curso c = dicionario[chave];
            Console.WriteLine(c.NomeCurso);
        }
        Console.Read();
    }
}
public class Curso
{
    public int Codigo;
    public string NomeCurso;
    public Curso(int cod, string nome)
    {
        this.Codigo = cod;
        this.NomeCurso = nome;
    }
}