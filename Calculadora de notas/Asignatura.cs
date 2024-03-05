using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDeNotas
{
    class Asignatura
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public List<Nota> Notas { get; set; }

        public Asignatura(string nombre, int creditos)
        {
            Nombre = nombre;
            Creditos = creditos;
            Notas = new List<Nota>();
        }

        public void AgregarNota(string nombre, double valor, double porcentaje)
        {
            if (CalcularPorcentajeTotal() + porcentaje > 100)
            {
                Console.WriteLine("Error: El porcentaje total de las notas no puede exceder el 100%.");
                return;
            }

            Notas.Add(new Nota { Nombre = nombre, Valor = valor, Porcentaje = porcentaje });
            Console.WriteLine("Nota agregada con éxito.");
        }

        public double CalcularPromedioAcumulado()
        {
            double promedio = 0;
            foreach (var nota in Notas)
            {
                promedio += (nota.Valor * nota.Porcentaje) / 100;
            }
            return promedio;
        }

        public double CalcularPromedioMinimo(double notaDeseada)
        {
            double porcentajeRestante = 100 - CalcularPorcentajeTotal();
            double sumaNotasExistente = CalcularPromedioAcumulado();
            double promedioMinimo = (notaDeseada - sumaNotasExistente) / (porcentajeRestante / 100);
            return promedioMinimo;
        }

        public double CalcularPorcentajeTotal()
        {
            double porcentajeTotal = 0;
            foreach (var nota in Notas)
            {
                porcentajeTotal += nota.Porcentaje;
            }
            return porcentajeTotal;
        }

    }

}
