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

