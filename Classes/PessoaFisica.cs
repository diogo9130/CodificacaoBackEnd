using CadastroPessoa.Interfaces;

namespace CadastroPessoa.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }

        public DateTime dataNasc { get; set; }

        public string caminho { get; private set; } = "Database/PessoaFisica.csv";

        public override float CalcularImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }else if (rendimento > 1500 && rendimento <= 3500)
            {
                float resultado = (rendimento / 100) * 2;

                return resultado;
            }else if (rendimento > 3500 && rendimento <=6)
            {
                float resultado = (rendimento / 100) * 3.5f;

                return resultado;
            }else
            {
                float resultado = (rendimento / 100) * 5;

                return resultado;
            }
        }
        public bool ValidarDataNasc(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }

            return false;
        }

        public bool ValidarDataNasc(string dataNasc)
        {
            
            if (DateTime.TryParse(dataNasc, out DateTime dataCovertida) == true)
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataCovertida).TotalDays / 365;

                Console.WriteLine(anos);

                if (anos >= 18)
                {
                    return true;
                }

                return false;
                
            }

            return false;
        }

        public void Inserir(PessoaFisica pf) {
            Utils.VerificarPastaArquivo(caminho);

            string[] pfValores = {$"{pf.nome}, {pf.cpf}, {pf.rendimento}, {pf.endereco.logradouro}, {pf.endereco.numero}, {pf.endereco.complemento}"};

            File.AppendAllLines(caminho, pfValores);
        }

        public List<PessoaFisica> LerArquivo(){
            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);

            // Fabio, 04.900.240/0001-01,Razao Social Pj
            // nome, cnpj, razaoSocial
            // 0, 1, 2
            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaFisica novaPf = new PessoaFisica();

                novaPf.nome = atributos[0];
                novaPf.cpf = atributos [1];
                novaPf.rendimento = int.Parse(atributos[2]);
                
                listaPf.Add(novaPf);

            }
            
            return listaPf;
        }
        
    }
}