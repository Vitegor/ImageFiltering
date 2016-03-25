namespace FilteringImage.Core
{
  //Структура результата для преобразования Фурье
  public struct FourierResult
  {
    public FourierResult(int m)
    {
      Re = new double[m];
      Im = new double[m];
      ReIDFT = new double[m];
      ImIDFT = new double[m];
      Spectrum = new double[m];
    }

    public double[] Re { get; set; }           //Действительная часть прямного Фурье-преобразования
    public double[] Im { get; set; }           //Мнимая часть прямного Фурье-преобразования
    public double[] ReIDFT { get; set; }          //Действительная часть обратного Фурье-преобразования
    public double[] ImIDFT { get; set; }          //Мнимая часть обратного Фурье-преобразования
    public double[] Spectrum { get; set; } //Спектр Фурье преобразования
  }
}