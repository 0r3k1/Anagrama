using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama {
    class Program {
        static void Main(string[] args) {
            string palabra1, palabra2;

            Console.Write("Escriba una palabra: ");
            palabra1 = Console.ReadLine();

            Console.Write("Escriba una palabra: ");
            palabra2 = Console.ReadLine();

            Console.Write($"Las palabras {palabra1} y {palabra2} ");
            if (isAnagram(palabra1, palabra2)) Console.WriteLine("son anagramoas");
            else Console.WriteLine("no son anagramas");


        }

        static Tuple<string, string> contarLetras(string palabra) {
            string aux = "";
            string repetida = "";
            foreach (char letra in palabra) {
                if (aux.Contains(letra)) continue;
                int lRepet = 0;
                foreach (char caracter in palabra) {
                    if (letra == caracter) lRepet += 1;
                }
                aux += letra;
                repetida += lRepet;
            }

            return Tuple.Create(aux, repetida);
        }

        static bool isAnagram(string plb1, string plb2) {
            if (plb1.CompareTo(plb2) == 0) return false;

            int largo = plb1.Length;

            Tuple<string, string> p1 = contarLetras(plb1.ToLower());
            Tuple<string, string> p2 = contarLetras(plb2.ToLower());
            
            foreach (char letraP1 in p1.Item1) {
                foreach(char letraP2 in p2.Item1) {
                    if(letraP1 == letraP2) {
                        if (p1.Item2[p1.Item1.IndexOf(letraP1)] != p2.Item2[p2.Item1.IndexOf(letraP2)]) return false;
                    }
                }
            }


            return true;
        }
    }
}
