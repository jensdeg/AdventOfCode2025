var content = File.ReadAllText("Input.txt");
var lines = content.Split(Environment.NewLine);

var DialNumber = 50;
var ZeroCount = 0;

foreach(var line in lines)
{
    if (line.StartsWith('L'))
    {
        int value = int.Parse(line.Split('L')[1]);
        Subtract(value);
    }
    else
    {
        int value = int.Parse(line.Split('R')[1]);
        Add(value);
    }
}

Console.WriteLine(ZeroCount);


void Subtract(int count)
{
    for(int i = 0; i < count; i++)
    {
        DialNumber--;
        if(DialNumber < 0)
        {
            DialNumber = 99;
        }
    }
    if(DialNumber == 0) ZeroCount++;
}

void Add(int count)
{
    for (int i = 0; i < count; i++)
    {
        DialNumber++;
        if (DialNumber > 99)
        {
            DialNumber = 0;
        }
    }
    if (DialNumber == 0) ZeroCount++;
}