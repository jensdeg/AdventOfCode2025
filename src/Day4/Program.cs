var content = File.ReadAllText("Input.txt");
var lines = content.Split(Environment.NewLine);

var sizeX = lines[0].ToString().Length;
var sizeY = lines.Length;

char?[,] grid = new char?[sizeX, sizeY];

var validRolls = 0;
var canRemoveRolls = true;


for (int x = 0; x < sizeX; x++)
{
    for (int y = 0; y < sizeY; y++)
    {
        grid[x, y] = lines[x][y];
    } 
}

while (canRemoveRolls)
{
    canRemoveRolls = false;
    for (int x = 0; x < sizeX; x++)
    {
        for (int y = 0; y < sizeY; y++)
        {
            if (grid[x,y] != '@') continue;
            var neighbourRollCount = 0;
            foreach (var (X, Y) in Neighbours(x, y))
            {
                if (X >= sizeX || Y >= sizeY || X < 0 || Y < 0)
                    continue;
                else if (grid[X,Y] == '@')
                    neighbourRollCount++;
            }
            if (neighbourRollCount < 4)
            {
                validRolls++;
                grid[x, y] = '.';
                canRemoveRolls = true;
            }
        }
    }
}

Console.WriteLine(validRolls);

static List<(int X, int Y)> Neighbours(int X, int Y) => [
        new(X + 1, Y),
        new(X - 1, Y),
        new(X, Y + 1),
        new(X, Y - 1),
        new(X + 1, Y + 1),
        new(X + 1, Y - 1),
        new(X - 1, Y + 1),
        new(X - 1, Y - 1)
    ];


