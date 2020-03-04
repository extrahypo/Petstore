using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Petstore.Model;
using Petstore.Util;

namespace Petstore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get Available Pets
            var pets = ApiReader.GetAvailablePets();

            //Check if there are no pets available
            if (pets == null || pets.Length <= 0)
            {
                Console.WriteLine("No available pets");
                Console.Read();
                return;
            }

            //Sort pets by category and reversed pet name
            var sorted = pets.SortPetsByCategory().SortPetsByNameInReverse();

            //output available pets
            Console.WriteLine("Avaliable pets");
            foreach (var category in sorted)
            {
                Console.WriteLine("Category: {0}", category.Name);
                if (category.Pets == null || category.Pets.Count <= 0) continue;
                foreach (var pet in category.Pets)
                    Console.WriteLine(pet.Name == null ? string.Empty : @pet.Name);
            }

            Console.Read();
        }
    }
}
