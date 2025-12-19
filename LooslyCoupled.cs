//to complile : CSC /t:library looslyCoupled.cs --> creates dll file
using System;

namespace MyRetailLogic //namespace to define a logical grouping of classes
{
    public class RetailLogic{
       public int CalcDiscount(int amount){// bydefault methods are private
        int discount = (amount)*10/100;
        return discount;
       }
    }
}