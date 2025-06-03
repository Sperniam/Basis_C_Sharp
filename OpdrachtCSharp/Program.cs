int hoeveel = vraagAantalCodes(); // Nummer tussen 20-50 dat we ingeven

Random random = new Random();

int[,] goedeTabel = new int[10, 7]; // rijen: 9 producten (1–9), kolommen: 6 machines (A–F)
int[,] slechteTabel = new int[10, 7];

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


// Codes genereren /verwerken/ totalen updaten
void verwerkCodes() {
    for (int i = 0; i < hoeveel; i++)
    {
        char identificatie = (char)random.Next('A','G'); // A tot F
        int productNummer = random.Next(1, 10); // 1 tot 9
        int kwaliteit = random.Next(0, 2); // 0 of 1

        int kolom = identificatie - 'A'; // A=0 - F=5
        int rij = productNummer - 1; // '1'=0 -'9'= 8

        gegenereerdeCode[i] = $"{identificatie}{productNummer}{kwaliteit}"; 
        
        //Om de 10 codes een nieuwe lijn
        if (i % 10 == 0) Console.WriteLine();
        Console.Write(gegenereerdeCode[i] + " " );
        
        // Update juiste tabel en totalen
        if (kwaliteit == 1)
        {
            goedeTabel[rij, kolom]++;
            goedeTabel[rij, 6]++;     // rijtotaal
            goedeTabel[9, kolom]++;   // kolomtotaal
            goedeTabel[9, 6]++;       // eindtotaal
        }

        else
        {
            slechteTabel[rij, kolom]++;
            slechteTabel[rij, 6]++;    // rijtotaal
            slechteTabel[9, kolom]++;  // kolomtotaal
            slechteTabel[9, 6]++;      // eindtotaal
        }
    }
    Console.WriteLine();
}



// Tabel tonen met rijen, kolommen en totalen
void PrintTabel(string titel, int[,] tabel) {
    Console.WriteLine($"\n{titel}");
    Console.Write("   ");

    //Headers: A B C ...
    for (int j = 0; j < 6; j++)
    {
        Console.Write($" {(char)('A' + j)}");
    }
    Console.WriteLine(" TOT");

    
    //Loop over elke Rij met productnummer + rijTotaal
    for (int i = 0; i < 9; i++)
    {
        Console.Write($"{i + 1}  "); // Print product number (1–9)
        
        //Loop over elke Kolom
        for (int j = 0; j < 6; j++)
        {
            Console.Write($" {tabel[i, j]}"); // Print de cell value
        }

        Console.WriteLine($"  {tabel[i,6]}"); //Rij totaal ( kolom 6)
    }

    //TOT rij (rij 9)
    Console.Write("TOT");
    
    for (int j = 0; j < 6; j++)
    {
       
        Console.Write($" {tabel[9,j]}"); 
    }

    Console.WriteLine($"  {tabel[9, 6]}");
}

