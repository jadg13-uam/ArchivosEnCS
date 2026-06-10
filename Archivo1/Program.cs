/*Almacenar 10 registros de estudiantes: nombre, carrera y promedio*/

using System.Runtime;

Estudiante[] estudiantes = new Estudiante[10];
int i = 0;

int menu()
{
    Console.Clear();
    Console.WriteLine("1. Agregar Registro");
    Console.WriteLine("2. Mostrar Registros");
    Console.WriteLine("3. Guardar Archivo");
    Console.WriteLine("4. Eliminar Registro");
    Console.WriteLine("0. Salir");
    Console.Write("Digita tu opcion: ");
    return int.Parse(Console.ReadLine());

}

void pedirDatos()
{
    if (i < 10)
    {
        Console.WriteLine($"Registo # {i + 1} de 10");
        Console.Write("Nombre: ");
        estudiantes[i].nombre = Console.ReadLine();
        Console.Write("Carrera: ");
        estudiantes[i].carrera = Console.ReadLine();
        Console.Write("Promedio: ");
        estudiantes[i].promedio = Double.Parse(Console.ReadLine());
        i++;
    }
    else
    {
        Console.WriteLine("No hay espacio.");
    }
    Console.ReadLine();
}

void mostrarDatos()
{
    for (int cont = 0; cont < i; cont++)
    {
        Console.WriteLine($"Estudiante #: {cont+1}");
        Console.WriteLine($"{estudiantes[cont].nombre} | {estudiantes[cont].carrera} | {estudiantes[cont].promedio}");
    }
    Console.ReadLine();
}

void guardarArchivo()
{
    StreamWriter archivo = new StreamWriter("C:\\xe\\registro.csv");
    for (int cont = 0; cont < i; cont++)
    {
        archivo.WriteLine(estudiantes[cont].nombre + ";" + estudiantes[cont].carrera + ";" + estudiantes[cont].promedio);
    }
    archivo.Close();
    Console.WriteLine("Registro guardado.");
    Console.ReadLine();
}

int buscarRegistro(string nombre)
{
    return Array.FindIndex(estudiantes, est => est.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
}

void eliminarRegistro(string nombre)
{
    int pos = buscarRegistro(nombre);

    if (pos == -1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Estudiante no existe");
        Console.ResetColor();
        Console.ReadKey();
        return ;
    }

    for(int i = pos; i< estudiantes.Length-1; i++)
    {
        estudiantes[i] = estudiantes[i + 1];
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Registro eliminado satisfactoriamente.");
    i--;
    Console.ResetColor();
    Console.ReadKey();
}

void leerArchivo()
{
    StreamReader archivo = new StreamReader(@"C:\xe\registro.csv");
    String linea;
    while ((linea = archivo.ReadLine()) != null )
    {
        String[] dato = linea.Split(';');
        estudiantes[i].nombre = dato[0];
        estudiantes[i].carrera = dato[1];
        estudiantes[i].promedio = Double.Parse(dato[2]);
        i++;
    }
    archivo.Close();
}

void main()
{
    String nombre;
    int op;
    leerArchivo();
    do
    {
        op = menu();
        switch (op)
        {
            case 1:
                pedirDatos();
                break;
            case 2:
                mostrarDatos();
                break;
            case 3:
                guardarArchivo();
                break;

            case 4:
                Console.WriteLine("¿Qué estudiante desea eliminar? ");
                nombre = Console.ReadLine();
                eliminarRegistro(nombre);
                break;
            case 0:
                Console.WriteLine("Adios...");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción Invalida");
                Console.ResetColor();
                break;
        }
    } while (op != 0);
}

main();

struct Estudiante
{
    public string nombre;
    public string carrera;
    public double promedio;
}