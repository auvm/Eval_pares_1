[Serializable]

public class Alumno
{
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public decimal Calificacion { get; set; }

    public Alumno()
    {
        Nombre = String.Empty;
        Apellido = String.Empty;
    }

    public Alumno(string n, string a)
    {
        Nombre = n;
        Apellido = a;
    }

    public override string ToString()
    {
        string cadena = $"{Nombre} {Apellido}";
        return cadena;
    }
}