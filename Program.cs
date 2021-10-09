using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_plagiarism
{
    class Program
    {
        static Random random = new Random();
        static Dictionary<char, char> RuEn = new Dictionary<char, char>
        {
            {'А', 'A'},
            {'В', 'B'},
            {'С', 'C'},
            {'Е', 'E'},
            {'Н', 'H'},
            {'К', 'K'},
            {'О', 'O'},
            {'М', 'M'},
            {'Р', 'P'},
            {'Т', 'T'},
            {'Х', 'X'},
            {'а', 'a'},
            {'с', 'c'},
            {'е', 'e'},
            {'о', 'o'},
            {'р', 'p'},
            {'х', 'x'}
        };
        static string randomWord(byte numCol)
        {
            numCol--;
            string[][] tablString = new string[3][];
            tablString[0] = new string[]
              {
                 "Это текст",
                 "Это материал",
                 "Это статья",
                 "Это публикация",
                 "Это данные",
                 "Это информация",
                 "Материал",
                 "Текст",
                 "Статья",
                 "Публикация",
                 "Данные",
                 "Информация"
              };
            tablString[1] = new string[]
              {
                 "сайта",
                 "книги",
                 "библиотеки",
                 "каталога",
                 "системы"
              };
            tablString[2] = new string[]
              {
                 "Univer",
                 "univer.ququ",
                 "Универ"
              };
            if (numCol > 2)
            {
                throw new Exception("Такой номера колонки не существует");
            }
            return tablString[numCol][random.Next(tablString[numCol].Length)];
           
        }
        static string randomReplaceRuEn(string str)
        {
            List<int> indexRuEn = new List<int> { };
            char[] strCharArr = str.ToCharArray();
            for (int i = 0; i < strCharArr.Length; i++)
            {
                if (RuEn.ContainsKey(strCharArr[i]))
                {
                    indexRuEn.Add(i);
                }
            }
            if (indexRuEn.Count != 0)
            {
                int randIndex = indexRuEn[random.Next(indexRuEn.Count)];
                strCharArr[randIndex] = RuEn[strCharArr[randIndex]];
                str = new string(strCharArr);
                return str;
            }
            else
            {
                return str;
            }
        }
        static string randomZeroSpaceInsert(string str)
        {
            string[] strArray = str.Split();
            int spaceRandom = random.Next(strArray.Length - 1);
            str = "";
            for (int i = 0; i < strArray.Length - 1; i++)
            {
                if (i != spaceRandom)
                {
                    str += strArray[i] + " ";
                }
                else
                {
                    str += strArray[i] + "  ";
                }
            }
            return str + strArray[strArray.Length - 1];
        }
        static void Main(string[] args)
        {
            string phrase = randomZeroSpaceInsert(randomReplaceRuEn(randomWord(1) + " " +
                randomWord(2))) + " " + randomZeroSpaceInsert(randomWord(3)) + ". ";
            Console.WriteLine("Generate phrase:" + phrase);

            Console.ReadKey();
        }
    }
}
