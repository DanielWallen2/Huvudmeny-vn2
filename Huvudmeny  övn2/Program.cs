
bool done = false;
string choise = "";
bool subDone = false;
string subChoise = "0";


Console.Title = "Huvudmeny";

do
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("HUVUDMENY");

    Console.WriteLine("");
    Console.WriteLine("1 - Boka biobiljetter");
    Console.WriteLine("2 - Upprepa tio gånger");
    Console.WriteLine("3 - Det tredje ordet");
    Console.WriteLine("0 - Avsluta");
    Console.WriteLine("");
    Console.WriteLine("Skriv in en siffra för att välja funktion");

    choise = Console.ReadLine();

    switch(choise)
    {
        case "1":

            Console.WriteLine("");
            Console.WriteLine("  Bokameny");
            Console.WriteLine("  1 - Boka biobiljett");
            Console.WriteLine("  2 - Boka biobiljetter för grupp");
            Console.Write("  ");

            do
            {
                subChoise = Console.ReadLine();

                switch (subChoise)
                {
                    case "1":
                        Order();
                        subDone = true;
                        break;

                    case "2":
                        GroupOrder();
                        subDone = true;
                        break;

                    case "0":
                        Console.WriteLine("Avbryter beställning...");
                        subDone = true;
                        break;

                    default:
                        Console.WriteLine("Felaktig input!");
                        break;
                }

            } while (!subDone);
            
            break;

        case "2":
            Repeat10();
            break;

        case "3":
            Word3();
            break;

        case "0":
            Console.WriteLine("Avslutar program...");
            done = true;
            break;

        default:
            Console.WriteLine("Felaktig input!");
            Console.WriteLine("Enter för att gå tillbaka");
            Console.ReadLine();
            break;
    }

} while(!done);

void Order()
{
    uint age = 0;
    uint price = 0;

    Console.WriteLine("");
    Console.WriteLine("Beställning  (Skriv 0 för att avbryta)");

    age = GetAge();
    if (age == 0) { return; };
    price = GetPrice(age);

    Console.WriteLine("");
    Console.WriteLine("Enter för att gå tillbaka");
    Console.ReadLine();
}

void GroupOrder()
{
    uint nrOfVisitors = 0;
    uint age = 0;
    uint sum = 0;

    Console.WriteLine("");
    Console.WriteLine("Gruppbeställning  (Skriv 0 för att avbryta)");

    nrOfVisitors = GetVisitorNr();
    if (nrOfVisitors == 0) { return; }
    for (int i = 1; i <= nrOfVisitors; i++)
    {
        Console.Write($"Person {i}: ");
        age = GetAge();
        if (age == 0) { return; };
        sum += GetPrice(age);
    }
    Console.WriteLine("");
    Console.WriteLine($"Antal personer: {nrOfVisitors}");
    Console.WriteLine($"Summa för grupp: {sum}kr");

    Console.WriteLine("");
    Console.WriteLine("Enter för att gå tillbaka");
    Console.ReadLine();
}

uint GetVisitorNr()
{
    uint fellowshipNr = 0;
    string sFellowshipNr = "";
    bool done = false;

    Console.Write("Hur många ska gå? ");

    do
    {
        sFellowshipNr = Console.ReadLine();
        if(uint.TryParse(sFellowshipNr, out uint result))
        {
            fellowshipNr = result;
            done = true;
        }
        else { Console.WriteLine("Felaktig input!"); }

    } while(!done);

    return fellowshipNr;
}

uint GetAge()
{
    uint age = 0;
    string sAge = "";
    bool done = false;

    Console.Write("Ange ålder ");

    do
    {
        sAge = Console.ReadLine();
        if (uint.TryParse(sAge, out uint result))
        {
            age = result;
            done = true;
        }
        else { Console.WriteLine("Felaktig input!"); }
 
    } while(!done);

    return age;
}

uint GetPrice(uint age)
{
    uint price = 0;

    if(age < 5 || age > 100)
    {
        price = 0;
        Console.WriteLine($"Fri Entre: {price}kr");
    }
    else if(age < 20)
    {
        price = 80;
        Console.WriteLine($"Ungdomspris: {price}kr"); 
    }
    else if(age > 64) 
    {
        price = 90;
        Console.WriteLine($"Pensionärspris: {price}kr"); 
    }
    else 
    {
        price = 120;
        Console.WriteLine($"Standardpris: {price}kr"); 
    }

    return price;
}

void Repeat10()
{
    string text = "";
    uint nrOfTimes = 10;
    bool done = false;

    Console.WriteLine("");
    Console.WriteLine("Skriv en godtycklig text");

    do
    {
        text = Console.ReadLine();
        if(text != "")
        {
            WriteSeveralTimes(text, nrOfTimes);

            Console.WriteLine("");
            Console.WriteLine("Enter för att gå tillbaka");
            Console.ReadLine();
            done = true;
        }
        else { Console.WriteLine("Felaktig input!"); }

    }while(!done);

}

void WriteSeveralTimes(string text, uint nrOfTimes)
{
    Console.WriteLine("");
    for (int i = 1; i <= nrOfTimes; i++)
    {
        Console.Write($"{i}. {text}");
        if (i < nrOfTimes) { Console.Write(", "); }
    }
    Console.WriteLine("");
}

void Word3()
{
    string sentence = "";
    string[] wordList;
    int nrOfWords = 0;
    bool done = false;

    Console.WriteLine("");
    Console.WriteLine("Skriv en mening med minst tre ord  (0 för att avbryta)");

    do
    {
        sentence = Console.ReadLine();
        sentence = RemoveDubbleSpace(sentence);
        if(sentence == "0") { return; }
        wordList = sentence.Split(' ');
        nrOfWords = wordList.Count();
        if (nrOfWords >= 3)
        {
            Console.WriteLine("");
            Console.WriteLine($"Det tredje ordet är: {wordList[2]}");
            Console.WriteLine("");
            Console.WriteLine("Enter för att gå tillbaka");
            Console.ReadLine();
            done = true;
        }
        else { Console.WriteLine("Felaktig input!"); }

    } while (!done);

}

string RemoveDubbleSpace(string sentence)
{
    do
    {
        sentence = sentence.Replace("  ", " ");

    } while (sentence.Contains("  "));

    return sentence.Trim();
}