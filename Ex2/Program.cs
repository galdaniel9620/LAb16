using Ex1.Models;
using Ex2.Models;


//Seed();

internal class Program
{
    private static void Main(string[] args)
    {
        using var dbContext = new CarsDbContext();
        dbContext.SaveChanges();


        ShowAllCars(dbContext);
        Console.WriteLine();
        // int newCarId = AddCar(dbContext, "Focus", "abc123456", 2023, "Ford");
        //Console.WriteLine($"New car added with ID: {newCarId}");


        var fordCars = GetCarsByProducer(dbContext, "Ford");
        Console.WriteLine("\nFord Cars:");
        fordCars.ForEach(car => Console.WriteLine($"Name: {car.Name}, Producer: {car.Producer}, Series: {car.Series}, Year Of Manufacture: {car.YearOfManufacture}"));

        DeleteCar(19);

        static void Seed()
        {
            var dbContext = new CarsDbContext();

            dbContext.Add(new Car() { Name = "Sandero", Producer = "Dacia", Series = "wdv322323", YearOfManufacture = 2022 });
            dbContext.Add(new Car() { Name = "Model S", Producer = "Tesla", Series = "xyn657320", YearOfManufacture = 2021 });
            dbContext.Add(new Car() { Name = "Mustang", Producer = "Ford", Series = "mch987234", YearOfManufacture = 2019 });
            dbContext.Add(new Car() { Name = "Civic", Producer = "Honda", Series = "cvc454623", YearOfManufacture = 2020 });
            dbContext.Add(new Car() { Name = "Corolla", Producer = "Toyota", Series = "crl874322", YearOfManufacture = 2018 });
            dbContext.Add(new Car() { Name = "Impreza", Producer = "Subaru", Series = "ipr672239", YearOfManufacture = 2021 });
            dbContext.Add(new Car() { Name = "Charger", Producer = "Dodge", Series = "chg233465", YearOfManufacture = 2022 });
            dbContext.Add(new Car() { Name = "Accord", Producer = "Honda", Series = "acd764233", YearOfManufacture = 2019 });
            dbContext.Add(new Car() { Name = "Camry", Producer = "Toyota", Series = "cmr875321", YearOfManufacture = 2020 });
            dbContext.Add(new Car() { Name = "Fiesta", Producer = "Ford", Series = "fst124589", YearOfManufacture = 2018 });
            dbContext.Add(new Car() { Name = "Cayenne", Producer = "Porsche", Series = "cyn345672", YearOfManufacture = 2021 });
            dbContext.Add(new Car() { Name = "Cherokee", Producer = "Jeep", Series = "chk456781", YearOfManufacture = 2022 });
            dbContext.Add(new Car() { Name = "A4", Producer = "Audi", Series = "aud762134", YearOfManufacture = 2019 });
            dbContext.Add(new Car() { Name = "3 Series", Producer = "BMW", Series = "bmw342567", YearOfManufacture = 2020 });
            dbContext.Add(new Car() { Name = "Altima", Producer = "Nissan", Series = "nss234565", YearOfManufacture = 2021 });
            dbContext.Add(new Car() { Name = "CX-5", Producer = "Mazda", Series = "mzd874322", YearOfManufacture = 2018 });
            dbContext.Add(new Car() { Name = "Outback", Producer = "Subaru", Series = "obk675321", YearOfManufacture = 2022 });


            dbContext.SaveChanges();
        }

        static void ShowAllCars(CarsDbContext dbContext)
        {
            var cars = dbContext.Cars.OrderByDescending(car => car.YearOfManufacture).ToList();

            cars.ForEach(x => Console.WriteLine($"Year Of Manufacture: {x.YearOfManufacture}, Name: {x.Name}, Producer: {x.Producer}, Series: {x.Series}"));

        }

        static int AddCar(CarsDbContext dbContext, string name, string series, int yearOfManufacture, string producer)
        {
            var car = new Car
            {
                Name = name,
                Series = series,
                YearOfManufacture = yearOfManufacture,
                Producer = producer
            };

            dbContext.Add(car);
            dbContext.SaveChanges();

            return car.Id;
        }

        static List<Car> GetCarsByProducer(CarsDbContext dbContext, string producer)
        {
            return dbContext.Cars.Where(car => car.Producer == producer).ToList();
        }

        static void DeleteCar(int id)
        {
            using var dbContext = new CarsDbContext();

            var car = dbContext.Cars.Find(id);
            if (car != null)
            {
                dbContext.Cars.Remove(car);
                Console.WriteLine($"\nCar with ID: {id} has been deleted.");
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Car with ID: {id} not found.");
            }

        }
    }
}