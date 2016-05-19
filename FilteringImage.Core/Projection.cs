namespace FilteringImage.Core
{
  //Структура для хранения значений проекций
  public struct Projections
  {
    public Projections(int pointsCount, int projectionsCount, double angularStep, int length)
    {
      PointsCount = pointsCount;
      ProjectionsCount = projectionsCount;
      AngularStep = angularStep;
      Data = new double[length];
    }

    public int PointsCount;
    public int ProjectionsCount;
    public double AngularStep;
    public double[] Data;
  }
}
