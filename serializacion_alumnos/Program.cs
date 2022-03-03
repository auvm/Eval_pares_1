using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class MainClass{
    public static void Main(string[] args){
        
        string nombre = string.Empty; 
        string apellido = string.Empty; 
        //int salir = 0;
        Alumno[] lista = new Alumno[]{
                new Alumno("Rodrigo", "Lita", 0),
                new Alumno("Uriel", "Velasco", 0),
                new Alumno("Jeannet", "Garcia", 0),
                new Alumno("Antonio", "Santiago", 0),
                new Alumno("Javier", "Rubin", 0),
                new Alumno("Alejandro", "Garcia", 0),
                new Alumno("Ahtziri", "Sara", 0),
                new Alumno("Jacqueline", "Cisneros", 0),
                new Alumno("Eliot", "Ibarra", 0),
                new Alumno("Jose", "Montes", 0)
        };

       IFormatter f = new BinaryFormatter();
       Stream stream = new FileStream("registroAlumnos.dat", FileMode.Create);
       f.Serialize(stream, lista);
       stream.Close();
       stream.Dispose();

       Console.WriteLine("Exito: Se serializó!");

        //DESCERIALIZACIÓN BINARIA
        //IFormatter f = new BinaryFormatter();
        //canal de comunicación
        stream = new FileStream("registroAlumnos.dat", FileMode.Open);
        //instanciamos para acceder al objeto
        Alumno[] copia = (Alumno[])f.Deserialize(stream);
        //casteamos el stream a un registro, porque está como un objeto general
        stream.Close();
        stream.Dispose();
        Console.WriteLine("\nSe deserealizo! ");


        Console.WriteLine("Ingrese las calificaiones: ");
        for (int i = 0; i < copia.Length; i++)
        {
            Console.Write($"{i+1}.- {copia[i].Nombre} {copia[i].Apellido}\t Calificación: ");
            copia[i].Calificacion = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("");
        }


        decimal max = 0;
        int indexMax = 0;
        decimal min = 10;
        int indexMin = 0;
        decimal sumatoria = 0;
        decimal promedio = 0;
        int numAprobados = 0;
        int numReprobados = 0;
        for (int i = 0; i < copia.Length; i++)
        {
            if(copia[i].Calificacion > max){
                max = copia[i].Calificacion;
                indexMax = i;
            }
            if(copia[i].Calificacion < min){
                min = copia[i].Calificacion;
                indexMin = i;
            }
            sumatoria += copia[i].Calificacion;
            if(copia[i].Calificacion >= 6){
                numAprobados++;
            }else{
                numReprobados++;
            }

        }
        promedio = sumatoria/copia.Length;
        Console.WriteLine($"El alumno con menor calificación: {copia[indexMin].Nombre} {copia[indexMin].Apellido}"+
                        $" Calificación: {copia[indexMin].Calificacion}");
        Console.WriteLine($"El alumno con mayor calificación:  {copia[indexMax].Nombre} {copia[indexMax].Apellido}"+
                        $"  Calificación: {copia[indexMax].Calificacion}");
                        
        Console.WriteLine($"Aprovechamiento general: {promedio}");
        Console.WriteLine($"Número total de aprobados: {numAprobados*100/10}");
        Console.WriteLine($"Número total de reprobados: {numReprobados*100/10}");
    }
}
