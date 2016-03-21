namespace FilteringImage.Core
{
  //Структура результата для преобразования Фурье
  public struct FourierResult
  {
    public FourierResult(int m)
    {
      ReDFT = new double[m];
      ImDFT = new double[m];
      ReIDFT = new double[m];
      ImIDFT = new double[m];
      FourierSpectrum = new double[m];
      PowerSpectrum = new double[m];
    }

    public double[] ReDFT { get; set; }           //Действительная часть прямного Фурье-преобразования
    public double[] ImDFT { get; set; }           //Мнимая часть прямного Фурье-преобразования
    public double[] ReIDFT { get; set; }          //Действительная часть обратного Фурье-преобразования
    public double[] ImIDFT { get; set; }          //Мнимая часть обратного Фурье-преобразования
    public double[] FourierSpectrum { get; set; } //Спектр Фурье преобразования
    public double[] PowerSpectrum { get; set; }   //Спектр мощности (энергетический спектр)
  }
}