using CadastroPessoa.Classes;

PessoaFisica novaPf = new PessoaFisica();


// novaPf.nome = "Diogo";
// novaPf.cpf = "1234567890";
novaPf.rendimento = 6600.5f;

// Console.WriteLine(novaPf.nome);

// Console.WriteLine("Nome: " + novaPf.nome + " - CPF: " + novaPf.cpf);
// Console.WriteLine($"Nome: {novaPf.nome} - CPF: {novaPf.cpf}");

float impostoPagar = novaPf.CalcularImposto(novaPf.rendimento);
Console.WriteLine(impostoPagar.ToString("C"));

// == igualdade
// > maior que
// < menor que
// >= maior ou igual
// <= menor ou igual
// != diferente

// && (and)
// || (or)


PessoaJuridica novaPj = new PessoaJuridica();
Console.WriteLine(novaPj.CalcularImposto(6600.5f));
