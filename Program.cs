using CadastroPessoa.Classes;

Console.Clear();
Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(@$"
===========================================
|   Bem vindo ao sistema de cadastro de   |
|       Pessoas Físicas e Jurídicas       | 
===========================================
");

Console.ResetColor();

Utils.BarraCarregamento("Carregando", 10, ".", 200);

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
===========================================
|       Escolha uma das opções abaixo     |
|-----------------------------------------|
|           1 - Pessoa Física             |
|           2 - Pessoa Jurídica           |
|                                         |
|           0 - Sair                      |
===========================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEndPf = new Endereco();


            novaPf.nome = "Diogo";
            novaPf.cpf = "1234567890";
            novaPf.rendimento = 6600.5f;
            novaPf.dataNasc = new DateTime(2000, 01, 01);

            novoEndPf.logradouro = "Rua Yolanda Monteiro Pereira";
            novoEndPf.numero = 122;
            novoEndPf.complemento = "Jardim Santa Maria";
            novoEndPf.endComercial = false;

            novaPf.endereco = novoEndPf;

            Console.Clear();
            Console.WriteLine(@$"
Nome: {novaPf.nome}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
Maior de idade: {novaPf.ValidarDataNasc(novaPf.dataNasc)}
            ");

            Console.WriteLine($"Aperte 'ENTER' para continuar");
            Console.ReadLine();

            break;
        case "2":

            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();

            novaPj.nome = "Fabio";
            novaPj.razaoSocial = "Razao Social Pj";
            novaPj.cnpj = "04.900.240/0001-01";
            novaPj.rendimento = 6000.5f;

            novoEndPj.logradouro = "Rua Fioravante Sichieri";
            novoEndPj.numero = 2452;
            novoEndPj.complemento = "Jardim Paraíso";
            novoEndPj.endComercial = false;

            novaPj.endereco = novoEndPj;

            Console.Clear();
            Console.WriteLine(@$"
Nome: {novaPj.nome}
Razão Social: {novaPj.razaoSocial}
CNPJ: {novaPj.cnpj} - Válido: {novaPj.ValidarCnpj(novaPj.cnpj)}
            ");

            Console.WriteLine($"Aperte 'ENTER' para continuar");
            Console.ReadLine();

            break;
        case "0":
            Console.WriteLine($"Obrigado por utilizar nosso sistema");

            Utils.BarraCarregamento("Finalizando", 5, "+", 500);

            break;
        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Opção inválida, por favor digite uma opção válida");
            Console.ResetColor();
            Thread.Sleep(3000);
            break;
    }


} while (opcao != "0");



























// Console.WriteLine("Nome: " + novaPf.nome + " - CPF: " + novaPf.cpf);
// Console.WriteLine($"Nome: {novaPf.nome} - CPF: {novaPf.cpf}");

// float impostoPagar = novaPf.CalcularImposto(novaPf.rendimento);
//Console.WriteLine(impostoPagar.ToString("C"));

// == igualdade
// > maior que
// < menor que
// >= maior ou igual
// <= menor ou igual
// != diferente

// && (and)
// || (or)









