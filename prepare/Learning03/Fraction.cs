using System;

public class Fraction
{
    private int _topNum;
    private int _bottomNum;

    public Fraction()
    {//default 1/1
        _topNum= 1;
        _bottomNum= 1;
    }
    public Fraction(int wholeNumber)
    {// for whole numbers 2/1
        _topNum= wholeNumber;
        _bottomNum= 1;
    }
    public Fraction(int topNum, int bottomNum)
    {
        _topNum= topNum;
        SetBottomNum(bottomNum);
    }

    //SETTERS
    public void SetBottomNum(int bottomNum)
    {
        if (bottomNum != 0)
        {
            _bottomNum = bottomNum;
        }
        else
        {
            _bottomNum = 1;
        }
    }
      public void SetTopNum(int topNum)
    {
        _topNum = topNum;
    }

    //GETTERS
    public int GetTopNum()
    {
        return _topNum;
    }
    public int GetBottomNum()
    {
        return _bottomNum;
    }

    //GET STRINGS
    public string GetFractionString()
    {
        string showFraction= $"{_topNum}/{_bottomNum}";
        return showFraction;
    }
    public double GetDecimalValue()
    {
        return (double)_topNum / (double)_bottomNum;
    }
}