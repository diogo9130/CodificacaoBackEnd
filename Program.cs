using CadastroPessoa.Classes;

PessoaFisica metodosPf = new PessoaFisica();
List<PessoaFisica> listaPf = new List<PessoaFisica>();

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

            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
===========================================
|       Escolha uma das opções abaixo     |
|-----------------------------------------|
|       1 - Cadastrar Pessoa Física       |
|       2 - Listar Pessoa Física          |
|                                         |
|       0 - Voltar ao menu anterior       |
===========================================
");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEndPf = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento Ex:DD/MM/AAAA");
                            string? dataNascimento = Console.ReadLine();

                            dataValida = novaPf.ValidarDataNasc(dataNascimento);

                            if (dataValida) // dataValida == true
                            {
                                DateTime.TryParse(dataNascimento, out DateTime dataConvertida);
                                novaPf.dataNasc = dataConvertida;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data váida");
                                Console.ResetColor();
                                Thread.Sleep(3000);

                            }

                        } while (!dataValida); // dataValida == false

                        Console.WriteLine($"Digite o número do CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digte o rendimento mensal (Digite somente números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPf.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEndPf.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndPf.complemento = Console.ReadLine();


                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPf.endComercial = true;
                        }
                        else
                        {
                            novoEndPf.endComercial = false;
                        }

                        novaPf.endereco = novoEndPf;

                        listaPf.Add(novaPf);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Console.ResetColor();
                        Thread.Sleep(3000);


                        break;
                    case "2":
                        
                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPf in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
Nome: {cadaPf.nome}
Endereço: {cadaPf.endereco.logradouro}, {cadaPf.endereco.numero}
Data de Nascimento: {cadaPf.dataNasc.ToString("d")}
Rendimento: {cadaPf.rendimento.ToString("C")}
Imposto a ser pago: {metodosPf.CalcularImposto(cadaPf.rendimento).ToString("C")}
");

                                Console.WriteLine($"Aperte 'ENTER' para continuar");
                                Console.ReadLine();
                            }
                        }else
                        {
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(2000);
                            
                        }

                        break;
                    case "0":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Utils.BarraCarregamento("Voltando ao menu anterior", 10, ".", 200);
                        Console.ResetColor();
                        
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção inválida, por favor digite uma opção válida");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                }


            } while (opcaoPf != "0");

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
CNPJ: {novaPj.cnpj} - Válido: {(novaPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}
            ");

            // condição ? "sim" : "não"
            Console.WriteLine($"Aperte 'ENTER' para continuar");
            Console.ReadLine();

            break;
        case "0":
            Console.Clear();
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









