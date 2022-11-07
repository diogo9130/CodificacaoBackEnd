namespace CadastroPessoa.Classes
{
    public static class Utils
    {
        public static void BarraCarregamento(string texto, int repeticao, string elemento, int tempo)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(texto);

            for (int contador = 0; contador < repeticao; contador++)
            {
                Thread.Sleep(tempo);
                Console.Write(elemento);

            }
            Console.ResetColor();
        }

        public static void VerificarPastaArquivo(string caminho)
        {

            // string pasta = Database;
            string pasta = caminho.Split("/")[0];

            // Se a pasta não existe
            if (!Directory.Exists(pasta))
            {
                // Cria a pasta baseada com o nome que chegou no caminho
                Directory.CreateDirectory(pasta);
            }

            // Se o arquivo não existir
            if (!File.Exists(caminho))
            {
                // Cria o arquivo baseado com o nome que chegou no caminho
                using (File.Create(caminho))
                {

                }
            }
        }
    }


}