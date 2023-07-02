using System;

namespace guessing_number;

public class GuessNumber
{
  //In this way we are passing the random number generator by dependency injection
  private IRandomGenerator random;
  public GuessNumber() : this(new DefaultRandom()) { }
  public GuessNumber(IRandomGenerator obj)
  {
    this.random = obj;

    userValue = 0;
    randomValue = 0;
  }

  //user variables
  public int userValue;
  public int randomValue;

  public int maxAttempts = 5;
  public int currentAttempts;

  public int difficultyLevel = 1;

  public bool gameOver = false;

  //1 - Imprima uma mensagem de saudação
  public string Greet()
  {
    return "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
  }

  //2 - Receba a entrada da pessoa usuária e converta para Int
  //5 - Adicione um limite de tentativas.
  public string ChooseNumber(string userEntry)
  {

    currentAttempts += 1;

    if (currentAttempts > maxAttempts)
    {
      return "Você excedeu o número máximo de tentativas! Tente novamente.";
    }


    if (!int.TryParse(userEntry, out int number))
    {

      return "Entrada inválida! Não é um número.";
    }

    if (number < -100 || number > 100)
    {
      userValue = 0;
      return "Entrada inválida! Valor não está no range.";
    }

    userValue = number;
    gameOver = true;
    return "Número escolhido!";

  }

  //3 - Gere um número aleatório
  public string RandomNumber()
  {
    randomValue = random.GetInt(-100, 100);
    return "A máquina escolheu um número de -100 à 100!";
  }

  //6 - Adicione níveis de dificuldade
  public string RandomNumberWithDifficult()
  {
    switch (difficultyLevel)
    {
      case 2:
        return "A máquina escolheu um número de -500 à 500!";
      case 3:
        return "A máquina escolheu um número de -1000 à 1000!";
      default:
        return "A máquina escolheu um número de -100 à 100!";
    }
  }

  //4 - Verifique a resposta da jogada
  public string AnalyzePlay()
  {
    if (gameOver == true)
    {
      return "O jogo terminou. Deseja jogar novamente?";
    }

    if (userValue < randomValue)
    {
      return "Tente um número MAIOR";
    }
    else if (userValue > randomValue)
    {
      return "Tente um número MENOR";
    }
    else
    {
      return "ACERTOU!";
    }
  }

  //7 - Adicione uma opção para reiniciar o jogo
  public void RestartGame()
  {
    userValue = 0;
    randomValue = 0;
    currentAttempts = 0;
    difficultyLevel = 1;
    maxAttempts = 5;
    gameOver = false;
  }
}