var content = File.ReadAllText("Input.txt");
var ranges = content.Split(',');

long InvalidIds = 0;

foreach (var range in ranges)
{
    var start = long.Parse(range.Split('-')[0]);
    var end = long.Parse(range.Split("-")[1]);
    for(long id = start; id < end; id++)
    {
        var idString = id.ToString();
        if (idString.Length % 2 != 0) continue;

        var left = idString[..(idString.Length / 2)];
        var right = idString[(idString.Length / 2)..];

        if (left == right) InvalidIds += id;

    }
}

Console.WriteLine(InvalidIds);
