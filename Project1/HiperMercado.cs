
namespace Project1
{
    public class HiperMercado
    {
        public static double CalcularPreco(double custo, int validade)
        {
            return formulaMagica(custo, validade);
        }

        private static double formulaMagica(double custo, int validade)
        {
            return custo * validade;
        }
    }
}