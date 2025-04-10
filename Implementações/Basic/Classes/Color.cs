namespace Basic.Classes;

public class Color(byte r, byte g, byte b, byte a = 255)
{
    // Propriedades da cor: R = vermelho, G = verde, B = azul e A = alfa (transparência)
    // É utilizado o tipo byte porque os valores vão de 0 a 255
    public byte R { get; private set; } = r;
    public byte G { get; private set; } = g;
    public byte B { get; private set; } = b;
    public byte A { get; private set; } = a;

    // Retorna a cor no formato hexadecimal (por exemplo: #FF00FF80)
    // O "X2" formata cada byte como hexadecimal de 2 dígitos
    public string ToHex() => $"#{R:X2}{G:X2}{B:X2}{A:X2}";

    // Retorna a mistura das duas cores igualmente (blend 50%), calculando a média dos componentes R, G, B e A
    public Color Blend(Color other)
    {
        byte r = (byte)((R + other.R) / 2);
        byte g = (byte)((G + other.G) / 2);
        byte b = (byte)((B + other.B) / 2);
        byte a = (byte)((A + other.A) / 2);
        return new Color(r, g, b, a);
    }

    // Escurece a cor de acordo com um fator entre 0 e 1
    // Quanto maior o fator, mais escura fica (0.2 = 20% mais escura)
    public Color Darken(double factor)
    {
        return new Color(
            (byte)(R * (1 - factor)),
            (byte)(G * (1 - factor)),
            (byte)(B * (1 - factor)),
            A // Mantém o mesmo valor de transparência
        );
    }

    // Clareia a cor de acordo com um fator entre 0 e 1
    // Adiciona uma porcentagem da distância até o branco (255) a cada componente
    public Color Lighten(double factor)
    {
        byte r = (byte)Math.Min(255, R + (255 - R) * factor);
        byte g = (byte)Math.Min(255, G + (255 - G) * factor);
        byte b = (byte)Math.Min(255, B + (255 - B) * factor);
        return new Color(r, g, b, A);
    }

    // Representação da string da cor
    public override string ToString() => $"Color(R:{R}, G:{G}, B:{B}, A:{A})";
}
