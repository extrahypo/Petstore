using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Model
{
    public class Pet
    {
        public long Id;
        public Category Category;
        public string Name;
        public string[] Photourls;
        public Tag[] Tags;
        public Status Status;        
    }

    public enum Status
    {
        Available,
        Pending,
        Sold
    }
}
