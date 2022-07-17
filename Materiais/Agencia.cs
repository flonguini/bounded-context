namespace Materiais;
public class Agencia
{
    public int Id { get; set; } 
    public int Numero { get; set; }
}


public class Segmento
{
    public int Id { get; set; }
    public string Tipo { get; set; }

    public ICollection<Material> Materiais { get; set; }
}

public class Material
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Segmento Segmento { get; set; }
    public int SegmentoId { get; set; }

    protected Material()
    {

    }

    public Material(int segmentoId, string descricao)
    {
        SegmentoId = segmentoId;
        Descricao = descricao;
    }
}