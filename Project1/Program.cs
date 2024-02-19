using Project1;

class Program
{
    static void Main(string[] args)
    {
        HiperMercadoCalculo();
        CandidatoPrefeito();
    }

    private static void HiperMercadoCalculo()
    {
        double custo = 12.30;
        int validade = 16;

        double preco = HiperMercado.CalcularPreco(custo, validade);

        // Exibi o preço calculado
        Console.WriteLine($"O preço a ser cobrado é: R${preco:F2}");
    }

    private static void CandidatoPrefeito()
    {
        List<Casa> casas = new List<Casa>
        {
            new Casa { Rua = new Rua { Nome = "Rua A" }, Numero = 1, TotalEleitores = 100 },
            new Casa { Rua = new Rua { Nome = "Rua B" }, Numero = 2, TotalEleitores = 150 },
            new Casa { Rua = new Rua { Nome = "Rua A" }, Numero = 3, TotalEleitores = 120 },
            new Casa { Rua = new Rua { Nome = "Rua C" }, Numero = 4, TotalEleitores = 200 },
            new Casa { Rua = new Rua { Nome = "Rua B" }, Numero = 5, TotalEleitores = 180 }
        };

        List<Rua> ruasMaisImpactantes = RuasMaisImpactantes(casas);

        // Exibir as ruas mais impactantes
        Console.WriteLine("Ruas mais impactantes:");
        foreach (var rua in ruasMaisImpactantes)
        {
            Console.WriteLine(rua.Nome);
        }
    }

    public static List<Rua> RuasMaisImpactantes(List<Casa> casas)
    {
        Dictionary<string, int> eleitoresPorRua = new Dictionary<string, int>();

        foreach (var casa in casas)
        {
            if (!eleitoresPorRua.ContainsKey(casa.Rua.Nome))
            {
                eleitoresPorRua[casa.Rua.Nome] = 0;
            }
            eleitoresPorRua[casa.Rua.Nome] += casa.TotalEleitores;
        }

        // Ordenar as ruas pelo total de eleitores em ordem decrescente
        var ruasOrdenadas = eleitoresPorRua.OrderByDescending(pair => pair.Value).Select(pair => new Rua { Nome = pair.Key }).ToList();

        return ruasOrdenadas;
    }
}