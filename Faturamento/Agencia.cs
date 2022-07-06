namespace Faturamentos;
public class Agencia
{
    public int Id { get; set; }
    public int Numero { get; set; }

    public ICollection<Faturamento> Faturamentos { get; set; }
}

public class Faturamento
{
    public int Id { get; set; }
    public int Total { get; set; }

    public int AgenciaId { get; set; }
}
