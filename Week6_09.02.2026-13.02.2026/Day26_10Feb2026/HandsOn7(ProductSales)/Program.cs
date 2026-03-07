using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main()
  {
    var records = new Dictionary<string, int>();
    string line;
    while ((line = Console.ReadLine()) != null && line.Trim() != "")
    {
      var parts = line.Split('-');
      string id = parts[0];
      int sales = int.Parse(parts[1]);
      if (!records.ContainsKey(id) || records[id] < sales)
      {
        records[id] = sales;
      }
    }
    var sorted = records.OrderByDescending(x => x.Value);
    foreach (var r in sorted)
    {
      Console.WriteLine($"{r.Key}-{r.Value}");
    }
  }
}
