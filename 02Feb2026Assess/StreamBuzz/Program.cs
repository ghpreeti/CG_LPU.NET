// See https://aka.ms/new-console-template for more information
using System;
using StreamBuzz;

class Program
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        if (records == null || records.Count == 0)
        {
            return dict;
        }

        foreach (var record in records)
        {
            if (record.WeeklyLikes == null)
            {
                continue;
            }
            int count = 0;
            foreach (var likes in record.WeeklyLikes)
            {
                if (likes > likeThreshold)
                {
                    count++;
                }

            }
            if (count > 0)
            {
                dict.Add(record.CreatorName, count);
            }

        }
        return dict;
    }

    public double CalculateAverageLikes()
    {
        double likes = 0;
        int count = 0;

        foreach (var r in EngagementBoard)
        {
            if (r.WeeklyLikes == null)
            {
                continue;
            }
            foreach (var like in r.WeeklyLikes)
            {
                likes += like;
                count++;
            }
        }
        return likes / count;
    }

    public static void Main(string[] args)
    {
        Program app = new Program();   // ✔ Program object
        bool run = true;

        while (run)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine();

                    double[] likes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    CreatorStats cs = new CreatorStats
                    {
                        CreatorName = name,
                        WeeklyLikes = likes
                    };

                    app.RegisterCreator(cs);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    Dictionary<string, int> result =
                        app.GetTopPostCounts(EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Key + " " + item.Value);
                        }
                    }
                    break;

                case 3:
                    double avg = app.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + avg);
                    break;

                case 4:
                    Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                    run = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
    

}
