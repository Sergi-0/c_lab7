namespace ClassLibrary
{
    public class MyAttribute : Attribute
    {
        public string Comment { get; set; }
        MyAttribute() { }
        public MyAttribute(string Comment)
        {
            this.Comment = Comment;
        }
    }

    [MyAttribute("Классификация животных(травоядные, хищники, всеядные")]
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    [MyAttribute("Классификация еды(мясо, растения, всё")]
    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [MyAttribute("Родительский класс Animal ")]
    public abstract class Animal
    {
        public string Country { get; set; } // обязательно должны быть именно свойства(properties), а не поля !
        public string HideFromOtherAnimals {  get; set; }
        public string Name {  get; set; }
        public string WhatAnimal {  get; set; }
        public eClassificationAnimal classifications {  get; set; }
        public eFavouriteFood favouriteFood {  get; set; }

        public Animal(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classifications, eFavouriteFood favouriteFood)
        {
            this.Country = Country;
            this.HideFromOtherAnimals = HideFromOtherAnimals;
            this.Name = Name;
            this.WhatAnimal = WhatAnimal;
            this.classifications = classifications;
            this.favouriteFood = favouriteFood;
        }

        public void Deconstruct(out string Country, out string HideFromOtherAnimals, out string Name, out string WhatAnimal)
        {
            Country = this.Country;
            HideFromOtherAnimals = this.HideFromOtherAnimals;
            Name = this.Name;
            WhatAnimal = this.WhatAnimal;
        }

        public eClassificationAnimal GetClassificationsAnimal() { return classifications; }

        public virtual string GetFavouriteFood() { return favouriteFood.ToString(); }

        public abstract void SayHello();
    }

    [MyAttribute("Класс коровы производный от Animal")]
    public class Cow : Animal
    {
        public Cow(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classifications, eFavouriteFood favouriteFood) : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classifications, favouriteFood) { }

        public override string GetFavouriteFood() { return $"Корова любит {favouriteFood}. Ням-ням!"; }

        public override void SayHello() { Console.WriteLine("ММУУУУУУУУУУУ!!! Hello"); }
    }

    [MyAttribute("Класс льва производный от Animal")]
    public class Lion : Animal
    {
        public Lion(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classifications, eFavouriteFood favouriteFood) : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classifications, favouriteFood) { }

        public override string GetFavouriteFood() { return $"Лев любит {favouriteFood}. РРНям-ням!"; }

        public override void SayHello() { Console.WriteLine("РРРРРРРРРРРРрр!!!"); }
    }

    [MyAttribute("Класс свиньи производный от Animal")]
    public class Pig : Animal
    {
        public Pig(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classifications, eFavouriteFood favouriteFood) : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classifications, favouriteFood) { }

        public override string GetFavouriteFood() { return $"Свинья любит {favouriteFood}. Хр.., ой то есть, Ням-ням!"; }

        public override void SayHello() { Console.WriteLine("ХРЮюююю ХРЮЮЮЮЮ!!!"); }
    }
}