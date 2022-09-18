int[] grid = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0 ,15 };

int[] getPosition(int[] array,int num)
{
    int pos = Array.IndexOf(array, num);
    int x = pos / 4;
    int y = pos % 4;
    int[] position = { x, y };
    return position;
}

void mouveNum(int[]array, int num)
{
    int idxNum = Array.IndexOf(array, num);
    int idxZer = Array.IndexOf(array, 0);

    array[idxZer] = num;
    array[idxNum] = 0;
}

bool correctMouve(int num)
{
    int[] posNum = getPosition(grid, num);
    int[] posZer = getPosition(grid, 0);

    if ( posNum[0] == posZer[0] && 
        (posNum[1] == --posZer[1] || posNum[1] == posZer[1] + 2))
    {
        mouveNum(grid, num);
        return true;
    }
    if ( posNum[1] == posZer[1]  &&
        (posNum[0] == --posZer[0] || posNum[0] == posZer[0] + 2))
    {
        mouveNum(grid, num);
        return true;
    }

    return false;
}

void printPosition(int[] array)
{
    foreach (var item in array)
    {
        Console.Write(item+ " ");
    }
};

void printGrid(int[] array)
{
    Console.Write("|");
    for (int i = 0; i < array.Length; i++)
    {
        printNumber(array[i]);
        Console.Write("|");
        if ((i+1)%4==0)
        {
            Console.WriteLine();
            if (!(array.Length == i + 1))
            {
            Console.Write("|");
            }
        }
    }
}

void printNumber(int num)
{
    if (num > 9)
    {
        Console.Write($" {num} ");
    }
    else
    {
        Console.Write($"  {num} ");
    };
}

bool winCondition(int[] array)
{
    for (int i = 0; i < array.Length-1; i++)
    {
        if(i+1 != array[i])
        {
            return true;
        }
    }
    return false;
}


bool winner = winCondition(grid);
while (winner)
{
    printGrid(grid);
    Console.WriteLine();
    Console.Write("Digita il nuomer che vuoi muovere ");
    if (correctMouve(Convert.ToInt32(Console.ReadLine())))
    {
        Console.WriteLine("Mossa corretta");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Mossa Scorretta");
        Console.WriteLine();
    }

    winner = winCondition(grid);
    if (!winner)
    {
        printGrid(grid);
        Console.WriteLine();
        Console.Write("HAI VINTO");
    }
}
