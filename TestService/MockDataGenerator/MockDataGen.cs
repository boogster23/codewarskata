using System.Text.Json;

namespace MockDataGenerator;

public class MockGameAnalyticsTableData
{
    public string Name { get; set; }
    public List<MockGameAnalyticsTableDataItem> MockGameAnalyticsTableDataItems { get; set; }
}

public class MockGameAnalyticsTableDataItem
{
    public string? Url { get; set; }
    public int Count { get; set; }
}


public class MockDataGeneratr
{
    public List<MockGameAnalyticsTableData> GenerateMockData()
    {
        // Set up values
        var referrerItems = new List<MockGameAnalyticsTableDataItem>
    {
        new MockGameAnalyticsTableDataItem
        {
            Url = "testing.com",
            Count = 3345
        },
        new MockGameAnalyticsTableDataItem
        {
            Url = "other.ca",
            Count = 123
        },
        new MockGameAnalyticsTableDataItem
        {
            Url = "wow.it",
            Count = 65
        },
    };

        var referrer = new MockGameAnalyticsTableData
        {
            Name = "Referrer",
            MockGameAnalyticsTableDataItems = referrerItems
        };

        var topCitiesItems = new List<MockGameAnalyticsTableDataItem>
    {
        new MockGameAnalyticsTableDataItem
        {
            Url = "Winnipeg MB",
            Count = 4345
        },
        new MockGameAnalyticsTableDataItem
        {
            Url = "New York NY",
            Count = 333
        },
        new MockGameAnalyticsTableDataItem
        {
            Url = "San Francisco CA",
            Count = 50
        },
    };

        var topCities = new MockGameAnalyticsTableData
        {
            Name = "Top Cities",
            MockGameAnalyticsTableDataItems = referrerItems
        };


        return new List<MockGameAnalyticsTableData> { referrer, topCities };
    }

    public string GenerateMockDataToJsonString()
    {
        var mockData = this.GenerateMockData();

        return JsonSerializer.Serialize(mockData);
    }
}
