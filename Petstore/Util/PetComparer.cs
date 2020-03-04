using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petstore.Model;

namespace Petstore.Util
{
    public class PetComparer : IComparer<Pet>
    {
        public int Compare(Pet x, Pet y)
        {
            if (x.Name == null && y.Name == null) return 0;
            if (x.Name == null) return 1;
            if (y.Name == null) return -1;
            return x.Name.ToLowerInvariant().CompareTo(y.Name.ToLowerInvariant());
        }
    }
}
