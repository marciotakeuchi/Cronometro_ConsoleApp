// See https://aka.ms/new-console-template for more information
Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("Cronometro regressivo");
    Console.WriteLine("Digite quanto deseja contar, acrescentando s ou m");
    Console.WriteLine("12s -> contará 12 segundos");
    Console.WriteLine("4m  -> contará 4 minutos");
    Console.WriteLine("0  -> sai do sistema");
    Console.WriteLine("Digite seu tempo desejado:");
    var resp = Console.ReadLine();

    if(resp == "0")
        System.Environment.Exit(0);

    if (ValidarOpcao(resp))
    {
        int time = CalcularSegundos(resp.ToLower());
        Start(time);
    }
    else
    {
        Console.WriteLine("tipo invalido. informe 's' ou 'm'");
        Thread.Sleep(2000);
        Menu();
    }

    Menu();
}

static bool ValidarOpcao(string resp)
{
    if (!string.IsNullOrEmpty(resp)){
        char type = Convert.ToChar(resp.Substring(resp.Length - 1, 1));
        if (type != 's' && type != 'm')
        {
        
            return false;
        }
    }
    else
    {
        return false;
    }

    return true;
   
}
static int CalcularSegundos(string resp)
{
    char type = Convert.ToChar(resp.Substring(resp.Length - 1, 1));
    int time = Convert.ToInt32(resp.Substring(0, resp.Length - 1));

    int multiplicador = 1;

    if (type == 'm')
        multiplicador = 60;

    return time * multiplicador;
}

static void Start( int totalTime)
{
    int minTime = 0;

    do
    {
        Console.Clear();
        DateTime relogio = new DateTime().AddSeconds(totalTime);
        Console.WriteLine(relogio.ToLongTimeString());
        Thread.Sleep(1000);
        totalTime--;
    } while (totalTime > minTime);
}