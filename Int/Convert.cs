using System;
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


/// <summary>
/// Retrieves all people born after the specified date.
/// </summary>
/// <"date">The date to compare birthdays against.
/// <returns>
/// An array of <"Person"> objects representing the people
/// whose birthday is greater than the specified date. If no people
/// match the criteria, an empty array is returned.
/// </returns>
/// 

            public Person[] GetPeopleBornAfter(DateTime date) =>
            data.Where(p => p.Birthday > date).ToArray();
         

        /// <summary>
        /// Retrieves all people with the specified name from the data collection.
        /// </summary>
        /// <"name">The name to search for (case-insensitive).
        /// <returns>
        /// An array of <"Person"> objects whose <c>Name</c> matches the specified name.
        /// Returns an empty array if no matches are found.
        /// </returns>

        public Person[] GetPeopleByName(string name)
        {
            return data.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToArray();
        }


        /// <summary>
        /// Retrieves a <"Person"> from the data collection that matches the specified identifier.
        /// </summary>
        /// <"id">The unique identifier of the <"Person"> to retrieve.
        /// <returns>
        /// A <"Person"> if one is found that matches the given <"id">; otherwise, <c>null</c>.
        /// </returns>

        public Person? GetUserById(int id)
        {
            return data.FirstOrDefault(p => p.Id == id);
        }



}


