using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Case2;
using Øvelse;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
//using static Case2.H;

enum Valg
{
    Lærer,
    Elev,
    Fag
}
class Program
{
    static void Main(string[] args)
    {
        bool løkke;
        løkke = false;

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        H1 h1 = new H1();
        FagModel[] fag = h1.Fag;
        PersonModel[][] alleelever = h1.AlleElever;

        while (løkke == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===================================================");   //her lavede han en lille velkomstside med de vigtigste informationer, såsom et bord med nøgleknapper
            Console.WriteLine("            Velkommen til H1's system              ");
            Console.WriteLine("===================================================");
            Console.WriteLine("\n");
            Console.WriteLine("Vælg en af ​​mulighederne nedenfor:");
            Console.WriteLine("Hvis du ikke indtaster nogen muligheder, starter du forfra.");
            Console.WriteLine("tryk på L, hvis du vil vælge Lærer.");
            Console.WriteLine("tryk på E, hvis du vil vælge Elev.");
            Console.WriteLine("tryk på F, hvis du vil vælge Fag.");
            Console.WriteLine("tryk på Q, hvis du vil vælge Afslut.");
            Console.WriteLine("!!!!!husk om store bogstaver!!!!!\n");
            //her er de muligheder, som den besøgende kan vælge for at fortsætte eller deaktivere applikationen


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|          " + Valg.Lærer + " (L)                                |");
            Console.WriteLine("|          " + Valg.Elev + "  (E)                                |");
            Console.WriteLine("|          " + Valg.Fag + "   (F)                                |");
            Console.WriteLine("|          Exit  (A)                                |");
            Console.WriteLine("+-------------------------------------------------+\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Indtast: ");
            string Funktion = Console.ReadLine();

            if (Funktion == "L")
            {
                Console.Clear();
                Console.WriteLine("===================================================");
                Console.WriteLine("            Søg efter en lærer i systemet          ");
                Console.WriteLine("===================================================\n");
                Console.WriteLine("Hvis læreren ikke bliver fundet, vil du blive kastet tilbage til menuen.");
                Console.WriteLine("\"Husk at sætte dit for- og efternavn med store bogstaver efter hvert mellemrum.\n");
                Console.Write("Indtast navnet på den lærer, du vil søge hos: ");
                
                //her søger efter en lærer i systemet

                string lærenavn = Console.ReadLine(); //Denne kode får lærerens navn fra brugeren og finder faget (faget), der undervises af den pågældende lærer. Det viser derefter fagets navn og listen over elever, der er tilmeldt det pågældende fag.
                foreach (FagModel Fag in fag)
                {
                    if (Fag.Lærer.Fornavn + " " + Fag.Lærer.Efternavn == lærenavn)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n=== Fag: {Fag.FagNavn.ToUpper()} ===\n");
                        Console.ResetColor();

                        PersonModel[] elever = null;
                        if (Fag.FagNavn == "Studieteknik")
                        {
                            elever = h1.StudieTeknikElever;
                        }
                        if (Fag.FagNavn == "Grundlæggende programmering")
                        {
                            elever = h1.GrundlæggendeProgrammeringElever;
                        }
                        if (Fag.FagNavn == "OOP")
                        {
                            elever = h1.OOPElever;
                        }
                        if (Fag.FagNavn == "Computerteknologi")
                        {
                            elever = h1.ComputerteknologiElever;
                        }
                        if (Fag.FagNavn == "Clientsideprogrammering")
                        {
                            elever = h1.ClientsideprogrammeringElever;
                        }
                        if (Fag.FagNavn == "Netværk")
                        {
                            elever = h1.NetværkElever;
                        }
                        if (elever != null)
                        {
                            Console.WriteLine("\nElever:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            foreach (PersonModel elev in elever)
                            {
                                Console.WriteLine($"- {elev.Fornavn} {elev.Efternavn}");
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Der er ingen elever tilmeldt dette fag.");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine("\nTryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
            if (Funktion == "E")   //Funktionen "E" søger efter information om elever
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hvis eleven ikke bliver fundet, bliver du kastet tilbage til menuen.");
                Console.WriteLine("\nHvert mellemrum skal efterfølges af et stort bogstav.");
                Console.Write("\nIndtast navnet på den studerende, du vil søge: ");
                Console.ResetColor();
                string elevnavn = Console.ReadLine();

                int c = 0;

                if (alleelever.Length > 0)
                {
                    foreach (PersonModel[] item in alleelever) //Kontrollerer, om længden af ​​"alleelever"-arrayet er større end 0, hvis det er tilfældet, udfører følgende for hver "item"-array i "alleelever"-arrayet.
                    {
                        var Elev = item.FirstOrDefault(x => x.Fornavn + " " + x.Efternavn == elevnavn); 
                        if (Elev != null) //Hvis værdien af ​​"Fag" ikke er nul, viser den navnet på fagen, navnet på læreren og øger derefter værdien af ​​variablen "c".
                        {
                            FagModel Fag = null; //Til sidst viser koden en besked om at vente på, at en tast trykkes, før du fortsætter.
                            if (c == 0)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "Studieteknik");
                            }
                            if (c == 1)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "Grundlæggende Programmering");
                            }
                            if (c == 2)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "Database programmering");
                            }
                            if (c == 3)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "OOP");
                            }
                            if (c == 4)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "Computerteknologi");
                            }
                            if (c == 5)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "Clientsideprogrammering");
                            }
                            if (c == 6)
                            {
                                Fag = fag.FirstOrDefault(y => y.FagNavn == "Netværk");
                            }
                            if (Fag != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\nFag: {Fag.FagNavn}");
                                Console.ResetColor();
                                Console.WriteLine($"Lærer: {Fag.Lærer.Fornavn} {Fag.Lærer.Efternavn}");
                            }
                        }
                        c++;
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nTryk på en tast for at fortsætte");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            if (Funktion == "F")     //Funktion F viser skolefag, som er tildelt navne og efternavne
                                     //Koden består af to if-sætninger, som hver kontrollerer værdien af ​​Funktion-variablen. Hvis Funktionsvariablen er sat til "F", beder programmet brugeren om navnet på emnet og viser på skærmen den lærer, der er tildelt det pågældende emne, og listen over elever, der er tilmeldt det pågældende emne. Ellers, når Funktion er "A", afsluttes programmet.
            {
                Console.Clear();
                Console.WriteLine("Hvis eleven ikke bliver fundet, bliver du kastet tilbage til menuen");
                Console.WriteLine("\nHvert mellemrum skal efterfølges af et stort bogstav");
                Console.Write("Indtast det emne, du vil søge efter: ");
                string fagnavn = Console.ReadLine();
                foreach (FagModel Fag in fag)
                {
                    if (Fag.FagNavn == fagnavn)
                    {
                        Console.WriteLine($"Teacher: {Fag.Lærer.Fornavn} {Fag.Lærer.Efternavn}");
                        break;
                    }
                }
                PersonModel[] elever = null;
                if (fagnavn == "Studieteknik")
                {
                    elever = h1.StudieTeknikElever;
                }
                if (fagnavn == "Grundlæggende Programmering")
                {
                    elever = h1.GrundlæggendeProgrammeringElever;
                }
                if (fagnavn == "OOP")
                {
                    elever = h1.OOPElever;
                }
                if (fagnavn == "Computerteknologi")
                {
                    elever = h1.ComputerteknologiElever;
                }
                if (fagnavn == "Clientsideprogrammering")
                {
                    elever = h1.ClientsideprogrammeringElever;
                }
                if (fagnavn == "Netværk")
                {
                    elever = h1.NetværkElever;
                }
                if (elever != null)
                {
                    foreach (PersonModel elev in elever)
                    {
                        Console.WriteLine($"Student: {elev.Fornavn} {elev.Efternavn}");
                    }
                }
                if (elever == null)
                {
                    Console.WriteLine("Dette er ikke et emne, vi underviser i, prøv venligst igen");
                }

                Console.Write("\nTryk på en hvilken som helst smag for at fortsætte");
                Console.ReadKey();
            }
            if (Funktion == "A") //Funktion A er beregnet til at lukke konsoller
            {
                Environment.Exit(0);
                //For at kunne bruge programmet skal du vælge en af ​​funktionerne, indtaste de relevante data og læse programmet på skærmen. 
                //Bemærk venligst, at programmet er designet på en sådan måde, at det kun er muligt at afslutte det ved at vælge funktion "A".
            }
        }
    }
}