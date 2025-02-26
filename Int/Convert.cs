using System;
using System.Linq;

namespace Int;

    
public record Person(int Id, string Name, DateTime Birthday);
public class Convert
{
    private Person[] data;

     public void InitializeData()
        {
            Random random = new Random();
            DateTime startDate = new DateTime(1950, 1, 1);
            int totalDays = (new DateTime(2000, 12, 31) - startDate).Days;

            data = Enumerable.Range(1, 1000000)
                .Select(i => new Person(
                    Id: i,
                    Name: (i % 1000 == 0) ? "Jane Doe" : $"Person_{i}",
                    Birthday: startDate.AddDays(random.Next(totalDays))
                ))
                .ToArray();
        }

            public Person[] GetPeopleBornAfter(DateTime date) =>
            data.Where(p => p.Birthday > date).ToArray();
         

        public Person[] GetPeopleByName(string name)
        {
            return data.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToArray();
        }




}


