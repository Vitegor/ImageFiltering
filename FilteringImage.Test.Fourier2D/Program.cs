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
      int m = 5;
      int n = 5;
      if(!Fourier.IsEven(m)) m = m - 1;
      if(!Fourier.IsEven(n)) n = n - 1;
      double[,] fxy = new double[n,m];

      Console.WriteLine("========== Исходная функция ==========");

      for(int i = 0; i <= n - 1; i++)
      {
        for(int j = 0; j <= m - 1; j++) fxy[i, j] = 1;
      }

      PrintArray(fxy);

      for(int i = 0; i <= n - 1; i++)
      {
        for(int j = 0; j <= m - 1; j++) fxy[i, j] = fxy[i, j] * Fourier.Step(i + j);
      }

      FourierResult[] result = Fourier.DFT2D(fxy);

      double[] fx = new double[m];
      for(int i = 0; i <= m - 1; i++) fx[i] = fxy[0, i];

      Console.WriteLine("========== Действительная часть (2D) ==========");
      PrintRe(result);

      Console.WriteLine("========== Мнимая часть (2D) ==========");
      PrintIm(result);

      Console.WriteLine("==========Спектр (2D) ==========");
      PrintSpectrum(result);
    }

    private static void PrintArray(double[,] array)
    {
      int length = array.GetLength(0) - 1;
      int height = array.GetLength(1) - 1;

      for(int i = 0; i <= length; i++)
      {
        for(int j = 0; j <= height; j++)
        {
          Console.Write("{0} ", array[i, j]);
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    private static void PrintRe(FourierResult[] fourierResult)
    {
      foreach(FourierResult r in fourierResult)
      {
        foreach(double value in r.Re)
        {
          Console.Write("{0} ", Math.Round(value, 0));
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    private static void PrintIm(FourierResult[] fourierResult)
    {
      foreach(FourierResult r in fourierResult)
      {
        foreach(double value in r.Im)
        {
          Console.Write("{0} ", Math.Round(value, 0));
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    private static void PrintSpectrum(FourierResult[] fourierResult)
    {
      foreach(FourierResult r in fourierResult)
      {
        foreach(double value in r.Spectrum)
        {
          Console.Write("{0} ", Math.Round(value, 0));
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }
}
