using PersonalChallenges;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


Challenges challenge = new Challenges();

Person personas = new Person();

personas.AverageAgeByCompany(personas.crearPersonas());

Console.WriteLine(challenge.ReverseAndNotWithoutMethods(54321));

Console.WriteLine(challenge.ReverseCase("AbCd"));

var juan = new Allergies("Juan", "Cats");

Console.WriteLine(juan.ToString() + " " + juan.Score);

Console.WriteLine(juan.IsAlergicTo("Eggs"));

juan.AddAllergy("Eggs");

Console.WriteLine(juan.ToString() + " " + juan.Score);

juan.RemoveAllergy("Eggs");

Console.WriteLine(juan.ToString() + " " + juan.Score);



int[,] CannotCapture = (new int[,] {
  { 1, 0, 0, 1, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 1, 0, 0 },
  { 1, 0, 0, 0, 1, 0, 1, 0 },
  { 0, 1, 0, 0, 0, 1, 0, 0 },
  { 0, 0, 0, 0, 1, 0, 0, 0 },
  { 0, 1, 0, 0, 0, 0, 0, 1 },
  { 0, 0, 0, 0, 1, 0, 0, 0 }
});

Console.WriteLine("Chess: " + challenge.CannotCapture(CannotCapture));

//3.14159265358979

var result2 = challenge.PilishString("HOWINEEDADRINKALCOHOLICINNATUREAFTERTHEHEAVYLECTURESINVOLVINGQUANTUMMECHANICSANDALLTHESECRETSOFTHEUNIVERSE");

Console.WriteLine(result2);

Console.WriteLine("Prime: " + challenge.isPrime(60));

var primesInRange = challenge.PrimeInRange(1, 100);

foreach (var item in primesInRange)
{
    Console.WriteLine(item);
}


Console.WriteLine($"Previous: {challenge.PreviousPrime(97, 0)}, Next: {challenge.NextPrime(97)}");

Console.WriteLine("Loneliest: " + challenge.LoneliestNumber(8, 123));

var lookandsayResult = challenge.LookAndSay2(1, 7);

foreach (var item in lookandsayResult)
{
    Console.WriteLine("LookAndSay: " + item);
}

string testingSubString = "Joa mani no te tocaba";

testingSubString = testingSubString.Substring(0, 1);

Console.WriteLine(testingSubString);


string txt = "Wh*r* d*d my v*w*ls g*?";
var vowels = "eeioeo".ToArray();

decimal aa = 55.00m;
decimal bb = 55;

Console.WriteLine("Decimal: " + Decimal.Equals(aa, bb));



Console.WriteLine(challenge.Uncensor("Wh*r* d*d my v*w*ls g*?", "eeioeo"));

Console.WriteLine(challenge.ReverseAndNot(123));




foreach (var item in challenge.TrackRobot(new string[] { "rigsht 75", "up 20", "left 62", "down 3" }))
{
    Console.WriteLine(item);
}

Console.WriteLine(challenge.IsValidHexCode("#CD555f"));

Console.WriteLine(challenge.IsSymmetrical(2112));

List<int> arr = new List<int>() {1, 2, 3, 4, 5};
var result = challenge.GetAllMixes(arr);

var getCombination = challenge.GetCombination(arr);
Console.WriteLine("-----------------------------------------");

List<List<int>> matriz = new();
matriz.Add(new List<int>() { 11, 2, 4 });
matriz.Add(new List<int>() { 4, 5, 6 });
matriz.Add(new List<int>() { 10, 8, -12 });
var diagonalDifference = challenge.diagonalDifference(matriz);

challenge.staircase(6);

Console.WriteLine("");

challenge.TableroDeDamas(7);

challenge.Histograma(new int[] { 1, 2, 1, 3, 3, 1, 2, 1, 5, 1 });

challenge.separateByZero(new List<int>() { 2,1,0,0,3,4});

Console.WriteLine("");


Console.WriteLine(challenge.balancedSums(new List<int>() { 1, 2, 3, 3}));

Console.WriteLine(challenge.birthday2(new List<int>() { 1, 2, 1, 3, 2 }, 3, 2));

Console.WriteLine(challenge.divisibleSumPairs(6, 5, new List<int>() { 1, 2, 3, 4, 5, 6 }));

Console.WriteLine(challenge.MigratoryBirds2(new List<int>() { 1, 4, 4, 4, 5, 3, 3, 3 }));


