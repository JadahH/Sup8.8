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
}