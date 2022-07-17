using SharedKernel;

namespace Agencias;


public  class Agencia 
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Endereco { get; set; }
    public ICollection<Segmento> Segmentos { get; set; }

    protected Agencia()
    {
        Segmentos = new List<Segmento>();
    }

    public Agencia(int numero, string endereco)
    {
        Numero = numero;
        Endereco = endereco;
        Segmentos = new List<Segmento>();
    }
}


public class Segmento
{
    public int Id { get; set; }
    public string Tipo { get; set; }

    public ICollection<Agencia> Agencias { get; set; }
}