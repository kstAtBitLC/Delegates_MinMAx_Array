using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_MinMAx_Array {

    // Vereinbarung eines Delegate-Typs mit dem Namen: VergleichsDalegate
    delegate bool VergleichsDelegate ( int x, int y );

    class Program {
        
        static void Main ( string [] args ) {
            Random zfzg = new Random (); // Zufallszahlgenerator
            //int [] zfzArray = new int [ 5 ]; // Array für die Zufallszahlen

            // Testdaten
            // Um festzustellen, ob die Methoden korrekt funktionieren
            // ist es unsinnig mit Zufallswerten zu arbeiten
            // daher zunächst:
            int[] zfzArray = { 10,77,3,4,10};

            // Fülle Array mit Zufallszahlen
            //for ( int i = 0 ; i < zfzArray.Length ; i++ ) {
            //    zfzArray [ i ] = zfzg.Next ( 0, 10 );
            //}
            // Zeige Array-Inhalt - der Inhalt des Arrays ÄNDERT sich !!!
            //foreach ( var item in zfzArray ) {
            //    Console.WriteLine (item);
            //}

            // Objekt vom selbst definierten Typ ArrayInformation erzeugen!
            // Ohne dieses Objekt müßten wir mit statischen Klassenmethoden arbeiten
            // - was wir, laut Aufgabenstellung, zu berücksichtigen haben ...
            ArrayInformation ai = new ArrayInformation ();


            // Vorüberlegung:
            // Schreibe eine Methode, welche den größten Wert im Array bestimmt
            // Diese Methode läßt sich überreden an Stelle des größten Wertes
            // den entsprechenden Index zurückzugeben!
            Console.WriteLine ( ai.BestimmeGrößtenWertImArray ( zfzArray ) );
            Console.WriteLine ("================== ohne Delegates für den Test =====================");

            // ********************** Arbeiten mit Delegates ****************************

            // Delegate-Variable ...
            VergleichsDelegate dlg;

            // dlg zeigt auf IstKleiner-Methode des ai-Objekts
            dlg = ai.IstKleiner;
            
            // Ergebnis für den Arrayindex des größten Elements
            //int groesstes = ai.Limit(dlg, zfzArray);
            //Console.WriteLine ("Arrayindex mit größtem Element auf: {0}", groesstes );


            // ************** Methode auf die die Delegate Variable zeigt - ändern ***************

            // dlg zeigt nun auf IstGrösser-Methode des ai-Objekts
            dlg = ai.IstGrösser;

            // Ergebnis für den Arrayindex des kleinsten Elements
            //int kleinstes = ai.Limit ( dlg, zfzArray );
            
            //Console.WriteLine ("Arrayindex mit kleinstem Element: {0}", kleinstes );

            Console.ReadLine ();
        }
    }

    // unsere Klasse, welche die vorgegebenen Methoden aufnimmt
    class ArrayInformation {

        // die geforderte Methode ...
        public int Limit ( VergleichsDelegate vgldlg, int [] zfz ) {
            int ergebnis=0, merker=0;

            merker = zfz [0];

            for ( int i = 0 ; i < zfz.Length ; i++ ) {
                if ( vgldlg( zfz [ i ], merker ) ) {                    
                    merker = zfz[i];
                }
            }
            ergebnis = Array.IndexOf(zfz,merker);
            return ergebnis;
        }

        public bool IstKleiner ( int a, int b ) {
            return a < b;
        }
        public bool IstGrösser ( int a, int b ) {
            return a > b;
        }

        /*
         * BestimmeGrößtenWertImArray liefert - eigentlich den größten Wert im Array
         * zurück - läßt sich aber durch Auskommentieren der return-Anweisung
         * und Einkommentieren der anderen return-Anweisung umstellen auf die
         * Rückgabe der Position der größten Zahl des Arrays
         * 
         * Die kleinste Zahl läßt sich mit einer ähnlichen Methode finden.
         * Lediglich eine Umkehrung des Größerzeichens in ein Kleinerzeichen
         * in der Anweisung if ( array[i] > merker ) in
         * if ( array[i] < merker ) ist erforderlich
         * Die Ermittlung der Position ist davon unabhängig!
         */
        public int BestimmeGrößtenWertImArray (int [] array) {
            // setze merker auf das 1. Element des Arrays
            int merker = array [ 0 ];

            // der eigentliche Algorithmus
            for ( int i = 0 ; i < array.Length ; i++ ) {
                if ( array[i] > merker ) {
                    merker = array [i];
                }
            }

            // die Klassenmethode IndexOf der Klasse Array
            // liefert die Position des gefundenen, größten Elements
            int positionImArray = Array.IndexOf ( array, merker );

            return merker;  // liefert den größten Wert im Array
            //return positionImArray; // liefert die Position des größten Werts im Array
        }
    }
}
