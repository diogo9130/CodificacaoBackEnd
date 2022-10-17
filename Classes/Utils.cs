namespace CadastroPessoa.Classes
{
    public static class Utils
    {
        public static void BarraCarregamento(string texto, int repeticao, string elemento, int tempo) {
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
    }
}