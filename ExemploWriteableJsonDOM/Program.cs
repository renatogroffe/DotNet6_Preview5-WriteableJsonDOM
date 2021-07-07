using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ExemploWriteableJsonDOM
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*** Testes com Writeable JSON DOM ***");

            var versaoAtual = JsonNode.Parse(
                "{\"nome\": \"Microsoft\", \"versaoAtualDotNet\": 5}");
            int versaoAtualDotNet = versaoAtual["versaoAtualDotNet"].GetValue<int>();
            Console.WriteLine();
            Console.WriteLine($"Empresa Responsável: {versaoAtual["nome"]}");
            Console.WriteLine($"Versão atual do .NET: {versaoAtualDotNet}");

            var plataformaDotNet = new JsonObject()
            {
                ["descricao"] = "Plataforma .NET",
                ["anoInicial"] = 2002,
                ["versaoAtual"] = versaoAtualDotNet,
                ["pessoasChave"] = new JsonArray("Anders Hejlsberg", "Scott Hanselman", "Mads Torgersen", "Miguel de Icaza"),
                ["ferramentas"] = new JsonObject
                {
                    ["microsoft"] = new JsonArray("Visual Studio 2019", "Visual Studio 2022", "Visual Studio Code"),
                    ["jetBrains"] = "Rider"
                }
            };

            Console.WriteLine();
            Console.WriteLine(plataformaDotNet.ToJsonString());

            Console.WriteLine();
            Console.WriteLine(plataformaDotNet.ToJsonString(
                new JsonSerializerOptions() { WriteIndented = true }));
            
            Console.WriteLine();
            Console.WriteLine($"* {plataformaDotNet["descricao"]} - Overview *");
            Console.WriteLine($"Ano inicial: {plataformaDotNet["anoInicial"]}");
            Console.WriteLine($"Uma pessoa importante: {plataformaDotNet["pessoasChave"][0].GetValue<string>()}");
            Console.WriteLine($"Principal ferramenta hoje: {plataformaDotNet["ferramentas"]["microsoft"][0]}");
        }
    }
}