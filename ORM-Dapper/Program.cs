using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            // var departmentRepo = new DapperDepartmentRepository(conn);
            // departmentRepo.InsertDepartment("My new department");
            // var departments = departmentRepo.GetAllDepartments();
            // foreach (var department in departments)
            // {
            //     Console.WriteLine($"name: {department.Name} | Id {department.DepartmentID}");
            //     
            // }
            
            var prodRepo = new DapperProductRepository(conn);
            //prodRepo.CreateProduct(" my Tv ", 500.00, 10, true, 5);
            //prodRepo.UpdateProduct("my Tv", 1000.00, 10, false, 2, 940);
            prodRepo.DeleteProduct(940);
            
            var products = prodRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId} : {product.Name} : ${product.Price}");
            }
            
        }
    }
}
