using Basic.Classes;
using Basic.Enums;

// Exemplo de utilização das classes

#region Color

Color blue = new(100, 150, 200);
Color orange = new(255, 120, 50);

Console.WriteLine("Cor 1: " + blue);
Console.WriteLine("Cor 2: " + orange);

Console.WriteLine("Hexadecimal da cor 1: " + blue.ToHex());

Color mix = blue.Blend(orange);
Console.WriteLine("Mistura: " + mix.ToHex());

Color darken = blue.Darken(0.3); // escurece 30%
Console.WriteLine("Cor 1 mais escura: " + darken.ToHex());

Color lighten = blue.Lighten(0.5); // clareia 50%
Console.WriteLine("Cor 2 mais clara: " + lighten.ToHex());

#endregion

Console.WriteLine();

#region Temperature

Temperature t1 = new(25, ETemperatureScale.Celsius);   
Temperature t2 = new(77, ETemperatureScale.Fahrenheit);

Console.WriteLine("Temperatura 1: " + t1);
Console.WriteLine("Temperatura 2: " + t2);

Console.WriteLine("T1 em Kelvin: " + t1.ToKelvin());
Console.WriteLine("T2 em Celsius: " + t2.ToCelsius());

Temperature t2InCelsius = t2.ConvertTo(ETemperatureScale.Celsius);
Console.WriteLine("T2 convertida para Celsius: " + t2InCelsius);

int comparison = t1.CompareTo(t2);
Console.WriteLine(
    comparison == 0 ? "Temperaturas iguais" :
    comparison > 0 ? "T1 é maior" : "T2 é maior"
);

#endregion

