using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChallenges
{
    public class Allergies
    {
        public readonly string Name;
        public int Score { get; set; }
        public string AllergiesName { get; set; }

        public string? Result { get; set; }

        public enum Allergen
        {
            Eggs = 1,
            Peanuts = 2,
            Shellfish = 4,
            Strawberries = 8,
            Tomatoes = 16,
            Chocolate = 32,
            Pollen = 64,
            Cats = 128
        }

        public Allergies(string name, string? allergies = null)
        {
            Name = name;

            if (!String.IsNullOrEmpty(allergies))
            {
                List<string> listOfAllergies = allergies.Split(" ").ToList();
                List<string> EnumNames = Enum.GetNames<Allergen>().ToList();

                listOfAllergies = listOfAllergies.Intersect(EnumNames).ToList();

                AllergiesName = String.Join(" ", listOfAllergies);

                Score = listOfAllergies.Sum(x => (int)Enum.Parse(typeof(Allergen), x));
            }
        }

        public Allergies(string name, int score)
        {
            Score = score;
            Name = name;
            StringBuilder AllergiesNameBuilder = new StringBuilder("");

            List<int> enumScore = Enum.GetValues<Allergen>().Cast<int>().ToList();
            List<string> enumName = Enum.GetNames<Allergen>().ToList();

            for (int i = enumScore.Count - 1; i > 0; i--)
            {
                if (score >= enumScore[i])
                {
                    score -= enumScore[i];
                    AllergiesNameBuilder.AppendFormat("{0} ", enumName[i]);
                }
            }

            AllergiesName = AllergiesNameBuilder.ToString().TrimEnd();

        }

        public bool IsAlergicTo(string allergen)
        {
            List<string> listOfAllergies = AllergiesName.ToString().Split(" ").ToList();
            return listOfAllergies.Any(x => x == allergen);
        }

        public void AddAllergy(string allergen)
        {
            List<string> listOfAllergies = AllergiesName.ToString().Split(" ").ToList();

            if (!IsAlergicTo(listOfAllergies, allergen) && ExistAllergenInEnum(allergen))
            {
                AllergiesName = String.Format("{0} {1}", AllergiesName, allergen);
                Score = Score + (int)Enum.Parse(typeof(Allergen), allergen);
            }
        }

        public void RemoveAllergy(string allergen)
        {
            List<string> listOfAllergies = AllergiesName.ToString().Split(" ").ToList();

            bool IsAlergicTo = listOfAllergies.Any(x => x == allergen);
            bool ExistAllergenInEnum = Enum.GetNames<Allergen>().Any(x => x == allergen);

            if (IsAlergicTo && ExistAllergenInEnum)
            {
                AllergiesName = AllergiesName.Replace(allergen, "").Replace("  ", " ").TrimEnd();
                Score = Score - (int)Enum.Parse(typeof(Allergen), allergen);
            }

        }

        public override string ToString()
        {
            StringBuilder ResultBuilder = new StringBuilder("");
            List<string> listOfAllergies = new List<string>();

            if (string.IsNullOrEmpty(AllergiesName))
            {
                Result = String.Format("{0} has no allergies", Name);
                return Result;
            }
            else if (AllergiesName.ToString().Split(" ").Length == 1)
            {
                Result = String.Format("{0} is allergic to {1}", Name, AllergiesName);
                return Result;
            }
            else
            {
                ResultBuilder.AppendFormat("{0} is allergic to ", Name);
                listOfAllergies.AddRange(AllergiesName.ToString().Split(" "));

                for (int i = 0; i <= listOfAllergies.Count - 1; i++)
                {
                    if (i != listOfAllergies.Count - 1)
                    {
                        ResultBuilder.AppendFormat("{0}, ", listOfAllergies[i]);
                    }
                    else
                    {
                        ResultBuilder.Remove(ResultBuilder.Length - 2, 1);
                        ResultBuilder.AppendFormat("and {0}", listOfAllergies[i]);
                    }
                }

                Result = ResultBuilder.ToString().TrimEnd(' ', 'a', 'n', 'd', ',');
                return Result;
            }
        }

        private bool ExistAllergenInEnum(string allergen)
        {
            return Enum.GetNames<Allergen>().Any(x => x == allergen);
        }

        private bool IsAlergicTo(List<string> allergies, string allergen)
        {
            return allergies.Any(x => x == allergen);
        }
    }
}
