var content = File.ReadAllText("Input.txt");
var ranges = content.Split(',');

List<long> InvalidIds = [];

foreach (var range in ranges)
{
    var start = long.Parse(range.Split('-')[0]);
    var end = long.Parse(range.Split("-")[1]);
    for(long id = start; id <= end; id++)
    {
        var idString = id.ToString();
        
        for(int i = 0; i < idString.Length / 2; i++)
        {
            var pairs = new List<string>();

            var pair = idString[..(i + 1)];
            if (idString.Length % pair.Length != 0) continue;

            for (int j = 0; j < idString.Length; j += pair.Length)
            {
                pairs.Add(idString.Substring(j, pair.Length));
            }

            if (pairs.All(p => p == pair) && !InvalidIds.Contains(id))
            {
                InvalidIds.Add(id);
            }
        }
    }
}

Console.WriteLine(InvalidIds.Sum());
