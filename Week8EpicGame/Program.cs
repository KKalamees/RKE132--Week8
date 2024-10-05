
//string[] heroes = { "Max Verstappen", "Diddy", "HDTanel", "Teet Margna" };
//string[] villains = { "Epstein", "LeBron", "DrVassiljev", "MrBeast" };

string folderPath = @"D:\proge\";
string heroFile = "heroes.txt";
string villianFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villianFile));

string[] weapons = { "R20", "Brick", "V6mp", "Kang" };


string hero = GetRandom(heroes);
string heroweapon = GetRandom(weapons);
int heroHP = GetHP(hero);
Console.WriteLine("Today "+ hero+ $"({heroHP}HP) with " + heroweapon+ " saves the day!");

string villain = GetRandom(villains);
string villianweapon = GetRandom(weapons);
int villainHP = GetHP(villain);
Console.WriteLine("Today "+ villain+ $"({villainHP}HP)  with " + villianweapon+ " tries to take over the world");


while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP); 
}


if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{ 
    Console.WriteLine("Evil wins");
}
else
{ 
    Console.WriteLine("Draw");
}






static string GetRandom(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;

}

static int GetHP(string characterName)
{ 
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    { 
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd .Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine(characterName + " missed the target!");   
    }
    else if (strike == characterHP -1) 
    {
        Console.WriteLine(characterName + " made a critical hit");
    }
    else
    {
        Console.WriteLine(characterName + " hit " + strike + "!");
    }
    return strike;
}