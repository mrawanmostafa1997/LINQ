// 1. Create the product data (a List of Product objects)
using LINQ.S01;

List<Product> products = new List<Product>
{
    new Product(1, "Atlantic Salmon Fillet", "Seafood", 18.50m, 50),
    new Product(2, "Wild-Caught Cod Loins", "Seafood", 15.99m, 30),
    new Product(3, "Large Peeled Shrimp", "Seafood", 22.00m, 40),
    new Product(4, "Fresh Scallops", "Seafood", 29.99m, 25),
    new Product(5, "Tuna Steaks", "Seafood", 19.75m, 35),
    new Product(6, "Organic Chicken Breast", "Meat", 12.99m, 60),
    new Product(7, "Grass-Fed Ground Beef", "Meat", 9.99m, 70),
    new Product(8, "Farm Fresh Eggs (Dozen)", "Dairy & Eggs", 4.50m, 100),
    new Product(9, "Whole Milk (Gallon)", "Dairy & Eggs", 3.79m, 80),
    new Product(10, "Artisan Sourdough Bread", "Bakery", 5.25m, 45),
    new Product(11, "Heirloom Tomatoes (lb)", "Produce", 3.29m, 90),
    new Product(12, "Alaskan King Crab Legs", "Seafood", 45.00m, 15)
};


IEnumerable<Product> seafoodProducts = products.Where(p => p.Category == "Seafood");


foreach (Product product in seafoodProducts)
{
    // Using string interpolation for clear output
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}"); // :C formats as currency
}

Console.WriteLine("-----------------------------------");

//2. Get a list of only the product names from ProductList. Print each name.
IEnumerable<string> productNames = products.Select(p => p.Name);

foreach (string name in productNames)
{
    Console.WriteLine(name);
}

//3. Sort all products by UnitPrice (ascending). Print each product's name and price.
IEnumerable<Product> sortedProducts = products.OrderBy(p => p.Price);

foreach (Product product in sortedProducts)
{
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}");
}

//4. Get all products where UnitPrice is between 10 and 30
IEnumerable<Product> filteredProducts = products.Where(p => p.Price >= 10m && p.Price <= 30m);

foreach (Product product in filteredProducts)
{
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}");
}

//5. Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
IEnumerable<Product> condimentsInStock = products.Where(p => p.Stock > 0 && p.Category == "Condiments");

foreach (Product product in condimentsInStock)
{
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}");
}


/*6. Create a new anonymous type with three properties:
● Name → the product name
● Price → the unit price
● StockStatus → a string: "Available" if UnitsInStock > 0,
otherwise "Out of Stock"
● Print the result.*/

var productInfo = products.Select(p => new
{
    Name = p.Name,
    Price = p.Price,
    StockStatus = p.Stock > 0 ? "Available" : "Out of Stock"
});

foreach (var info in productInfo)
{
    Console.WriteLine($"Name: {info.Name}, Price: {info.Price:C}, Stock Status: {info.StockStatus}");
}

//7. Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.
var productsWithIndex = products.Select((p, index) => new
{
    Index = index + 1, // Convert to 1-based index
    Name = p.Name
});
foreach (var item in productsWithIndex)
{
    Console.WriteLine($"{item.Index}. {item.Name}");
}


/* 8. Sort ProductList by Category ascending, then within each
category, sort by UnitPrice descending.*/
IEnumerable<Product> sortedByCategoryAndPrice = products
    .OrderBy(p => p.Category)
    .ThenByDescending(p => p.Price);
foreach (Product product in sortedByCategoryAndPrice)
    {
    Console.WriteLine($"Category: {product.Category}, Name: {product.Name}, Price: {product.Price:C}");
}
/*9. Get all products from the "Beverages" category, sorted by
UnitsInStock descending. Print name and stock.*/
IEnumerable<Product> beveragesInStock = products
    .Where(p => p.Category == "Beverages")
    .OrderByDescending(p => p.Stock);

foreach (Product product in beveragesInStock)
{
    Console.WriteLine($"Name: {product.Name}, Stock: {product.Stock}");
}
/*10. Using QUERY SYNTAX with a compound from clause, list
all orders placed in 1997 or later showing CustomerID and
OrderDate.*/




//11. Show position number alongside ProductName
var productsWithPosition = products.Select((p, index) => new
{
    Position = index + 1, // 1-based index
    Name = p.Name
});
foreach (var item in productsWithPosition)
{
    Console.WriteLine($"{item.Position}. {item.Name}");
}
foreach (Product product in products)
    {
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}");
}

/*
 12. Sort first by-word length and then by a
case-insensitive sort of the words in an array.

String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
 */

string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
var sortedArr = Arr
    .OrderBy(word => word.Length) // Sort by word length
    .ThenBy(word => word, StringComparer.OrdinalIgnoreCase); // Then sort case-insensitively
foreach (string word in sortedArr)
    {
    Console.WriteLine(word);
}

/*13. Create a list of all digits in the array whose second
letter is 'i' that is reversed from the order in the
original array.*/

string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
foreach (string word in digits)
    {
    if (word.Length > 1 && word[1] == 'i')
    {
        Console.WriteLine(word);
    }
}
