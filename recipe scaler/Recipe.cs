using System.Collections.Generic;

namespace recipe_scaler
{
    struct Ingredient
    {
        public string name;
        public decimal weight; //per 100ml

        public Ingredient(string name, decimal weight)
        {
            this.name = name;
            this.weight = weight;
        }
    }

    struct Component
    {
        public Ingredient ingredient;
        public decimal quantity;
        public string unit;

        public Component(Ingredient name, decimal quantity, string unit)
        {
            this.ingredient = name;
            this.quantity = quantity;
            this.unit = unit;
        }
    }

    struct Recipe
    {
        public string name;
        public List<Component> components;
        public string desc;

        public Recipe(string name, List<Component> components, string desc)
        {
            this.name = name;
            this.components = components;
            this.desc = desc;
        }
    }
}
