using CadastroPessoa.Classes;

// PessoaFisica novaPf = new PessoaFisica();
// Endereco novoEndPf = new Endereco();


// novaPf.nome = "Diogo";
// novaPf.cpf = "1234567890";
// novaPf.rendimento = 6600.5f;
// novaPf.dataNasc = new DateTime(2000, 01, 01);

// novoEndPf.logradouro = "Rua Yolanda Monteiro Pereira";
// novoEndPf.numero = 122;
// novoEndPf.complemento = "Jardim Santa Maria";
// novoEndPf.endComercial = false;

// novaPf.endereco = novoEndPf;

// Console.WriteLine(@$"
// Nome: {novaPf.nome}
// Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
// Maior de idade: {novaPf.ValidarDataNasc(novaPf.dataNasc)}
// ");



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


PessoaJuridica novaPj = new PessoaJuridica();
Endereco novoEndPj = new Endereco();

novaPj.nome = "Nome Pj";
novaPj.razaoSocial = "Razao Social Pj";
novaPj.cnpj = "04.900.240/0001-01";
novaPj.rendimento = 6000.5f;

novoEndPj.logradouro = "Rua Fioravante Sichieri";
novoEndPj.numero = 2452;
novoEndPj.complemento = "Jardim Paraíso";
novoEndPj.endComercial = false;

novaPj.endereco = novoEndPj;

Console.WriteLine(@$"
Nome: {novaPj.nome}
Razão Social: {novaPj.razaoSocial}
CNPJ: {novaPj.cnpj} - Válido: {novaPj.ValidarCnpj(novaPj.cnpj)}
");






