/*Almacenar 10 registros de estudiantes: nombre, carrera y promedio*/

Estudiante[] estudiantes = new Estudiante[10];

int menu()
{
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Salir");
    Console.Write("Digita tu opcion: ");
    return int.Parse(Console.ReadLine());
    
}

void pedirDatos() {
    for (int i = 0; i < 10; i++)
    {
        Console.Write("Nombre: ");
        estudiantes[i].nombre = Console.ReadLine();
        Console.Write("Carrera: ");
        estudiantes[i].carrera = Console.ReadLine();
        Console.Write("Promedio: ");
        estudiantes[i].promedio = Double.Parse(Console.ReadLine());
    }
}

void mostrarDatos()
{
    for(int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{estudiantes[i].nombre} | {estudiantes[i].carrera} | {estudiantes[i].promedio}");
    }
}

void main()
{
    int op;
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
                Console.WriteLine("Adios...");
                break;
            default:
                Console.WriteLine("Opción Invalida");
                break;
        }
    } while (op != 3);
}

main();

struct Estudiante
{
    public string nombre;
    public string carrera;
    public double promedio;
}