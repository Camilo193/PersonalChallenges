using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalChallenges
{
    public class Challenges
    {

        public string ReverseCase(string str)
        {
            char[] charArray = str.ToCharArray();
            string result = "";

            foreach (char ch in charArray)
            {
                if (ch.ToString().ToLower() == ch.ToString())
                {
                    result = result + ch.ToString().ToUpper();
                }
                else
                {
                    result = result + ch.ToString().ToLower();
                }
            }

            return result;
        }

        public bool CannotCapture(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        if ((i + 2) >= 0 && (i + 2) < 8 && (j + 1) >= 0 && (j + 1) < 8)
                        {
                            int position1 = board[i + 2, j + 1];

                            if (position1 == 1)
                                return false;
                        }

                        if ((i + 2) >= 0 && (i + 2) < 8 && (j - 1) >= 0 && (j - 1) < 8)
                        {
                            int position2 = board[i + 2, j - 1];

                            if (position2 == 1)
                                return false;
                        }

                        if ((i + 1) >= 0 && (i + 1) < 8 && (j + 2) >= 0 && (j + 2) < 8)
                        {
                            int position3 = board[i + 1, j + 2];

                            if (position3 == 1)
                                return false;
                        }

                        if ((i - 1) >= 0 && (i - 1) < 8 && (j + 2) >= 0 && (j + 2) < 8)
                        {
                            int position4 = board[i - 1, j + 2];

                            if (position4 == 1)
                                return false;
                        }

                        if ((i - 2) >= 0 && (i - 2) < 8 && (j + 1) >= 0 && (j + 1) < 8)
                        {
                            int position5 = board[i - 2, j + 1];

                            if (position5 == 1)
                                return false;
                        }

                        if ((i - 2) >= 0 && (i - 2) < 8 && (j - 1) >= 0 && (j - 1) < 8)
                        {
                            int position6 = board[i - 2, j - 1];

                            if (position6 == 1)
                                return false;
                        }

                        if ((i + 1) >= 0 && (i + 1) < 8 && (j - 2) >= 0 && (j - 2) < 8)
                        {
                            int position7 = board[i + 1, j - 2];

                            if (position7 == 1)
                                return false;
                        }

                        if ((i - 1) >= 0 && (i - 1) < 8 && (j - 2) >= 0 && (j - 2) < 8)
                        {
                            int position8 = board[i - 1, j - 2];

                            if (position8 == 1)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        public string PilishString(string txt)
        {
            double PI = Math.PI;
            char[] PIArray = PI.ToString().Replace(".", "").ToArray();

            StringBuilder result = new StringBuilder("");
            List<int> PiInList = new List<int>();
            List<string> listOfWords = new List<string>();

            foreach (var item in PIArray)
            {
                PiInList.Add(int.Parse(item.ToString()));
            }

            if (txt == "")
                return txt;

            foreach (var piNumber in PiInList)
            {
                if (txt.Length > piNumber)
                {
                    listOfWords.Add(txt.Remove(piNumber));
                    txt = txt.Remove(0, piNumber);
                }
                else
                {
                    string repeat = txt.Remove(0, txt.Length - 1);
                    int difference = piNumber - txt.Length;

                    for (int i = 0; i < difference; i++)
                    {
                        txt = txt.Insert(txt.Length, repeat);
                    }
                    listOfWords.Add(txt);
                    break;
                }
            }
            result.AppendJoin(" ", listOfWords);
            return result.ToString();
        }

        public string LoneliestNumber(int lo, int hi)
        {
            int distance = 0;
            int loneliest = 0;
            int closest = 0;

            for (int i = lo; i < hi; i++)
            {
                int differenceWithPreviousPrime = i - PreviousPrime(i, 0);
                int differenceWithNextPrime = NextPrime(i) - i;

                if (i < 2)
                {
                    differenceWithPreviousPrime = differenceWithNextPrime;
                }

                if (differenceWithNextPrime <= differenceWithPreviousPrime && differenceWithNextPrime > distance)
                {
                    distance = differenceWithNextPrime;
                    loneliest = i;
                    closest = NextPrime(i);
                }
                else if (differenceWithPreviousPrime < differenceWithNextPrime && differenceWithPreviousPrime > distance)
                {
                    distance = differenceWithPreviousPrime;
                    loneliest = i;
                    closest = PreviousPrime(i, 0);
                }
            }
            return String.Format("number:{0}, distance:{1}, closest:{2}", loneliest, distance, closest);
        }

        public bool isPrime(int number)
        {
            if (number == 1)
                return false;
            if (number == 2)
                return true;
            for (int i = 2; i < number - 1; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public Dictionary<int, bool> PrimeInRange(int min, int max)
        {
            Dictionary<int, bool> primes = new();
            if (min > 1)
            {
                primes.Add(PreviousPrime(min, 0), true);
            }


            for (int i = min; i <= max; i++)
            {
                primes.Add(i, isPrime(i));
            }

            primes.Add(NextPrime(max), true);

            return primes;
        }

        public int NextPrime(int number)
        {
            if (isPrime(number))
                number++;
            while (!(isPrime(number)))
            {
                number++;
            }
            return number;
        }

        public int PreviousPrime(int number, int i)
        {
            if (isPrime(number) && i != 0)
            {
                return number;
            }
            return PreviousPrime(number - 1, i + 1);
        }

        public IEnumerable<long> LookAndSay(long start, int n)
        {
            List<long> lookAndSayList = new List<long>();
            lookAndSayList.Add(start);
            for (int i = 0; i < n - 1; i++)
            {
                start = NextLookAndSay(start);
                lookAndSayList.Add(start);
            }
            return lookAndSayList;
        }

        public IEnumerable<long> LookAndSay2(long start, int n)
        {
            List<long> lookAndSayList = new List<long>();
            StringBuilder result = new StringBuilder("");
            lookAndSayList.Add(start);

            for (int i = 0; i < n - 1; i++)
            {
                foreach (Match match in Regex.Matches(lookAndSayList[i].ToString(), @"(\d)(\1*)"))
                {
                    result.Append(match.Value.Length).Append(match.Value.Substring(0, 1));
                }
                lookAndSayList.Add(long.Parse(result.ToString()));
                result.Clear();
            }
            return lookAndSayList;
        }

        public long NextLookAndSay(long LookAndSay)
        {
            StringBuilder result = new("");
            int repeatCounter = 0;
            var LookAndSayArray = LookAndSay.ToString().ToArray();

            for (int i = 0; i <= LookAndSayArray.Length; i++)
            {
                if (i == 0)
                {
                    repeatCounter++;
                }
                else if (i == LookAndSayArray.Length || LookAndSayArray[i - 1] != LookAndSayArray[i])
                {
                    result.Append(repeatCounter);
                    result.Append(LookAndSayArray[i - 1].ToString());

                    repeatCounter = 1;
                }
                else if (LookAndSayArray[i - 1] == LookAndSayArray[i] && i > 0)
                {
                    repeatCounter++;
                }
            }
            return long.Parse(result.ToString());
        }

        public long NextLookAndSay2(long LookAndSay)
        {
            StringBuilder result = new("");
            int repeatCounter = 0;
            var LookAndSayArray = LookAndSay.ToString().ToArray();

            for (int i = 0; i <= LookAndSayArray.Length; i++)
            {
                if (i == 0)
                {
                    repeatCounter++;
                }
                else if (i == LookAndSayArray.Length || LookAndSayArray[i - 1] != LookAndSayArray[i])
                {
                    result.Append(repeatCounter);
                    result.Append(LookAndSayArray[i - 1].ToString());

                    repeatCounter = 1;
                }
                else if (LookAndSayArray[i - 1] == LookAndSayArray[i] && i > 0)
                {
                    repeatCounter++;
                }
            }
            return long.Parse(result.ToString());
        }

        public bool isLastCharacterN(string word)
        {
            return Regex.Match(word, @"edabit").Success;
        }

        public string Uncensor(string txt, string vowels)
        {
            int i = 0;
            return Regex.Replace(txt, @"\*", x => vowels[i++].ToString());
        }

        public string ReverseAndNot(int i)
        {
            return String.Concat(i.ToString().Reverse()) + i.ToString();
        }

        public string ReverseAndNotWithoutMethods(int i)
        {

            string iToString = "" + i;
            StringBuilder resultBuilder = new StringBuilder();
            string result = "";

            for (int j = iToString.Length - 1; j >= 0; j--)
            {
                resultBuilder.Append(iToString[j]);
                result += iToString[j];
            }

            for (int k = 0; k < iToString.Length; k++)
            {
                resultBuilder.Append(iToString[k]);
                result += iToString[k];
            }

            return result;

        }

        public int[] TrackRobot(string[] instructions)
        {
            int[] result = new int[2] { 0, 0 };

            foreach (string instruction in instructions)
            {
                string position = Regex.Match(instruction, @"^(right|up|left|down)").Value;
                int value = Int32.Parse(Regex.Match(instruction, @"\d+").Value);

                if (Regex.IsMatch(instruction, @"(^(right|up|left|down)\s\d+)"))
                {
                    switch (position)
                    {
                        case "right":
                            result[0] += value;
                            break;
                        case "left":
                            result[0] -= value;
                            break;
                        case "up":
                            result[1] += value;
                            break;
                        case "down":
                            result[1] -= value;
                            break;
                    }
                }
                else
                {
                    return new int[] { 0, 0 };
                }
            }
            return result;
        }

        public bool IsValidHexCode(string str)
        {
            return Regex.IsMatch(str, @"^#[0-9a-f]{6}$|^#[0-9A-F]{6}$");
        }

        public bool IsSymmetrical(int num)
        {
            return num.ToString() == String.Concat(num.ToString().Reverse());
        }
    }
}

