using ProductManagement.Repository;
using ProductManagement.Service;
using System;
using System.Windows.Forms;

namespace ProductManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Keep your existing initialization
            ApplicationConfiguration.Initialize();

            // 1) Create the in-memory repository
            var repo = new InMemoryProductRepository();

            // 2) Wrap it in your service
            var service = new ProductService(repo);

            // 3) Pass that service into your main form
            Application.Run(new Form1(service));
        }
    }
}
