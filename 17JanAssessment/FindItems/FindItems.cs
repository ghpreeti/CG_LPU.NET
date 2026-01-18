using System;
namespace FindItems{

public class Program
{
    public static SortedDictionary<String,long> itemDetails = new SortedDictionary<String,long>();
   
 public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result =
                new SortedDictionary<string, long>();

            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return result;
        }

public static List<string> FindMinAndMaxSoldItem(){
 
       List<string> result = new List<string>();
       var resultMax = itemDetails.Max(s=>s.Value).ToString();
       var resultMin = itemDetails.Min(s=>s.Value).ToString();
         
       result.Add(resultMax);
       result.Add(resultMin);
      return result;
}

public static Dictionary<string,long> SortByCount(){
	var result = itemDetails.OrderBy(s=>s.Value).ToList();
        Dictionary<string,long> ans = new Dictionary<string,long>();
	foreach(var item in result){
	   ans.Add(item.Key,item.Value);
		
	}
      return ans;
}

  
   public static void Main(){
   
	Console.WriteLine("Enter sold Item Details");
        for(int i=0;i<3;i++){
	  Console.WriteLine("enter name of item and its soldCount");
          string name = Console.ReadLine();
          long soldCount = long.Parse(Console.ReadLine());
          itemDetails.Add(name,soldCount);
	}
         
       Console.WriteLine("\nEnter soldCount to search:");
            long searchCount = long.Parse(Console.ReadLine());

            var foundItems = FindItemDetails(searchCount);
            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold Count");
            }
            else
            {
                foreach (var item in foundItems)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }
        
       Console.WriteLine("Output of FindMinAndMaxSoldItem()---");
           var result = FindMinAndMaxSoldItem();
foreach(var item in result){
   Console.WriteLine(item);
}
           
       Console.WriteLine("Output of SortByCount()---");
           var result2 = SortByCount();
foreach(var item in result2){
   Console.WriteLine($"{item.Key} : {item.Value}");
}

 	}



}
}