// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class MainClass{
    public static void Main(string[] args){
        
        string nombre = string.Empty; 
        string apellido = string.Empty; 
        int salir = 0;
        Alumno[] lista = new Alumno[10];
        int i = 0;
        do{
            Console.WriteLine("Nombre(s) del alumno: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Apellidos del alumno: ");
            apellido = Console.ReadLine();
            Console.WriteLine("salir? si=1 no=0");
            lista[i] = new Alumno(nombre, apellido);
            i++;
            salir = Convert.ToInt32(Console.ReadLine()) ;
        }while(salir != 1);
        

       IFormatter f = new BinaryFormatter();
       Stream stream = new FileStream("registroAlumnos.dat", FileMode.Create);
       f.Serialize(stream, lista);
       stream.Close();
       stream.Dispose();

       Console.WriteLine("Exito: Se serializó!");

    }
}
