namespace FotoVista.Service.Validations;

public class PriceValidator
{
    public static bool IsValid(int price)
    {
        if (price < 0) return false;

        return true;
    }
}