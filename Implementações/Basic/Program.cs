using Basic.Classes;

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