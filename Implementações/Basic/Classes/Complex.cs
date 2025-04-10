namespace Basic.Classes;

public class Complex
{
    // Parte real do número complexo (ex: 3 em 3 + 2i)
    public double Real { get; set; }

    // Parte imaginária do número complexo (ex: 2 em 3 + 2i)
    public double Imaginary { get; set; }

    // Permite a criação de um Complex a partir de uma tupla (ex: (3, 2))
    public static implicit operator Complex((double a, double b) value)
    {
        return new Complex
        {
            Real = value.a,
            Imaginary = value.b
        };
    }

    // Sobrecarga do operador de igualdade (==)
    public static bool operator ==(Complex a, Complex b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;

        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }

    // Sobrecarga do operador de desigualdade (!=)
    public static bool operator !=(Complex a, Complex b)
        => !(a == b); // Reaproveita a lógica do operador ==

    // Sobrecarga do operador de adição (+) para somar dois números complexos
    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex
        {
            Real = a.Real + b.Real,
            Imaginary = a.Imaginary + b.Imaginary
        };
    }

    // Sobrescreve Equals para manter coerência com o operador ==
    public override bool Equals(object? obj)
    {
        if (obj is Complex other)
            return this == other;

        return false;
    }

    // Sobrescreve GetHashCode para manter coerência com Equals e ==/!=
    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imaginary);
    }

    // Representação em string
    public override string ToString()
    {
        string sign = Imaginary >= 0 ? "+" : "-";
        return $"{Real} {sign} {Math.Abs(Imaginary)}i";
    }
}
