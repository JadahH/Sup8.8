using System;
using System.Linq;
using Xunit;

namespace Int.Tests;

public class ConvertTests
{
    private readonly Convert repository
    
        public Convert(){
        repository = new Convert();
        repository.InitializeData();
    }


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

     
}