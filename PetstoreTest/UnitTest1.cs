using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Petstore.Util;
using Petstore.Model;
using System.Linq;

namespace PetstoreTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanGetPetsWithoutError()
        {
            var pets = ApiReader.GetAvailablePets();

            Assert.IsTrue(pets != null);
            Assert.IsTrue(pets.Length > 0);
        }

        [TestMethod]
        public void CanAddPetToCategoryWithoutError()
        {
            var pet = new Pet();
            pet.Name = "TestPet";

            var category = new Category(1, "TestCategory");
            category.AddPet(pet);

            Assert.IsTrue(category.Pets != null && category.Pets.Count > 0);
            Assert.AreEqual("TestPet", category.Pets.Single().Name);
        }

        [TestMethod]
        public void ShouldThrowErrorIfTryingToReadPetsFromNewCategory()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                var category = new Category(0, "TestCategory");
                var pet = category.Pets[0];
            });
        }

        [TestMethod]
        public void CanSortPetsIntoCategoriesWithoutError()
        {
            var pets = ApiReader.GetAvailablePets();

            Assert.IsTrue(pets != null);
            Assert.IsTrue(pets.Length > 0);

            var categories = pets.SortPetsByCategory();

            Assert.IsTrue(categories != null);
            Assert.IsTrue(categories.Count > 0);
        }


    }
}
