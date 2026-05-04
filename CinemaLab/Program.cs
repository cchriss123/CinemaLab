using System.Text;

namespace CinemaLab;

class Program
{
    static void Main(string[] args)
    {
        
        const string menuText = """
                                Välkommen till programmets huvudmeny! Välj ett av följande alternativ.
                                0. Avsluta program.
                                1. Ungdom eller pensionär.
                                2. Grupp.
                                3. Upprepa input 10 gånger.
                                4. Det tredje ordet.
                                """;

        var isRunning = true;
        
        while (isRunning)
        {

            Console.WriteLine(menuText);
            switch (Console.ReadLine() ?? "")
            {
                case "0": 
                    isRunning = false; 
                    break;
                case "1": 
                    Console.WriteLine(GetUserPriceOutput()); 
                    PressAnyKey(); 
                    break;
                case "2": 
                    Console.WriteLine(GetUserPriceGroupOutput()); 
                    PressAnyKey(); 
                    break;
                case "3": 
                    Console.WriteLine(GetInputTimesTenOutput()); 
                    PressAnyKey(); 
                    break;
                case "4": 
                    Console.WriteLine(GetThirdWordOutput()); 
                    PressAnyKey(); 
                    break;
                default: 
                    Console.WriteLine("Felaktigt alternativ, försök igen."); 
                    PressAnyKey(); 
                    break;
            }
        }
    }
    
    private static void PressAnyKey()
    {
        Console.WriteLine("Tryck på valfri tangent för att fortsätta!");
        Console.ReadLine();
    }
    
    private static string GetUserPriceOutput()
    {
        var userAge = GetUserAge();
        return userAge switch
        {
            < 20 => "Ungdomspris: 80kr ",
            > 64 => "Pensionärspris: 90kr",
            _ => "Standardpris: 120kr"
        };
    }

    private static int GetUserAge()
    {
        while (true)
        {
            Console.WriteLine("Ange ålder i siffror.");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var userAge) && userAge >= 0)
            {
                return userAge;
            }
            Console.WriteLine("Felaktig input.");
            PressAnyKey();
        }
    }
    
    private static string GetUserPriceGroupOutput()
    {
        int amountOfPeople;
        while (true)
        {
            Console.WriteLine("Ange antal personer i grupp");
            var amountOfPeopleInput = Console.ReadLine();
            if (int.TryParse(amountOfPeopleInput, out amountOfPeople) && amountOfPeople > 0)
            {
                break;
            }
            Console.WriteLine("Felaktig input. Ange ett heltal större än 0.");
            PressAnyKey();
        }
        
        var amountOfMoney = 0;
        Console.WriteLine($"Du har angett att ni är {amountOfPeople} personer, behöver nu ange ålder för var och en av dessa personer");
        
        for (var i = 0; i < amountOfPeople; i++)
        {
            Console.WriteLine($"Person nummer {i+1}.");
            var userAge = GetUserAge();
            amountOfMoney += userAge switch
            {
                < 20 => 80,
                > 64 => 90,
                _ => 120
            };
        }
        return $"Ni är {amountOfPeople} personer och det totala priset för gruppen är {amountOfMoney} kr.";
    }
    
    private static string GetInputTimesTenOutput()
    {
        Console.WriteLine("Skriv in din input");
        var input = Console.ReadLine() ?? "";
        var sb = new StringBuilder();

        for (var i = 0; i < 10; i++)
        {
            sb.Append($"{i+1}. {input}");
            if (i < 9) sb.Append(", ");
        }
        return sb.ToString();
    }
    
    private static string GetThirdWordOutput()
    {
        List<string> words;
        
        while (true)
        {
            Console.WriteLine("Skriv en mening på minst 3 ord");
            var input = Console.ReadLine() ?? "";
            
            var tempWords = input.Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .ToList();

            if (tempWords.Count < 3)
            {
                Console.Write("Din mening innehåller inte 3 ord. ");
                continue;
            }
            words = tempWords; 
            break; 
        }
        return $"Det tredje ordet i meningen är {words[2]}.";
    }
}