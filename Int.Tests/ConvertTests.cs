using System;
using System.Linq;
using Xunit;

namespace Int.Tests;

public class ConvertTests
{
    private readonly Convert repository
    
    /// <summary>
    /// Initializes a new instance of the "ConvertTests"class.
    /// </summary>
    /// <remarks>
    /// This constructor creates a new "Convert" instance and calls its InitializeData method 
    /// to prepare the data required for testing.
    /// </remarks>
    /// 
        public Convert(){
        repository = new Convert();
        repository.InitializeData();
    }

    /// <summary>
/// Tests that the GetPeopleBornAfter method returns only people whose birthdays are after the specified date.
/// </summary>
/// <remarks>
/// This test sets a reference date (January 1, 1980) and then asserts that every person returned by 
/// repository.GetPeopleBornAfter(testDate) has a Birthday greater than the test date.
/// </remarks>
/// <returns>This test method does not return any value.</returns>

    [Fact]
    public void GetPeopleBornAfter_ShouldReturnOnlyPeopleBornAfterSpecifiedDate()()
    {

        DateTime testDate = new DateTime(1980, 1, 1);
        var results = repository.GetPeopleBornAfter(testDate);
         Assert.All(results, p => Assert.True(p.Birthday > testDate));

    }

     [Fact]
        public void GetPeopleByName_ShouldReturnMatchingPeople_WhenFound()
        {
            // Arrange - "Jane Doe" is expected for persons with Id divisible by 1000.
            string name = "Jane Doe";

            // Act
            var results = repository.GetPeopleByName(name);

            // Assert: Verify that the results are not empty and that each person has the expected name.
            Assert.NotEmpty(results);
            Assert.All(results, p => Assert.Equal(name, p.Name, ignoreCase: true));
        }

     [Fact]
        public void GetUserById_ShouldReturnPerson_WhenValidIdProvided()
        {
            // Arrange
            int validId = 250000;

            // Act
            var person = repository.GetUserById(validId);

            // Assert: The returned person is not null and has the expected ID.
            Assert.NotNull(person);
            Assert.Equal(validId, person.Id);
        }

    [Fact]
        public void GetUserById_ShouldReturnNull_WhenInvalidIdProvided()
        {
            // Arrange
            int invalidId = 1000001;

            // Act
            var person = repository.GetUserById(invalidId);

            // Assert: No person should be found for an invalid ID.
            Assert.Null(person);
        }
    }
