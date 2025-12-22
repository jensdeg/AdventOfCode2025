var content = File.ReadAllText("Input.txt");
var batteries = content.Split(Environment.NewLine);

List<long> joltages = [];

foreach(var battery in batteries)
{
    List<int> numbers = [];
    foreach (var number in battery)
    {
        numbers.Add(int.Parse(number.ToString()));
    }

    List<int> joltageList = [];
    var index = 0;
    List<int> newlist = [];
    for (int i = 12; i > 0; i--)
    {
        if(i == 12)
        {
            var firstnumber = FindHighestNumber(numbers, i);
            joltageList.Add(firstnumber);
            index = numbers.IndexOf(firstnumber);
            newlist = numbers[(index + 1)..];
        }
        else
        {
            var number = FindHighestNumber(newlist, i + 1);
            joltageList.Add(number);
            index = newlist.IndexOf(number);
            newlist = newlist[(index + 1)..];
        }       
    }

    var joltageString = string.Empty;
    joltageList.ForEach(n => joltageString += n.ToString());

    joltages.Add(long.Parse(joltageString));
}

int FindHighestNumber(List<int> numbers, int batteryLength, List<int> checkednumbers = null)
{
    checkednumbers ??= [];

    var Highest = numbers
        .OrderDescending()
        .Where(n => !checkednumbers.Contains(n))
        .First();

    var index = numbers.IndexOf(Highest);

    if (index > numbers.Count - (batteryLength - 1))
    {
        checkednumbers.Add(Highest);
        return FindHighestNumber(numbers, batteryLength, checkednumbers);
    }
    else return Highest;
}

Console.WriteLine(joltages.Sum());