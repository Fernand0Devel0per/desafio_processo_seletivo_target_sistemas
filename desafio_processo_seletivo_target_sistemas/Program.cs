using desafio_processo_seletivo_target_sistemas;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Text;

/*

1) Observe o trecho de código abaixo:

	int INDICE = 13, SOMA = 0, K = 0;

	enquanto K < INDICE faça
	{
		K = K + 1;
		SOMA = SOMA + K;
	}

	imprimir(SOMA);

Ao final do processamento, qual será o valor da variável SOMA?
*/

int INDICE = 13, SOMA = 0, K = 0;

while (K < INDICE)
{
    K = K + 1;
    SOMA = SOMA + K;
}

Console.WriteLine(SOMA);


/*

2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

IMPORTANTE: 
	Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;
*/
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

/*

3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
	• O menor valor de faturamento ocorrido em um dia do mês;
	• O maior valor de faturamento ocorrido em um dia do mês;
	• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

IMPORTANTE:
	a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
	b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;
*/


string content = File.ReadAllText("C:\\Users\\fhlot\\Desktop\\desafio_processo_seletivo_target_sistema\\desafio_processo_seletivo_target_sistemas\\dados.json");
List<Faturamento> faturamento = JsonConvert.DeserializeObject<List<Faturamento>>(content);

Faturamento menorFaturamento = null;

foreach (var item in faturamento)
{
    if (item.Valor > 0)
    {
        if (menorFaturamento == null)
        {
            menorFaturamento = item;
        }
        if (item.Valor < menorFaturamento.Valor)
        {
            menorFaturamento = item;
        }
    }
}

Faturamento maiorFaturamento = null;

foreach (var item in faturamento)
{
    if (item.Valor > 0)
    {
        if (maiorFaturamento == null)
        {
            maiorFaturamento = item;
        }
        if (item.Valor > maiorFaturamento.Valor)
        {
            maiorFaturamento = item;
        }
    }
}


int media = 0;
double somadorDiasMedias = 0;

foreach (var item in faturamento)
{
    if (item.Valor > 0)
    {
        somadorDiasMedias += item.Valor;
        media++;
    }
}

somadorDiasMedias = media / somadorDiasMedias;

int diasMaiorMedia = 0;

foreach (var item in faturamento)
{
    if (somadorDiasMedias < item.Valor)
    {
        diasMaiorMedia++;
    }
}

StringBuilder sb = new StringBuilder();
sb.AppendLine($"Menor Faturamento Dia:{menorFaturamento.Dia} Valor:{menorFaturamento.Valor}");
sb.AppendLine($"Maoir Faturamento Dia:{maiorFaturamento.Dia} Valor:{maiorFaturamento.Valor}");
sb.AppendLine($"Dias totais que o faturamento foi maior que a media:{diasMaiorMedia}");

Console.WriteLine(sb.ToString());

/*
4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:

	SP – R$67.836,43
	RJ – R$36.678,66
	MG – R$29.229,88
	ES – R$27.165,48
	Outros – R$19.849,53

Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.
*/

double SP = 67836.43d;

double RJ = 36678.66d;

double MG = 29229.88d;

double ES = 27165.48d;

double Outros = 19849.53d;

double total = SP + RJ + MG + ES + Outros;

StringBuilder sb2 = new StringBuilder();

sb2.AppendLine($"SP Percentual de representação: {(SP/total).ToString("0.00").Substring(2)}%");
sb2.AppendLine($"RJ Percentual de representação: {(RJ/total).ToString("0.00").Substring(2)}%");
sb2.AppendLine($"MG Percentual de representação: {(MG/total).ToString("0.00").Substring(2)}%");
sb2.AppendLine($"ES Percentual de representação: {(ES/total).ToString("0.00").Substring(2)}%");
sb2.AppendLine($"Outros Percentual de representação: {(Outros/total).ToString("0.00").Substring(2)}%");

Console.WriteLine(sb2.ToString());

/*
5) Escreva um programa que inverta os caracteres de um string.

IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;
*/


Console.WriteLine("Informe a palavra a ser invertida");
string stringInicial = Console.ReadLine();

StringBuilder sb3 = new StringBuilder();          

for (var i = stringInicial.Length - 1; i >= 0; i--)
{
    sb3.Append(stringInicial[i]);
}

Console.WriteLine(sb3.ToString());

