
bool done = false;
bool subDone = false;
string choise = "";
string subChoise = "0";


Console.Title = "Huvudmeny";

do
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("HUVUDMENY");
    Console.WriteLine("");
    Console.WriteLine("Skriv in en siffra för att välja funktion");
    Console.WriteLine("1 - Boka biobiljetter");
    Console.WriteLine("2 - Upprepa tio gånger");
    Console.WriteLine("3 - Det tredje ordet");
    Console.WriteLine("0 - Avsluta");

    choise = Console.ReadLine();

    switch(choise)
    {
        case "1":

            
            

            do
            {
                Console.WriteLine("");
                Console.WriteLine("  Bokameny");
                Console.WriteLine("  1 - Boka biobiljett");
                Console.WriteLine("  2 - Boka biobiljetter för grupp");
                Console.WriteLine("  0 - Avbryt bokning");
                Console.Write("  ");
                subChoise = Console.ReadLine();

                switch (subChoise)
                {
                    case "1":
                        Order();
                        break;

                    case "2":
                        GroupOrder();
                        break;

                    case "0":
                        subDone = true;
                        break;

                    default:
                        PrintErrorMsg();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktig input!");
            Console.ResetColor();
            Console.Write("Enter för att gå tillbaka ");
            Console.ReadLine();                             // Pausa här för att anv ska hinna läsa
            break;
    }

} while(!done);

void Order()
{
    uint age = 0;
    uint price = 0;

    Console.WriteLine("");
    Console.WriteLine("  Beställning  (Skriv 0 för att avbryta)");
    Console.Write("  ");
    age = InputAge();
    if (age == 0) 
    {
        Console.WriteLine("  Avbryter bokningen...");
        return;
    }
    price = WritePrice(age);
}

void GroupOrder()
{
    uint nrOfVisitors = 0;
    uint age = 0;
    uint sum = 0;

    Console.WriteLine("");
    Console.WriteLine("  Gruppbeställning  (Skriv 0 för att avbryta)");

    nrOfVisitors = InputGroupSize();
    if (nrOfVisitors == 0)
    {
        Console.WriteLine("  Avbryter bokningen...");
        return;
    }

    for (int i = 1; i <= nrOfVisitors; i++)
    {
        Console.Write($"  Person {i}: ");
        age = InputAge();
        if (age == 0)
        {
            Console.WriteLine("  Avbryter bokningen...");
            return;
        }
        sum += WritePrice(age);
    }

    Console.WriteLine("");
    Console.WriteLine($"  Antal personer: {nrOfVisitors}");
    Console.WriteLine($"  Summa för grupp: {sum}kr");

}

uint InputGroupSize()
{
    uint fellowshipNr = 0;
    string sFellowshipNr = "";
    bool done = false;

    do
    {
        Console.Write("  Hur många ska gå? ");
        sFellowshipNr = Console.ReadLine();
        if(uint.TryParse(sFellowshipNr, out uint result))
        {
            fellowshipNr = result;
            done = true;
        }
        else 
        {
            Console.Write("  ");
            PrintErrorMsg();
        }

    } while(!done);

    return fellowshipNr;
}

uint InputAge()
{
    uint age = 0;
    string sAge = "";
    bool done = false;

    do
    {
        Console.Write("Ange ålder ");
        sAge = Console.ReadLine();
        if (uint.TryParse(sAge, out uint result))
        {
            age = result;
            done = true;
        }
        else 
        {
            Console.Write("  ");
            PrintErrorMsg();
            Console.Write("  ");
        }

    } while(!done);

    return age;
}

uint WritePrice(uint age)
{
    uint price = 0;

    if(age < 5 || age > 100)
    {
        price = 0;
        Console.WriteLine($"  Fri Entre: {price}kr");
    }
    else if(age < 20)
    {
        price = 80;
        Console.WriteLine($"  Ungdomspris: {price}kr"); 
    }
    else if(age > 64) 
    {
        price = 90;
        Console.WriteLine($"  Pensionärspris: {price}kr"); 
    }
    else 
    {
        price = 120;
        Console.WriteLine($"  Standardpris: {price}kr"); 
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
            Console.Write("Enter för att gå tillbaka");
            Console.ReadLine();
            done = true;
        }
        else { PrintErrorMsg(); }

    } while(!done);

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
            Console.Write("Enter för att gå tillbaka ");
            Console.ReadLine();
            done = true;
        }
        else { PrintErrorMsg(); }

    } while (!done);

}

string RemoveDubbleSpace(string sentence)
{
    do
    {
        sentence = sentence.Replace("  ", " ");     // Ersätt dubbelt mellanslag med enkelt

    } while (sentence.Contains("  "));              // tills det inte finns några kvar

    return sentence.Trim();                         // Ta även bort inledande och efterföljande mellanslag
}

void PrintErrorMsg()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Felaktig input! Försök igen.");
    Console.ResetColor();
}