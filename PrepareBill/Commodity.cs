using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PrepareBill
{
    enum CommodityCategory {
        Furniture,
        Grocery,
        Service,
    }
            
    internal class Commodity
    {

        public CommodityCategory Category{ get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }
        public Commodity(){}
        public Commodity(CommodityCategory category, string commodityName,int commodityQuantity,double commodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;
        }
    }
}
