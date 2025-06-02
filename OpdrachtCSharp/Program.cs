int hoeveel = vraagAantalCodes(); // Nummer tussen 20-50 dat we ingeven

Random random = new Random();

int[,] goedeTabel = new int[9, 6]; // rijen: 9 producten (1–9), kolommen: 6 machines (A–F)
int[,] slechteTabel = new int[9, 6];  

string[] gegenereerdeCode = new string[hoeveel];

verwerkCodes();
PrintTabel("goeie afwerking", goedeTabel);
PrintTabel("slechte afwerking", slechteTabel);


int vraagAantalCodes() {
    Console.WriteLine("Hoeveel Codes genereren?(20-50): ");
    int hoeveel = 0;
    try
    {
        hoeveel= int.Parse(Console.ReadLine());
    }
    catch 
    {
        Console.WriteLine("Dat was geen nummer peisk");
    }
    

    while (hoeveel < 20 || hoeveel > 50)
    {
        Console.WriteLine("Geef een geldig aantal(20-50): ");
        try
        {
            hoeveel = int.Parse(Console.ReadLine());
        }
        catch 
        {
            Console.WriteLine("Dat was geen nummer peisk");
           
        }
        
    }
    return hoeveel;
}



void verwerkCodes() {
    for (int i = 0; i < hoeveel; i++)
    {
        char identificatie = (char)random.Next('A','G'); // A tot F
        int productNummer = random.Next(1, 10); // 1 tot 9
        int kwaliteit = random.Next(0, 2); // 0 of 1

        int kolom = identificatie - 'A'; // A=0 - F=5
        int rij = productNummer - 1; // '1'=0 -'9'= 8

        gegenereerdeCode[i] = $"{identificatie}{productNummer}{kwaliteit}"; //samenvoegen in string
        
        //Om de 10 codes een nieuwe lijn
        if (i > 0 && i % 10 == 0) Console.WriteLine();
        Console.Write(gegenereerdeCode[i] + " " );
        
        // Tel 1 bij op de juiste plek in de juiste tabel afhankelijk van welk product en welke machine gebruikt werd (goed of slecht)
        if (kwaliteit == 1 ) goedeTabel[rij, kolom]++;
        
        else slechteTabel[rij, kolom]++;
    }
    Console.WriteLine();
}



void PrintTabel(string titel, int[,] tabel) {
    Console.WriteLine($"\n{titel}");
    Console.Write("   ");

    //Headers: A B C ...
    for (int j = 0; j < 6; j++)
    {
        Console.Write($" {(char)('A' + j)}");
    }
    Console.WriteLine(" TOT");

    
    //Loop over elke Rij
    for (int i = 0; i < 9; i++)
    {
        Console.Write($"{i + 1}  "); // Print product number (1–9)
        int rijTOT = 0;
        
        
        //Loop over elke Kolom
        for (int j = 0; j < 6; j++)
        {
            Console.Write($" {tabel[i, j]}"); // Print de cell value
            rijTOT += tabel[i, j]; // Toevoegen aan de row total
        }

        Console.WriteLine($"  {rijTOT}"); //Print de row total at the end
    }

    // Het TOT (kolom totaal + eindtotaal)
    Console.Write("TOT");
    int totaal = 0;
    
    for (int j = 0; j < 6; j++)
    {
        int kolomTotaal = 0;
        
        // Alle values in kolom toevoegen
        for (int i = 0; i < 9; i++) kolomTotaal += tabel[i, j];
        totaal += kolomTotaal;
        Console.Write($" {kolomTotaal}");
    }

    Console.WriteLine($"  {totaal}");
}

