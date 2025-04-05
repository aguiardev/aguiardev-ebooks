Console.WriteLine("Digite 5 notas:");
double soma = 0, maiorNota = 0, menorNota = 10;

for (int i = 1; i <= 5; i++)
{
  Console.Write("Nota " + i + ": ");
  double nota = double.Parse(Console.ReadLine());

  while (nota < 0 || nota > 10)
  {
    Console.Write("Nota inválida. Digite novamente: ");
    nota = double.Parse(Console.ReadLine());
  }

  soma += nota;

  if (nota > maiorNota)
    maiorNota = nota;

  if (nota < menorNota)
    menorNota = nota;
}

double media = soma / 5;

Console.WriteLine("A média das notas é: " + media);
Console.WriteLine("A maior nota é: " + maiorNota);
Console.WriteLine("A menor nota é: " + menorNota);