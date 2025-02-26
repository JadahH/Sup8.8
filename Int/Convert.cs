﻿using System;
using System.Linq;

namespace Int;

    /// <summary>
/// Represents a person with an identifier, name, and birthday.
/// </summary>
/// "Id" Unique identifier for the person.
/// "Name" The name of the person.
/// "Birthday" The birthday of the person
/// 

public record Person(int Id, string Name, DateTime Birthday);
public class Convert
{
    private Person[] data;

/// <summary>
    /// Initializes the internal data collection with a million "Person" records.
    /// </summary>
    /// <remarks>
    /// This method generates "Person" records with unique identifiers from 1 to 1,000,000.
    /// Every 1000th record is assigned the name "Jane Doe", while all other records follow the naming pattern "Person_{id}".
    /// The birthday for each person is randomly assigned to a date between January 1, 1950, and December 31, 2000.
    /// </remarks>
    /// <returns>This method does not return a value.</returns>


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

        public Person? GetUserById(int id)
        {
            return data.FirstOrDefault(p => p.Id == id);
        }



}


