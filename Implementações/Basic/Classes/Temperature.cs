namespace Basic.Classes;

using Basic.Enums;

public class Temperature(double value, ETemperatureScale scale)
{
    // Valor numérico da temperatura (ex: 25.0)
    public double Value { get; private set; } = value;

    // Escala da temperatura (Celsius, Fahrenheit ou Kelvin)
    public ETemperatureScale Scale { get; private set; } = scale;

    // Converte a temperatura atual para Celsius
    public double ToCelsius()
    {
        return Scale switch
        {
            ETemperatureScale.Celsius => Value,                            // Já está em Celsius
            ETemperatureScale.Fahrenheit => (Value - 32) * 5 / 9,          // Fórmula de conversão F -> C
            ETemperatureScale.Kelvin => Value - 273.15    ,                // Fórmula de conversão K -> C
            _ => throw new InvalidOperationException("Escala inválida.")   // Caso de erro
        };
    }

    // Converte a temperatura atual para Fahrenheit
    public double ToFahrenheit()
    {
        return Scale switch
        {
            ETemperatureScale.Celsius => Value * 9 / 5 + 32,               // Fórmula de conversão C -> F
            ETemperatureScale.Fahrenheit => Value,                         // Já está em Fahrenheit
            ETemperatureScale.Kelvin => (Value - 273.15) * 9 / 5 + 32,     // Fórmula de conversão K -> F
            _ => throw new InvalidOperationException("Escala inválida.")
        };
    }

    // Converte a temperatura atual para Kelvin
    public double ToKelvin()
    {
        return Scale switch
        {
            ETemperatureScale.Celsius => Value + 273.15,                   // Fórmula de conversão C -> K
            ETemperatureScale.Fahrenheit => (Value - 32) * 5 / 9 + 273.15, // Fórmula de conversão F -> K
            ETemperatureScale.Kelvin => Value,                             // Já está em Kelvin
            _ => throw new InvalidOperationException("Escala inválida.")
        };
    }

    // Cria uma nova instância da temperatura convertida para a escala desejada
    public Temperature ConvertTo(ETemperatureScale targetScale)
    {
        return targetScale switch
        {
            ETemperatureScale.Celsius => new Temperature(ToCelsius(), ETemperatureScale.Celsius),
            ETemperatureScale.Fahrenheit => new Temperature(ToFahrenheit(), ETemperatureScale.Fahrenheit),
            ETemperatureScale.Kelvin => new Temperature(ToKelvin(), ETemperatureScale.Kelvin),
            _ => throw new InvalidOperationException("Escala inválida.")
        };
    }

    // Compara duas temperaturas (após convertê-las para Kelvin para ter uma base comum)
    // Retorna -1 se this < other, 0 se iguais, 1 se this > other
    public int CompareTo(Temperature other)
    {
        double thisInKelvin = this.ToKelvin();
        double otherInKelvin = other.ToKelvin();

        return thisInKelvin.CompareTo(otherInKelvin);
    }

    // Retorna uma representação em string da temperatura (ex: "25.0 °C")
    public override string ToString()
    {
        // Define o símbolo de acordo com a escala
        string symbol = Scale switch
        {
            ETemperatureScale.Celsius => "° C",
            ETemperatureScale.Fahrenheit => "° F",
            ETemperatureScale.Kelvin => "K",
            _ => ""
        };

        return $"{Value:0.0}{symbol}";
    }
}