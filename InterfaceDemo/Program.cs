// See https://aka.ms/new-console-template for more information


using InterfaceDemo;

//IAdd m1 = new MathClass();//Add
//IAddSub m2 = new MathClass();//add and sub
//IAll m3 = new MathClass();//all

//m1.AddMe(10, 20);

//approach1
Product pObj = new Product();
pObj.ProdID = 101;
pObj.Name = "Flask";
pObj.Price = 850;

//approach2-Object initializer
Product pObj2 = new Product() { ProdID = 102, Name = "Thermos", Price = 1200 };

//approach3-collection initializer
List<Product> prodList = new List<Product>()
{
    new Product(){ProdID=101,Name="Lotion",Price=1350},
    new Product(){ProdID=102,Name="Perfume",Price=500},
    new Product(){ProdID=103,Name="Mop",Price=1300},
    new Product(){ProdID=104,Name="Mat",Price=100},
    new Product(){ProdID=105,Name="Bowl",Price=130},
    new Product(){ProdID=106,Name="Note",Price=150},
    new Product(){ProdID=107,Name="Cloack",Price=350},
};

foreach(var item in prodList)
{
    Console.WriteLine($"{item.ProdID}\t{item.Name}\t{item.Price}");
}




{

}

