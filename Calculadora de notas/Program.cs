
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraDeNotas;
using System;

class Program
{
    static List<Asignatura> asignaturas = new List<Asignatura>();

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la Calculadora de Notas");

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar una nueva asignatura");
            Console.WriteLine("2. Agregar nota a una asignatura");
            Console.WriteLine("3. Calcular promedio acumulado de una asignatura");
            Console.WriteLine("4. Calcular promedio mínimo necesario para alcanzar una nota deseada en una asignatura");
            Console.WriteLine("5. Salir");

            Console.WriteLine("Ingrese el número de la opción deseada:");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarAsignatura();
                    break;
                case "2":
                    AgregarNota();
                    break;
                case "3":
                    MostrarPromedioAsignatura();
                    break;
                case "4":
                    CalcularNotaNecesaria();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }






    static void AgregarAsignatura()
    {
        Console.WriteLine("Ingrese el nombre de la asignatura:");
        string nombre = Console.ReadLine().ToLower();

        Console.WriteLine("Ingrese el número de créditos de la asignatura:");
        int creditos = Convert.ToInt32(Console.ReadLine());

        asignaturas.Add(new Asignatura(nombre, creditos));
        Console.WriteLine($"Asignatura '{nombre}' agregada con éxito.");
    }

    static void ListarAsignaturas()
    {
        Console.WriteLine("Lista de asignaturas:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"Asignatura: {asignatura.Nombre}, Créditos: {asignatura.Creditos}");
        }
    }

    static void MostrarPromedioAsignatura()
    {
        Console.WriteLine("Ingrese el nombre de la asignatura para calcular el promedio acumulado:");
        string nombreAsignatura = Console.ReadLine().ToLower();

        var asignatura = asignaturas.Find(a => a.Nombre == nombreAsignatura);
        if (asignatura != null)
        {
            Console.WriteLine($"Promedio de {nombreAsignatura}: {asignatura.CalcularPromedioAcumulado()}");
        }
        else
        {
            Console.WriteLine("Error: La asignatura especificada no existe.");
        }
    }

    static void CalcularNotaNecesaria()
    {
        Console.WriteLine("Ingrese el nombre de la asignatura para calcular el promedio mínimo:");
        string nombreAsignatura = Console.ReadLine().ToLower();

        var asignatura = asignaturas.Find(a => a.Nombre == nombreAsignatura);
        if (asignatura != null)
        {
            Console.WriteLine("Ingrese la nota deseada:");
            double notaDeseada = Convert.ToDouble(Console.ReadLine());

            double notaNecesaria = asignatura.CalcularPromedioMinimo(notaDeseada);
            Console.WriteLine($"Para obtener {notaDeseada} en {nombreAsignatura}, necesitas sacar {notaNecesaria} en el porcentaje restante.");
        }
        else
        {
            Console.WriteLine("Error: La asignatura especificada no existe.");
        }
    }

    static void AgregarNota()
    {
        Console.WriteLine("Ingrese el nombre de la asignatura a la que desea agregar la nota:");
        string nombreAsignatura = Console.ReadLine();

        var asignatura = asignaturas.Find(a => a.Nombre == nombreAsignatura);
        if (asignatura != null)
        {
            Console.WriteLine("Ingrese el nombre de la nota:");
            string nombreNota = Console.ReadLine();

            Console.WriteLine("Ingrese el valor de la nota:");
            double valorNota = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el porcentaje de la nota con respecto al total:");
            double porcentajeNota = Convert.ToDouble(Console.ReadLine());

            asignatura.AgregarNota(nombreNota, valorNota, porcentajeNota);
        }
        else
        {
            Console.WriteLine("Error: La asignatura especificada no existe.");
        }
    }



}