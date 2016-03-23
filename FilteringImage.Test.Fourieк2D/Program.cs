using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FilteringImage.Core;

namespace FilteringImage.Test.Fourier2D
{
  class Program
  {
    static void Main(string[] args)
    {
      int m = 15;
      int n = 10;
      double[][] a = new double[n][];

      FourierResult[] result = new FourierResult[n];

      Console.WriteLine("========== Исходная функция ==========");
      for(int i = 0; i <= n - 1; i++)
      {
        a[i] = new double[m];
        for(int j = 0; j <= m - 1; j++)
        {
          a[i][j] = 1;
          Console.Write("{0} ", a[i][j]);
        }
        Console.WriteLine();
      }
      Console.WriteLine();

      result = Fourier.DFT2D(a);

      Console.WriteLine();

      Console.WriteLine("========== Действительная часть ==========");
      for(int i = 0; i <= n - 1; i++)
      {
        FourierResult r = result[i];
        foreach(var item in r.Re)
        {
          Console.Write("{0} ", Math.Round(item, 0));
        }
        Console.WriteLine();
      }
      Console.WriteLine();

      Console.WriteLine("========== Мнимая часть ==========");
      for(int i = 0; i <= n - 1; i++)
      {
        FourierResult r = result[i];
        foreach(var item in r.Im)
        {
          Console.Write("{0} ", Math.Round(item, 0));
        }
        Console.WriteLine();
      }
      Console.WriteLine();

      Console.WriteLine("========== Спектр ==========");
      for(int i = 0; i <= n - 1; i++)
      {
        FourierResult r = result[i];
        foreach(var item in r.Spectrum)
        {
          Console.Write("{0} ", Math.Round(item, 0));
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }
}
