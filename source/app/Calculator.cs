using System;

namespace app
{
  public class Calculator
  {
    public int add(int i, int i1)
    {
        if(i < 0 || i1 < 0) throw new ArgumentException("Not allowed to add a negative to a positive.");
        return i + i1;
    }
  }
}