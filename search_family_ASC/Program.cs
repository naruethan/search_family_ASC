// See https://aka.ms/new-console-template for more information
using search_family_ASC.Model;




List<family> fa = new List<family>
    {
        new family{Id = 1, Name = "Lee" ,DOB = Convert.ToDateTime("7 May 1890")},
        new family{Id = 2, Name = "Robert" ,DOB = Convert.ToDateTime("10 July 1920")},
        new family{Id = 3, Name = "Kris" ,DOB = Convert.ToDateTime("26 December 1944")},
    };



string input_name = "Kris";

Console.WriteLine("display the seniority from older to younger by input the name : {0} ", input_name);
Show_family_ASC(input_name, fa);


static void Show_family_ASC(string input_name, List<family> fa)
{

    var list_input =
        (from f in fa
         where f.Name == input_name
         select new { f }).ToList();


    var list_fam = (from fam in fa
                    where fam.Id != list_input[0].f.Id
                    orderby fam.DOB ascending
                    select new { fam }).ToList();

    var las_row = (from la in fa
                   orderby la.DOB ascending
                   select new { la }).ToList().LastOrDefault();


    for (var i = 0; i < list_fam.Count() - 1; i++)
    {

        if (las_row.la.Id == list_input[0].f.Id)
        {
            Console.WriteLine("Not Found");

        }
        else
        {
            Console.WriteLine("{0} > {1}", list_fam[i].fam.Name, list_fam[i + 1].fam.Name);
        };

    }

}