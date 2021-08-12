using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_scaler
{
    static class DBHandler
    {
        public const string ITEMSFILE = "items.db";
        public const string RECIPEFILE = "Recipes.db";
        public static readonly Encoding encoding = Encoding.UTF8;

        static private List<Ingredient> ingredients = new List<Ingredient>();
        static private List<Recipe> recipes = new List<Recipe>();

        internal static List<Recipe> Recipes { get => recipes; }
        internal static List<Ingredient> Ingredients { get => ingredients; }

        public static List<string> getRange<T>()
        {
            List<string> range = new List<string>();

            if (typeof(T) == typeof(Recipe))
            {
                foreach (Recipe recipe in recipes)
                {
                    range.Add(recipe.name);
                }
            }

            if (typeof(T) == typeof(Ingredient))
            {
                foreach (Ingredient ingredient in Ingredients)
                {
                    range.Add(ingredient.name);
                }
            }

            return range;
        }

        public static void loadItemFile()
        {
            ingredients.Clear();

            if (!File.Exists(ITEMSFILE))
                return;

            StreamReader sr = new StreamReader(ITEMSFILE, encoding);

            string item = sr.ReadLine();

            while (item != null)
            {
                string[] strings = item.Split(';');

                ingredients.Add(new Ingredient(strings[0], decimal.Parse(strings[1])));
                item = sr.ReadLine();
            }
            sr.Close();
        }

        public static void loadRecipeFile()
        {
            recipes.Clear();

            if (!File.Exists(RECIPEFILE))
                return;

            StreamReader sr = new StreamReader(RECIPEFILE, encoding);

            string item = sr.ReadLine();
            while (item != null)
            {
                string name = item;

                item = sr.ReadLine();
                List<Component> components = new List<Component>();
                while (item != "[ITEMEND]")
                {
                    string[] strings = item.Split(';');

                    components.Add(new Component(ingredients[findIngredientID(strings[0])], decimal.Parse(strings[1]), strings[2]));
                    item = sr.ReadLine();
                }

                item = sr.ReadLine();
                string desc = "";
                while (item != "[END]")
                {
                    desc += item + "\r\n";
                    item = sr.ReadLine();
                }

                desc = desc.Substring(0, desc.Length - 2);

                recipes.Add(new Recipe(name, components, desc));

               
                item = sr.ReadLine();
            }
            sr.Close();
        }

        public static int findIngredientID(string name)
        {
            int id = -1;

            for (int i = 0; i < ingredients.Count && id == -1; i++)
                if (ingredients[i].name == name)
                    id = i;

            return id;
        }

        public static void addIngredient(string name, decimal weight = 0)
        {
            if (findIngredientID(name) != -1)
                return;

            StreamWriter sw = new StreamWriter(ITEMSFILE, true, encoding);

            sw.WriteLine(name + ";" + weight);
            sw.Close();
        }

        public static void addRecipe(Recipe recipe)
        {
            StreamWriter sw = new StreamWriter(RECIPEFILE, true, encoding);
            sw.WriteLine(recipe.name);

            foreach (Component comp in recipe.components)
            {
                sw.WriteLine(comp.ingredient.name + ";" + comp.quantity + ";" + comp.unit + ";");
            }

            sw.WriteLine("[ITEMEND]");

            sw.WriteLine(recipe.desc);

            sw.WriteLine("[END]");
            sw.Close();
        }

    }
}
