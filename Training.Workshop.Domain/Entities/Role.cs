using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.Domain.Entities
{
    [Serializable]
    public class Role : Entitybase
    {
        public string Name { get; set; }

        public List<string> Permissions { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Role)obj;

            if (other != null)
            {
                if (Name == other.Name)
                {

                    foreach (var el in other.Permissions)
                    {
                        if (!Permissions.Contains(el))
                        {
                            return false;
                        }
                    }

                    foreach (var el in Permissions)
                    {
                        if (!other.Permissions.Contains(el))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            string stringforhashcode = "";

            foreach (var permission in Permissions)
            {
                stringforhashcode += permission;
            }
            return string.Format("{0}{1}", Name, stringforhashcode).GetHashCode();
        }

    }

}
