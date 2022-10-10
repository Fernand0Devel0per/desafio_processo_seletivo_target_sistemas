int INDICE = 13, SOMA = 0, K = 0;

while (K < INDICE)
{
    K = K + 1;
    SOMA = SOMA + K;
}

Console.WriteLine(SOMA);

int inicial = 0, somador = 1;
Console.WriteLine("Digite por favor o valor a ser consultado");
int resultado = int.Parse(Console.ReadLine());

while (somador < resultado)
{
    int provisorio = somador;
    somador += inicial;
    inicial = provisorio;
}

if (somador == resultado)
{
    Console.WriteLine("pertence a sequência.");
}
else
{
    Console.WriteLine("não pertence a sequência.");
}