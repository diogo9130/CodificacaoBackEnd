using System.Text.RegularExpressions;
using CadastroPessoa.Interfaces;

namespace CadastroPessoa.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? cnpj { get; set; }

        public string? razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";

        public override float CalcularImposto(float rendimento)
        
        {
            if (rendimento <= 3000)
            {
                return rendimento * .03f;

            } else if (rendimento <= 6000)
            {
                return rendimento * .05f;

            }else if (rendimento <= 10000)
            {
                return rendimento * .07f;

            }else
            {
                return rendimento * .09f;

            }
        }
        
        // XX.XXX.XXX/0001-XX
        // XXXXXXXX0001XX
        public bool ValidarCnpj(string cnpj)
        {
            bool retornoCnpjValido = Regex.IsMatch(cnpj, @"(^(\d{14}?)|(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})$)");

            //if(retornoCnpjValido == true)
            if (retornoCnpjValido)
            {

                if (cnpj.Length == 14)
                {
                    string subStringCnpj14 = cnpj.Substring(8, 4);

                    if (subStringCnpj14 == "0001")
                    {
                        return true;
                    }
                    return false;
                }

                string subStringCnpj18 = cnpj.Substring(11, 4);

                if (subStringCnpj18 == "0001")
                {
                    return true;
                }
            }

            return false;
        }

        public void Inserir(PessoaJuridica pj) {
            Utils.VerificarPastaArquivo(caminho);

            string[] pjValores = {$"{pj.nome}, {pj.cnpj},{pj.razaoSocial}, {pj.rendimento}, {pj.endereco.logradouro}, {pj.endereco.numero}, {pj.endereco.complemento}"};

            File.AppendAllLines(caminho, pjValores);
        }
        
        // Transforma o arquivo em uma lista
        public List<PessoaJuridica> LerArquivo(){
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            // Fabio, 04.900.240/0001-01,Razao Social Pj
            // nome, cnpj, razaoSocial
            // 0, 1, 2
            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica novaPj = new PessoaJuridica();

                novaPj.nome = atributos[0];
                novaPj.razaoSocial = atributos [1];
                novaPj.cnpj = atributos [2];
                novaPj.rendimento = int.Parse(atributos[3]);
                
                listaPj.Add(novaPj);

            }
            
            return listaPj;
        }
    }
}