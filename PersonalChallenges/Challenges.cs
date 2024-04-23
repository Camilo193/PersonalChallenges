using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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

        public int findLongestSubsequence(List<int> arr)
        {
            int count = arr.Count();
            List<int> values = new List<int>();
            arr.Sort();
            for (int i = count - 1; i >= 1; i--)
            {
                values.Add(arr[i] - arr[i - 1]);
            }

            int sum = values.Sum(x => x);

            if (sum % 2 == 0)
            {
                return count;
            }
            else
            {
                return findLongestSubsequence(arr);
            }
        }

        public List<List<int>> mix(List<int> arr)
        {
            List<List<int>> listOfList = new();
            listOfList.Add(new List<int>(arr));
            int auxiliarCounter = 0;

            while (arr.Count - 1 != 0)
            {
                List<int> auxiliarList = new();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i != auxiliarCounter)
                    {
                        auxiliarList.Add(arr[i]);
                    }
                }
                auxiliarCounter++;
                listOfList.Add(auxiliarList);

                if (auxiliarCounter == arr.Count)
                {
                    arr.RemoveAt(arr.Count - 1);

                    auxiliarCounter = 0;
                }
            }

            return listOfList;
        }
        public List<List<int>> MixN(List<int> arr)
        {
            List<List<int>> result = new();
            List<int> temporalList = new();
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    temporalList.Add(arr[i]);
                    temporalList.Add(arr[j]);
                    result.Add(new List<int>(temporalList));
                    temporalList.Clear();
                }
            }
            return result;
        }

        public List<List<int>> MixTwo(List<int> arr)
        {
            List<List<int>> result = new();

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    List<int> temporalList = new();
                    temporalList.Add(arr[i]);
                    temporalList.Add(arr[j]);

                    var existLast = result.Any(x => x.SequenceEqual(temporalList));
                    var existRepeats = temporalList.GroupBy(x => x).Any(g => g.Count() > 1);

                    if (!existLast && !existRepeats)
                    {
                        result.Add(new List<int>(temporalList));
                    }

                }
            }
            return result;
        }

        public List<int> MixValueWithAll(List<int> arr, int position)
        {
            List<int> result = new();
            for (int i = position + 1; i < arr.Count; i++)
            {
                //result.Add(arr[position]);
                result.Add(arr[i]);
            }
            return result;
        }

        public List<List<int>> GetMix(List<int> arr, int n)
        {
            n--;
            int arrCount = arr.Count - 1;
            List<List<int>> result = new();
            List<int> acumulate = new();

            for (int i = 0; i < arrCount; i++)
            {
                acumulate.Add(arr[i]);
                if (acumulate.Count >= n)
                {
                    var value = MixValueWithAll(arr, i);

                    foreach (var item in value)
                    {
                        List<int> auxiliarList = new();
                        auxiliarList.AddRange(acumulate);
                        auxiliarList.Add(item);
                        result.Add(auxiliarList);
                    }
                    acumulate.RemoveAt(acumulate.Count - 1);
                }
            }
            return result;
        }

        public List<List<int>> GetFinalMix(List<int> arr)
        {
            int quantity = arr.Count - 1;
            List<List<int>> result = new();

            while (arr.Count >= quantity)
            {
                result.AddRange(GetMix(arr, quantity));
                arr.RemoveAt(0);
            }
            return result;
        }

        public List<List<int>> GetNextMix(List<int> arr, List<List<int>> mixTwo)
        {
            List<List<int>> result = new();
            for (int i = 0; i < mixTwo.Count; i++)
            {
                int beginWith = mixTwo[i].First();
                int endWith = mixTwo[i].Last();
                List<int> lastAdd = new List<int>();
                for (int j = i; j < mixTwo.Count; j++)
                {
                    if (mixTwo[j].First() == beginWith && mixTwo[j].Last() != endWith)
                    {
                        List<int> resultList = new List<int>(mixTwo[i]);
                        int getLast = mixTwo[j].Last();

                        lastAdd.Add(getLast);
                        resultList.Add(getLast);
                        resultList.Sort();
                        var existLast = result.Any(x => x.SequenceEqual(resultList));
                        var existRepeats = resultList.GroupBy(x => x).Any(g => g.Count() > 1);
                        if (!existLast && !existRepeats)
                        {
                            result.Add(resultList);
                        }
                    }
                }
            }
            return result;
        }

        public List<List<int>> GetAllMixes(List<int> arr)
        {
            List<List<int>> globalResult = new();
            List<List<int>> result = new();
            List<List<int>> mixTwo = MixTwo(arr);
            globalResult.AddRange(mixTwo);
            for (int i = 0; i < arr.Count - 2; i++)
            {
                if (i == 0) result = GetNextMix(arr, mixTwo);
                else result = GetNextMix(arr, result);
                globalResult.AddRange(result);
            }
            return globalResult;
        }

        public List<List<int>> GetCombination(List<int> list)
        {
            List<List<int>> result = new List<List<int>>();

            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                List<int> list2 = new();
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        list2.Add(list[j]);

                    }
                }
                result.Add(list2);
            }
            result.Sort((a, b) => a.Count - b.Count);
            return result;
        }

        public int diagonalDifference(List<List<int>> arr)
        {
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                int PositionX = arr.Count - 1;
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i == j) primaryDiagonalSum += arr[i][j];
                    if (PositionX == i) secondaryDiagonalSum += arr[i][j];
                    PositionX--;
                }
            }
            return Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
        }

        public void plusMinus(List<int> arr)
        {
            int countPositives = 0;
            int countNegatives = 0;
            int countZeros = 0;

            foreach (var item in arr)
            {
                if (item > 0) countPositives++;
                else if (item < 0) countNegatives++;
                else countZeros++;
            }

            Console.WriteLine(((float)countPositives / arr.Count).ToString("n6"));
            Console.WriteLine(((float)countNegatives / arr.Count).ToString("n6"));
            Console.WriteLine(((float)countZeros / arr.Count).ToString("n6"));
        }

        public void staircase(int n)
        {
            StringBuilder result = new();
            for (int i = 1; i < n; i++)
            {
                result.Append(" ");
            }

            result.Append("#");

            for (int i = n - 1; i >= 0; i--)
            {
                result.Replace(" ", "#", i, 1);
                Console.WriteLine(result);
            }
        }

        public void TableroDeDamas(int n)
        {
            bool EsX = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (EsX)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                    EsX = !EsX;
                }
                Console.Write("\n");
            }

        }

        public void Histograma(int[] arr)
        {
            List<int> lista = arr.ToList();
            lista.Sort();
            //2: Obtenemos el ultimo item del array que seria el valor maximo.
            int maxValue = lista.Max();

            //3: recorremos todos los numeros entre 1 y el valox maximo, para imprimirlos.
            for (int i = 1; i <= maxValue; i++)
            {
                // 4: imprimimos el numero a contar
                Console.Write(i + ": ");
                //5: recorremos el array para imprimir * por cada vez que encontremos el numero actual i
                for (int x = 0; x < lista.Count; x++)
                {
                    // 6: si el numero actual i es igual al numero en la pocision x del array imprime *
                    if (i == arr[x])
                    {
                        Console.Write("*");
                    }
                }
                //7: salto de linea al final de imprimir los * o vacio en caso de no encontrar el número
                Console.WriteLine();
            }
        }

        public void separateByZero(List<int> lista)
        {
            List<int> listaResultado = new List<int>();
            List<int> listaAuxiliar = new List<int>();
            int LastValue = -9999;
            for (int i = 0; i < lista.Count; i++)
            {

                if (lista[i] != 0)
                {
                    listaAuxiliar.Add(lista[i]);
                }
                else
                {
                    if (LastValue != 0)
                    {
                        listaAuxiliar.Sort();
                        listaAuxiliar.Add(lista[i]);
                        listaResultado.AddRange(new List<int>(listaAuxiliar));
                        listaAuxiliar.Clear();
                    }
                    LastValue = 0;
                }
            }

            if (lista.Count != listaResultado.Count)
            {
                listaAuxiliar.Sort();
                listaResultado.AddRange(new List<int>(listaAuxiliar));
                listaAuxiliar.Clear();
            }

            for (int i = 0; i < listaResultado.Count; i++)
            {
                if (listaResultado[i] == 0)
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(listaResultado[i]);
                }
            }
        }

        public int formingMagicSquare(List<List<int>> s)
        {
            return 39;
        }

        //1 2 3 3
        public string balancedSums(List<int> arr)
        {
            if (arr.Count <= 1)
            {
                return "YES";
            }

            int sumLeft = 0;
            int sumRight = arr.Sum() - arr[0];

            if (sumRight == sumLeft)
            {
                return "YES";
            }

            for (int i = 1; i < arr.Count; i++)
            {
                sumLeft += arr[i - 1];
                sumRight -= arr[i];

                if (sumLeft == sumRight)
                {
                    return "YES";
                }

            }
            return "NO";
        }

        public int birthday(List<int> s, int d, int m)
        {
            int result = 0;

            for (int i = 0; i < s.Count; i++)
            {
                int sum = s.Skip(i).Take(m).Sum();
                if (sum == d)
                {
                    result += 1;
                }
            }

            return result;
        }

        public int birthday2(List<int> s, int d, int m)
        {
            var step1 = s.Select((_, index) => s.Skip(index).Take(m).Sum());
            var step2 = step1.Count(sum => sum == d);
            return step2;
        }

        public int birthday3(List<int> s, int d, int m)
        {
            var step1 = s.Select((item, index) => s.Skip(index).Take(m).Sum());
            var step2 = step1.Count(sum => sum == d);
            return step2;
        }

        public int divisibleSumPairs(int n, int k, List<int> ar)
        {
            var step1 = ar.SelectMany((item, index) => ar.Skip(index + 1).Select(y => y + item));
            var step2 = step1.Count(sum => sum % k == 0);
            return step2;
        }

        public int MigratoryBirds(List<int> arr)
        {
            var maxValue = arr.Max();
            var maxValues = arr.Where(x => x == maxValue).Distinct().ToList();

            if (maxValues.Count > 1) 
            {
                switch (maxValue)
                {
                    default:
                        break;
                }
            }
            return 1;
        }

        public int MigratoryBirds2(List<int> arr)
        {
            var migratoryBirds = arr.GroupBy(number => number)
                .Select(group => new
                {
                    Type = group.Key,
                    BirdsNumber = group.Count()
                });

            var maxRepited = migratoryBirds.Max(x => x.BirdsNumber);

            var maxValue = migratoryBirds.Where(x => x.BirdsNumber == maxRepited)
                .Select(x => x.Type).ToList();

            if (maxValue.Count > 1)
            {
                return maxValue.Min();
            }
            else 
            {
                return maxValue.FirstOrDefault();
            }
        }

    }
}

