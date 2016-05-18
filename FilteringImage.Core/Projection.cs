namespace FilteringImage.Core
{
  //Структура для хранения значений проекций
  public struct Projection
  {
    public Projection(double angle, int length)
    {
      Angle = angle;
      Data = new double[length];
    }

    public double Angle;
    public double[] Data;
  }
}
