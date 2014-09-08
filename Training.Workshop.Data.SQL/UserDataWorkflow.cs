
namespace workflow
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    
    public static class FakeUser
    {
        private static readonly string[] Names = {"John","Bill","Alex","Christopher","Ada","Adalyn","Adele","Barney"
				 	 ,"Becky","Brandon","Candi","Cate","Dale","Richard","Dyson","Emily"
					 ,"Flora","Floyd","Graham","Hank","Eileen","James","Joshua","Kylie"
					 ,"Laura","Madison","Miles","Morgana","Nelson","Patty","Phyllis"
					 ,"Posy","Ralph","Rex","Ronald","Rudy","Saxon","Sharon","Shelley"
					 ,"Sophia","Stewart","Thomas","Tricia","Vance","Warwick","William"
					 ,"Yasmin","Selma","Zula","Zoe"};

        private static readonly string[] Surnames = {"Adamson","Adhock","Acker","Beckett","Bonner","Brooks","Causer"
						,"Clayton","Cox","Cory","Curtis","Davidson","Dixon","Dyson","Ewart"
						,"Forest","Foster","Garnett","Greene","Harlan","Hawk","Hayley","Hollins"
						,"Howe","Jervis","Kersey","Kirby","Lockwood","Mathews","Merill","Moore"
						,"Nash","Olson","Parish","Peak","Readdie","Rose","Savage","Sexton","Simmons"
						,"Spear","Starr","Tailor","Thomas","Tifft","Tinker","Wallis","West","Woods","York"};
      
        private static readonly Random Rand = new Random();

        public static string GetUser()
        {   
                var str= string.Empty;
                
                str = Names[Rand.Next(0,49)] + " " + Surnames[Rand.Next(0,49)];
                return str;
        }
        
        public static List<string> GetUsers(int count)
        {
            var listofusers = new List<string>();
    
            for(int i = 0; i < count; i++)
            {
                listofusers.Add(Names[Rand.Next(0, 49)] + " " + Surnames[Rand.Next(0, 49)]);
            }
            return listofusers;
        }
    }

         
}    
