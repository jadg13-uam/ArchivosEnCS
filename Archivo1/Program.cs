/*Almacenar 10 registros de estudiantes: nombre, carrera y promedio*/

using System.Runtime;

Estudiante[] estudiantes = new Estudiante[10];
int i = 0;

int menu()
{
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Guardar");
    Console.WriteLine("4. Salir");
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
}

void mostrarDatos()
{
    for (int cont = 0; cont < i; cont++)
    {
        Console.WriteLine($"Estudiante #: {cont+1}");
        Console.WriteLine($"{estudiantes[cont].nombre} | {estudiantes[cont].carrera} | {estudiantes[cont].promedio}");
    }
}

void guardarArchivo()
{
    StreamWriter archivo = new StreamWriter("C:\\xe\\registro.csv");
    for (int i = 0; i < 10; i++)
    {
        archivo.WriteLine(estudiantes[i].nombre + ";" + estudiantes[i].carrera + ";" + estudiantes[i].promedio);
    }
    archivo.Close();
    Console.WriteLine("Registro guardado.");
}

void leerArchivo()
{
    StreamReader archivo = new StreamReader("C:\\xe\\registro.csv");
    String linea;
    while ((linea = archivo.ReadLine()) != null && i < 10)
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
                Console.WriteLine("Adios...");
                break;
            default:
                Console.WriteLine("Opción Invalida");
                break;
        }
    } while (op != 4);
}

main();

struct Estudiante
{
    public string nombre;
    public string carrera;
    public double promedio;
}