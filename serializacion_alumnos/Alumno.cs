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
        Calificacion = 0;
    }

    public Alumno(string n, string a)
    {
        Nombre = n;
        Apellido = a;
        Calificacion = 0;
    }

    public Alumno(string n, string a, decimal c)
    {
        Nombre = n;
        Apellido = a;
        Calificacion = c;
    }

    public override string ToString()
    {
        string cadena = $" Nombre: {Nombre} {Apellido} \n Calificación: {Calificacion}\n";
        return cadena;
    }
}