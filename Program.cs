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

                PessoaFisica metodosPf = new PessoaFisica();
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
                            Console.Clear();
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
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data válida");
                                Console.ResetColor();
                                Thread.Sleep(3000);

                            }

                        } while (!dataValida); // dataValida == false

                        Console.Clear();
                        Console.WriteLine($"Digite o número do CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digte o rendimento mensal (Digite somente números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine($"Digite o logradouro");
                        novoEndPf.logradouro = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digite o número");
                        novoEndPf.numero = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndPf.complemento = Console.ReadLine();
                        
                        Console.Clear();
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

                        metodosPf.Inserir(novaPf);
                        
                        // listaPf.Add(novaPf);

                        // // Instanciar o StreamWriter - Criando um arquivo
                        // StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
                        // // Inserindo o nome em uma linha do arquivo txt
                        // sw.WriteLine(novaPf.nome);
                        // // Fechando o sw
                        // sw.Close();
                        

                        // Enquanto usar o SW não fecha
                        // using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        // {
                        //     sw.WriteLine(@$"
                        //     Nome: {novaPf.nome}
                        //     Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
                        //     Data de nascimento: {novaPf.dataNasc.ToString("d")}
                        //     Rendimento: {novaPf.rendimento.ToString("C")}
                        //     Imposto a ser pago: {metodosPf.CalcularImposto(novaPf.rendimento).ToString("C")}"
                        //     );
                        //     // Depois que não tem mais nada sendo usado pelo recurso (SW) ele fecha
                        // }

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Console.ResetColor();
                        Thread.Sleep(3000);


                        break;
                    case "2":
                        
                        Console.Clear();

//                         if (listaPf.Count > 0)
//                         {
//                             foreach (PessoaFisica cadaPf in listaPf)
//                             {
//                                 Console.Clear();
//                                 Console.WriteLine(@$"
// Nome: {cadaPf.nome}
// Endereço: {cadaPf.endereco.logradouro}, {cadaPf.endereco.numero}
// Data de Nascimento: {cadaPf.dataNasc.ToString("d")}
// Rendimento: {cadaPf.rendimento.ToString("C")}
// Imposto a ser pago: {metodosPf.CalcularImposto(cadaPf.rendimento).ToString("C")}
// ");

//                                 Console.WriteLine($"Aperte 'ENTER' para continuar");
//                                 Console.ReadLine();
//                             }
//                         }else
//                         {
//                             Console.WriteLine($"Lista vazia");
//                             Thread.Sleep(2000);
                            
//                         }

                        // using (StreamReader sr = new StreamReader("Diogo.txt"))
                        // {
                        //     string linha;

                        //     while ((linha = sr.ReadLine()) != null)
                        //     {
                        //         Console.WriteLine($"{linha}");
                        //     }
                        // }

                        List<PessoaFisica> listaExibicaoPf = metodosPf.LerArquivo();

                        foreach (PessoaFisica cadaItem in listaExibicaoPf)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
Nome: {cadaItem.nome}
CPF: {cadaItem.cpf}
Rendimento: {cadaItem.rendimento.ToString("C")}
            ");
                        }

                        Console.WriteLine($"Aperte 'Enter' para continuar...");
                        Console.ReadLine();
                        

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
            // PessoaJuridica metodosPj = new PessoaJuridica();
            // PessoaJuridica novaPj = new PessoaJuridica();
            // Endereco novoEndPj = new Endereco();

            // novaPj.nome = "Fabio";
            // novaPj.razaoSocial = "Razao Social Pj";
            // novaPj.cnpj = "04.900.240/0001-01";
            // novaPj.rendimento = 6000.5f;

            // novoEndPj.logradouro = "Rua Fioravante Sichieri";
            // novoEndPj.numero = 2452;
            // novoEndPj.complemento = "Jardim Paraíso";
            // novoEndPj.endComercial = false;

            // novaPj.endereco = novoEndPj;

            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
===========================================
|       Escolha uma das opções abaixo     |
|-----------------------------------------|
|       1 - Cadastrar Pessoa Jurídica     |
|       2 - Listar Pessoa Jurídica        |
|                                         |
|       0 - Voltar ao menu anterior       |
===========================================
");

                opcaoPj = Console.ReadLine();

                PessoaJuridica metodosPj = new PessoaJuridica();
                PessoaJuridica novaPj = new PessoaJuridica();
                Endereco novoEndPj = new Endereco();

                switch (opcaoPj)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar");
                        novaPj.nome = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digite a razão social");
                        novaPj.razaoSocial = Console.ReadLine();
                        
                        bool cnpjValido;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"Digite o CNPJ");
                            string? cnpj = Console.ReadLine();
                            
                            
                            cnpjValido = novaPj.ValidarCnpj(cnpj);

                            if (cnpjValido)
                            {
                                novaPj.cnpj = cnpj;
                            }else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválido, por favor digite uma CNPJ válido");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                            }
                            
                        } while (!cnpjValido);

                        Console.Clear();
                        Console.WriteLine($"Digte o rendimento mensal (Digite somente números)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        float impostoPagar = novaPj.CalcularImposto(novaPj.rendimento);

                        Console.Clear();
                        Console.WriteLine($"Digite o logradouro");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digite o número");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.Clear();                       
                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPj.endComercial = true;
                            
                        } else
                        {
                            novoEndPj.endComercial = false;
                        }

                        novaPj.endereco = novoEndPj;

                        metodosPj.Inserir(novaPj);

                        // using (StreamWriter sw = new StreamWriter("Diogo.txt"))
                        // {
                        //     sw.WriteLine(@$"
                        //     Nome: {novaPj.nome}
                        //     Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero}
                        //     Rendimento: {novaPj.rendimento.ToString("C")}
                        //     Imposto a ser pago: {metodosPf.CalcularImposto(novaPj.rendimento).ToString("C")}"
                        //     );

                        // Console.Clear();
                        // Console.ForegroundColor = ConsoleColor.DarkGreen;
                        // Console.WriteLine($"Cadastro realizado com sucesso");
                        // Console.ResetColor();
                        // Thread.Sleep(3000);

                        // }
                        break;
                    case "2":
                        

                        List<PessoaJuridica> listaExibicaoPj = metodosPj.LerArquivo();

                        foreach (PessoaJuridica cadaItem in listaExibicaoPj)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
Nome: {cadaItem.nome}
Razão Social: {cadaItem.razaoSocial}
CNPJ: {cadaItem.cnpj}
Rendimento: {cadaItem.rendimento.ToString("C")}
            ");
                        }

                            // using (StreamReader sr = new StreamReader("Diogo.txt"))
                            // {
                            //     string linha;

                            //     while ((linha = sr.ReadLine()) != null)
                            //     {
                            //         Console.WriteLine($"{linha}");
                            //     }
                            // }

                            Console.WriteLine($"Aperte 'ENTER' para continuar");
                            Console.ReadLine();

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
                

            } while (opcaoPj != "0");
//             Console.Clear();
//             Console.WriteLine(@$"
// Nome: {novaPj.nome}
// Razão Social: {novaPj.razaoSocial}
// CNPJ: {novaPj.cnpj} - Válido: {(novaPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}
//             ");

            
//             // condição ? "sim" : "não"
            

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









