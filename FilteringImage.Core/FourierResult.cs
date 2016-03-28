namespace FilteringImage.Core
{
  //Класс результата для прямого преобразования Фурье
  public class FourierResult : InvertedFourierResult
  {
    public FourierResult(int m) : base(m)
    {
      Spectrum = new double[m];
    }

    public double[] Spectrum { get; set; } //Спектр Фурье преобразования
  }

  //Класс результата для обратного преобразования Фурье
  public class InvertedFourierResult
  {
    public InvertedFourierResult(int m)
    {
      Re = new double[m];
      Im = new double[m];
    }

    public double[] Re { get; set; }
    public double[] Im { get; set; }
  }
}