using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petstore.Model;

namespace Petstore.Util
{
    public static class PetExtensions
    {
        //Sort pets into categorys based on name of category (Note: category ids seem to be the same but with different names)
        public static List<Category> SortPetsByCategory(this Pet[] pets)
        {
            //create a list of categories
            var categories = new Dictionary<string, Category>();
            foreach (var pet in pets)
                TryAddToCategory(pet.Category == null ? "" : pet.Category.Name, pet, categories);

            return categories.Select(c => c.Value).ToList();
        }

        //sort pet names in reverse
        public static List<Category> SortPetsByNameInReverse(this List<Category> categories)
        {
            foreach(var category in categories)
            {
                if (category.Pets == null || category.Pets.Count <= 0) continue;
                category.Pets.Sort(new PetComparer());
                category.Pets.Reverse();
            }
            return categories;
        }

        //Add pet to existing dictionary category or create new one in dictionary
        private static void TryAddToCategory(string name, Pet pet, Dictionary<string, Category> categories)
        {
            Category category;
            if (categories.TryGetValue(name == null ? "" : name, out category))
                category.AddPet(pet);
            else
            {
                category = new Category(string.IsNullOrEmpty(name) ? -1 : pet.Category.Id, 
                    string.IsNullOrEmpty(name) ? "No Category" : pet.Category.Name);
                category.AddPet(pet);
                categories.Add(name, category);
            }
        }
    }
}
