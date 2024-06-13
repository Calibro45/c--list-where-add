namespace ListWhere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nome1 = new Character("Darth Vader");

            var listaNomi = new List<Character>
            {
                new Character("Luke Skywalker"),
                new Character("Obi Wan Kenobi"),
                new Character("Anakin Skywalker"),
                new Character("Yoda")
            };

            listaNomi.Add(nome1);

            foreach (var nome in listaNomi)
            {
                Console.WriteLine(nome.Name);
            }

            Console.WriteLine("\n"); 

            List<Character> listaNomi2 = new List<Character>();

            listaNomi2.Add(new Character("Quigon Gin"));
            listaNomi2.Add(new Character("Mace Windu"));

            listaNomi.AddRange(listaNomi2);

            foreach (var nome in listaNomi)
            {
                Console.WriteLine(nome.Name);
            }

            Console.WriteLine("\n");

            var trovati = listaNomi
                .Where(x =>
                x.Name.Contains("Skywalker")
                );

            var trovati2 = listaNomi
                .Where(x =>
                x.Name.Contains("Luke")
                && x.Name.Contains("Skywalker")
                );

            foreach (var nome in trovati)
            {
                Console.WriteLine(nome.Name);
            }

            Console.WriteLine("\n");

            foreach (var nome in trovati2)
            {
                Console.WriteLine(nome.Name);
            }

            Console.WriteLine("\n");

            listaNomi.Add(new Character("Princess Leia Skywalker"));

            Func<Character, bool> predicato = x =>
                x.Name.Contains("Skywalker");

            var trovati3 = listaNomi.Where(predicato);

            foreach (var nome in trovati3)
            {
                Console.WriteLine(nome.Name);
            }

            Console.WriteLine("\n");

            var listaPredicati = new List<Func<Character, bool>>();

            listaPredicati.Add(predicato);

            Func<Character, bool> predicato2 = x =>
                x.Name.Contains("Obi")
                && x.Name.Contains("Wan");

            Func<Character, bool> predicato3 = x =>
                x.Name.Contains("Darth");

            listaPredicati.Add(predicato2);
            listaPredicati.Add(predicato3);

            var listaNomiTrovati = new List<Character>();

            foreach (var p in listaPredicati)
            {
                var pgs = listaNomi.Where(p);

                listaNomiTrovati.AddRange(pgs);
                //foreach (var n in pgs)
                //{
                //    Console.WriteLine(n.Name);
                //}
            }

            foreach (var nome in listaNomiTrovati)
            {
                Console.WriteLine(nome.Name);
            }

        }
    }
}
