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
        SetBottom(bottomNum);
    }
    public void SetBottom(int bottomNum)
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
}