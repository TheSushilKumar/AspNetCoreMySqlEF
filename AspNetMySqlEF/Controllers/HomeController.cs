using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using AspNetMySqlEF.Models;
using AspNetMySqlEF.Data;

namespace AspNetMySqlEF.Controllers
{
    public class HomeController : Controller
    {
        private MySQLDatabaseContext _context;

        public HomeController(MySQLDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {          
            var result = _context.Student.ToList();                
            return View(result);            
        }

        public List<MultipleTablesJoinedData> GetDataByRunningStoredProcedureOrDirectSqlQuery()
        {
            _context.Database.SetCommandTimeout(280);
            var result = _context.Student.ToList();
            return _context.MultipleTablesJoinedData.FromSql("Complex Query").ToList();           

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public static class StringExtensions
    {
        public static string TrimLastSepratorString(this string s, char seprator)
        {
            if (s == null)
                return null;

            string newString = string.Empty;

            string[] arrOrigionalString = s.Split(seprator);

            for (int i = 0; i < arrOrigionalString.Length - 1; i++)
            {
                if (string.IsNullOrEmpty(newString))
                    newString = arrOrigionalString[i];
                else
                    newString = string.Concat(newString, "_", arrOrigionalString[i]);

            }
            return newString;
        }
    }
}
