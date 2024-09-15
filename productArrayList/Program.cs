using System.Collections;

ArrayList brands = new ArrayList() { "Apple", "Samsung", "Dell" };
ArrayList models = new ArrayList() { "iPhone 11", "Galaxy S10", "XPS 15" };
ArrayList prices = new ArrayList() { 800, 600, 1200 };
ArrayList quantities = new ArrayList() { 50, 70, 30 };
ArrayList categories = new ArrayList() { "phone", "phone", "notebook" };

while (true)
{
    Console.Write("1. Show all products \n" +
                  "2. Show products by category \n" +
                  "3. Show total company price \n" +
                  "4. Show total price for category \n" +
                  "5. Add product \n" +
                  "6. Sell product \n" +
                  "7. Exit \n" +
                  "Choose an option: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Clear();
            ShowAllProducts(brands, models, prices, quantities, categories);
            break;
            
        case 2:
            Console.Clear();
            Console.Write("Enter category (notebook/phone): ");
            string category = Console.ReadLine();
            ShowProductsByCategory(brands, models, prices, quantities, categories, category);
            break;

        case 3:
            Console.Clear();
            ShowTotalCompanyPrice(prices, quantities);
            break;

        case 4:
            Console.Clear();
            Console.Write("Enter category (notebook/phone): ");
            string categoryPrice = Console.ReadLine();
            ShowTotalPriceForCategory(brands, models, prices, quantities, categories, categoryPrice);
            break;

        case 5:
            Console.Clear();
            AddProduct(brands, models, prices, quantities, categories);
            break;

        case 6:
            Console.Clear();
            SellProduct(brands, models, prices, quantities, categories);
            break;

        case 7:
            Console.Clear();
            return;
        default:
            Console.Clear();
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}
static void ShowAllProducts(ArrayList brands, ArrayList models, ArrayList prices, ArrayList quantities, ArrayList categories)
{
    if (brands.Count == 0)
    {
        Console.WriteLine("No products available.");
    }
    else
    {
        for (int i = 0; i < brands.Count; i++)
        {
            Console.WriteLine($"Brand: {brands[i]}\n " +
                $"Model: {models[i]}\n " +
                $"Price: {prices[i]}\n " +
                $"Quantity: {quantities[i]}\n " +
                $"Category: {categories[i]}\n");
        }
    }
}

static void ShowProductsByCategory(ArrayList brands, ArrayList models, ArrayList prices, ArrayList quantities, ArrayList categories, string category)
{
    bool found = false;
    for (int i = 0; i < brands.Count; i++)
    {
        if (categories[i].ToString().ToLower() == category.ToLower())
        {
            Console.WriteLine($"Brand: {brands[i]}\n" +
                $"Model: {models[i]}\n " +
                $"Price: {prices[i]}\n " +
                $"Quantity: {quantities[i]}\n " +
                $"Category: {categories[i]}\n");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine($"No products found in {category} category. \n");
    }
}

static void ShowTotalCompanyPrice(ArrayList prices, ArrayList quantities)
{
    double total = 0;
    for (int i = 0; i < prices.Count; i++)
    {
        total += Convert.ToDouble(prices[i]) * Convert.ToInt32(quantities[i]);
    }
    Console.WriteLine($"Total company price: {total}\n");
}

static void ShowTotalPriceForCategory(ArrayList brands, ArrayList models, ArrayList prices, ArrayList quantities, ArrayList categories, string category)
{
    double total = 0;
    for (int i = 0; i < brands.Count; i++)
    {
        if (categories[i].ToString().ToLower() == category.ToLower())
        {
            total += Convert.ToDouble(prices[i]) * Convert.ToInt32(quantities[i]);
        }
    }
    Console.WriteLine($"Total price for {category}: {total}");
}

static void AddProduct(ArrayList brands, ArrayList models, ArrayList prices, ArrayList quantities, ArrayList categories)
{
    Console.Write("Enter brand: ");
    string brand = Console.ReadLine();

    Console.Write("Enter model: ");
    string model = Console.ReadLine();

    Console.Write("Enter price: ");
    double price = double.Parse(Console.ReadLine());

    Console.Write("Enter quantity: ");
    int quantity = int.Parse(Console.ReadLine());

    Console.Write("Enter category (notebook/phone): ");
    string category = Console.ReadLine();

    brands.Add(brand);
    models.Add(model);
    prices.Add(price);
    quantities.Add(quantity);
    categories.Add(category);

    Console.WriteLine("Product added successfully.\n");
}

static void SellProduct(ArrayList brands, ArrayList models, ArrayList prices, ArrayList quantities, ArrayList categories)
{
    Console.Write("Enter the brand of the product to sell: ");
    string brand = Console.ReadLine();

    Console.Write("Enter the model of the product to sell: ");
    string model = Console.ReadLine();

    for (int i = 0; i < brands.Count; i++)
    {
        if (brands[i].ToString().ToLower() == brand.ToLower() && models[i].ToString().ToLower() == model.ToLower())
        {
            Console.Write("Enter quantity to sell: ");
            int sellQuantity = int.Parse(Console.ReadLine());

            if (sellQuantity <= Convert.ToInt32(quantities[i]))
            {
                quantities[i] = Convert.ToInt32(quantities[i]) - sellQuantity;
                Console.WriteLine("Product sold successfully.");

                if (Convert.ToInt32(quantities[i]) == 0)
                {
                    RemoveProduct(brands, models, prices, quantities, categories, i);
                    Console.WriteLine("Product is out of stock and removed from inventory.\n");
                }
                return;
            }
            else
            {
                Console.WriteLine("Not enough quantity available.\n");
                return;
            }
        }
    }

    Console.WriteLine("Product not found.\n");
}

static void RemoveProduct(ArrayList brands, ArrayList models, ArrayList prices, ArrayList quantities, ArrayList categories, int index)
{
    brands.RemoveAt(index);
    models.RemoveAt(index);
    prices.RemoveAt(index);
    quantities.RemoveAt(index);
    categories.RemoveAt(index);
}
