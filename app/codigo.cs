using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicitar el monto inicial
        Console.Write("Ingrese el monto inicial (capital): ");
        double principal = Convert.ToDouble(Console.ReadLine());

        // Solicitar la tasa de interés anual
        Console.Write("Ingrese la tasa de interés anual (en %): ");
        double rate = Convert.ToDouble(Console.ReadLine()) / 100;

        // Solicitar el número de veces que se capitaliza por año
        Console.Write("Ingrese el número de veces que se capitaliza por año: ");
        int timesCompounded = Convert.ToInt32(Console.ReadLine());

        // Solicitar el número de años
        Console.Write("Ingrese el número de años: ");
        int years = Convert.ToInt32(Console.ReadLine());

        // Calcular el monto futuro utilizando la fórmula de interés compuesto
        double amount = principal * Math.Pow((1 + rate / timesCompounded), timesCompounded * years);

        // Mostrar el resultado
        Console.WriteLine($"\nEl monto futuro después de {years} años es: {amount:C2}");
    }
}
