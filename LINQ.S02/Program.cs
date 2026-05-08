using LINQ.S02;

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

//1. Get top 3 most expensive products
IEnumerable<Product> topExpensiveProducts = products.OrderByDescending(p => p.Price).Take(3);

foreach (Product product in topExpensiveProducts)
{
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}");
}
//2. show page 2 of products, with page size = 5
int pageSize = 5;
int pageNumber = 2;
IEnumerable<Product> pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
/*3. Take products from the list as long as Their UnitPrice is less than
$25 (list is ordered by price).*/

IEnumerable<Product> productsUnder25 = products.OrderBy(p => p.Price).TakeWhile(p => p.Price < 25m);

//4. Check if ALL products in the "Seafood" category are in stock
bool allSeafoodInStock = products.Where(p => p.Category == "Seafood").All(p => p.Stock > 0);

/*5. Check if the ID list contains 9
int[] ids = { 3, 9, 13, 18 };*/

int[] ids = { 3, 9, 13, 18 };
bool containsId9 = ids.Contains(9);

/*6. Group all products by Category and print each group with its
product count.*/
IEnumerable<IGrouping<string, Product>> productsByCategory = products.GroupBy(p => p.Category);
/*7. Group products by Category and project only product names per
group*/
IEnumerable<IGrouping<string, string>> productNamesByCategory = products.GroupBy(p => p.Category, p => p.Name);

foreach (IGrouping<string, string> group in productNamesByCategory)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (string productName in group)
    {
        Console.WriteLine($" - {productName}");
    }
}

/*8. Find all categories that have MORE THAN 3 products*/
IEnumerable<string> categoriesWithMoreThan3Products = products.GroupBy(p => p.Category)
    .Where(g => g.Count() > 3)
    .Select(g => g.Key);

foreach (string category in categoriesWithMoreThan3Products)

    {
    Console.WriteLine(category);
}

/*9. Using QUERY SYNTAX, group customers by Country, and for each
group select { Country, Count, TotalOrderValue }.*/


/*10. Calculate the total number of units in stock across all products*/
int totalUnitsInStock = products.Sum(p => p.Stock);

/*11. Find the CHEAPEST and MOST EXPENSIVE product prices*/
decimal cheapestPrice = products.Min(p => p.Price);
decimal mostExpensivePrice = products.Max(p => p.Price);

/*12. Get a distinct list of all product categories*/
IEnumerable<string> distinctCategories = products.Select(p => p.Category).Distinct();

/*13. find product IDs that are in setA but NOT in setB
int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
int[] setB = { 3, 6, 9, 12, 15, 13 };*/

int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
int[] setB = { 3, 6, 9, 12, 15, 13 };
IEnumerable<int> idsInAOnly = setA.Except(setB);

/*14. Find countries that appear in list1 but NOT in list2
(case-insensitive).
string[] list1 = { "Germany", "France", "UK", "Spain" };
string[] list2 = { "france", "SPAIN", "Italy" };*/

string[] list1 = { "Germany", "France", "UK", "Spain" };
string[] list2 = { "france", "SPAIN", "Italy" };
IEnumerable<string> countriesInList1Only = list1.Except(list2, StringComparer.OrdinalIgnoreCase);


/*15. Build a Dictionary<int, Product> keyed by ProductID. Then
retrieve and print the product with ID = 18.*/
Dictionary<int, Product> productDictionary = products.ToDictionary(p => p.Id);
if (productDictionary.TryGetValue(18, out Product productWithId18))
{
    Console.WriteLine($"Product with ID 18: Name: {productWithId18.Name}, Price: {productWithId18.Price:C}");
}
else
{
    Console.WriteLine("Product with ID 18 not found.");
}

/*16. Get the first product whose price is greater than $50.*/
Product firstExpensiveProduct = products.FirstOrDefault(p => p.Price > 50m);
if (firstExpensiveProduct != null)
{
    Console.WriteLine($"First product with price > $50: Name: {firstExpensiveProduct.Name}, Price: {firstExpensiveProduct.Price:C}");
}
else
{
    Console.WriteLine("No product found with price > $50.");
}

/*17. Try to get the first product with a price > $500. it returns null
instead of throwing.*/
Product veryExpensiveProduct = products.FirstOrDefault(p => p.Price > 500m);
if (veryExpensiveProduct != null)
{
    Console.WriteLine($"First product with price > $500: Name: {veryExpensiveProduct.Name}, Price: {veryExpensiveProduct.Price:C}");
}
else
{
    Console.WriteLine("No product found with price > $500.");
}

/*18. Generate a multiplication table row for 7*/
int number = 7;
IEnumerable<string> multiplicationTableRow = Enumerable.Range(1, 10).Select(i => $"{number} x {i} = {number * i}");
foreach (string line in multiplicationTableRow)
{
    Console.WriteLine(line);
}

/*19. Generate even numbers between 1 and 30.*/
IEnumerable<int> evenNumbers = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
foreach (int even in evenNumbers)
{
    Console.WriteLine(even);
}

/*20. Concatenate the first 3 product names with the first 3
customer company names into a single sequence.*/

//IEnumerable<string> concatenatedNames = products.Select(p => p.Name).Take(3)
//    .Concat(customers.Select(c => c.CompanyName).Take(3));

//foreach (string name in concatenatedNames)
//{
//    Console.WriteLine(name);
//}

/*21. Pair each product with a customer (by position) and produce
a string "ProductName sold to CompanyName".*/

//IEnumerable<string> productCustomerPairs = products.Zip(customers, (p, c) => $"{p.Name} sold to {c.CompanyName}");
//foreach (string pair in productCustomerPairs)
//{
//    Console.WriteLine(pair);
//}   



