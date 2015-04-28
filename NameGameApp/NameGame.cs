using System;
using System.Text.RegularExpressions;

namespace NameGameApp
{
    public class NameGameApp
    {
        static void Main(string[] args)
        {
            var nameGenerator = new NameGenerator();
            Console.WriteLine("Please enter a name: ");
            var name = Console.ReadLine();

            if (name != null)
            {
                name = name.Trim().ToLower();
            }

            Console.WriteLine(nameGenerator.NameMessage(name, nameGenerator.ModifyName(name)));
            Console.Read();


        }
    }

    public class NameGenerator
    {
        public string ModifyName(string name)
        {
            var regex = new Regex(@"(ch|sh|st)");
            var match = regex.Match(name);
            name = name.Remove(0, match.Success ? 2 : 1);
            return name;
        }


        public string NameMessage(string name, string newName)
        {
            var regex = new Regex(@"[bfm]");
            var match = regex.Match(name);
            return string.Format(match.Success ? "{0}, {0}, bo-{1} \r\nBanana-fana fo-{1} \r\nFee-fi mo-{1} \r\n{0}!" : "{0}, {0}, bo-b{1} \r\nBanana-fana fo-f{1} \r\nFee-fi mo-m{1} \r\n{0}!", name, newName);
        }

    }
}
