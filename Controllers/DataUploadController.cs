using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using BlueMoonAdmin.Models;
using System.Data;
using System.Data.OleDb;
using BlueMoonAdmin.Models.ViewModels;
using System.Collections;
using BlueMoonAdmin.Data;
using System.Globalization;

namespace BlueMoonAdmin.Controllers
{
    public class DataUploadController : Controller
    {
        #region Database Connection
        private readonly ApplicationDbContext _db;

        public DataUploadController(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion
        #region Views
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Sales()
        {
            return View();
        }
        public IActionResult UploadSuccess()
        {
            return View();
        }
        public IActionResult Nothing()
        {
            return View();
        }
        #endregion
        #region Open & Read CSV File 
        [HttpPost]
        public IActionResult Customer(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                // Need to check if its customer data being uploaded.  Maybe by checking for a certain column name
                if (postedFile.FileName.EndsWith(".csv"))
                {
                    UploadViewModel uploadCust = new UploadViewModel();
                    
                   using (StreamReader sreader = new(postedFile.OpenReadStream()))
                    {
                        string[] headers = sreader.ReadLine().Split(',');     //Title
                         uploadCust.CustomersList = new List<Customers>();
                        // providing the column names remain the same, this will account for the column order changing
                        // searches for the column name and returns the column index (location)
                        #region Get the column index (int) based on name
                        int companyNameInt = Array.FindIndex(headers, x => x.Equals("CompanyName"));
                        int contactInt = Array.FindIndex(headers, x => x.Equals("ContactName"));                        
                        int officeInt = Array.FindIndex(headers, x => x.Equals("OfficeAddress"));
                        int telInt = Array.FindIndex(headers, x => x.Equals("TelephoneNumber"));
                        int webInt = Array.FindIndex(headers, x => x.Equals("Website"));
                        int sinceInt = Array.FindIndex(headers, x => x.Equals("CustomerSince"));
                        int addLineInt = Array.FindIndex(headers, x => x.Equals("AddressLine"));
                        int regionInt = Array.FindIndex(headers, x => x.Equals("CityRegion"));
                        int emailInt = Array.FindIndex(headers, x => x.Equals("EmailAddress"));
                        int postcodeInt = Array.FindIndex(headers, x => x.Equals("PostCode"));
                        int mobileInt = Array.FindIndex(headers, x => x.Equals("MobileNumber"));
                        int VatInt = Array.FindIndex(headers, x => x.Equals("Vat"));
                        #endregion
                        //Gets the contact of every row
                        while (!sreader.EndOfStream)                          
                        {                           
                            string[] rows = sreader.ReadLine().Split(',');
                            DateTime dateTime;
                            DateTime.TryParse(rows[sinceInt], out dateTime);
                            uploadCust.CustomersList.Add ( 
                                        new  Customers() 
                                            {   
                                                CompanyName = rows[companyNameInt],
                                                ContactName = rows[contactInt], 
                                                OfficeAddress = rows[officeInt],
                                                TelephoneNumber = rows[telInt],
                                                Website = rows[webInt],                                       
                                                CustomerSince = dateTime,
                                                AddressLine = rows[addLineInt],
                                                CityRegion = rows[regionInt],                                             
                                                EmailAddress = rows[emailInt],
                                                PostCode = rows[postcodeInt],
                                                MobileNumber = rows[mobileInt],
                                                Vat = rows[VatInt]
                                            }
                                        );           
                        }
                    }                    
                    return View(uploadCust);
                }
                // Need to display a message saying CSV has not been seected
                return View("Customer");
            }
            return View("Customer");
        }


        [HttpPost]
        public IActionResult Sales(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                // Need to check if its sales data being uploaded.  Maybe by checking for a certain column name
                if (postedFile.FileName.EndsWith(".csv"))
                {
                    UploadViewModel uploadCust = new UploadViewModel();

                    using (StreamReader sreader = new(postedFile.OpenReadStream()))
                    {
                        string[] headers = sreader.ReadLine().Split(',');     //Title
                        uploadCust.CustomersList = new List<Customers>();
                        uploadCust.SalesList = new List<MonthlySales>();
                        // providing the column names remain the same, this will account for the column order changing
                        // searches for the column name and returns the column index (location)
                        #region Get the column index (int) based on name
                        int contactInt = Array.FindIndex(headers, x => x.Equals("Contact"));
                        int dateInt = Array.FindIndex(headers, x => x.Equals("Date"));

                        int dueInt = Array.FindIndex(headers, x => x.Equals("Due Date"));
                            
                        int amountInt = Array.FindIndex(headers, x => x.Equals("Amount"));
                        #endregion
                        //Gets the contact of every row
                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(',');
                            decimal Amount;
                            decimal.TryParse(rows[amountInt], out Amount);
                            DateTime date;
                            // Check if date is in UK format
                            if (DateTime.TryParseExact(rows[dateInt],"dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None,out date))
                                {
                                // convert date to standard DateTime
                                date = DateTime.ParseExact(rows[dateInt], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                 }
                            else
                                {
                                // accepts YYYY-MM-DD format
                                DateTime.TryParse(rows[dateInt], out date);
                                }
                            date = date.AddDays(-date.Day+1);
                            uploadCust.SalesList.Add(
                                        new MonthlySales()
                                        {
                                            Date = date,
                                            Amount = Amount,
                                        }
                                        );
                            uploadCust.CustomersList.Add(
                                new Customers()
                                {
                                    CompanyName = rows[contactInt],
                                    Amount = Amount,                                    
                                });
                            //Groups month and total 
                           uploadCust.SalesList = uploadCust.SalesList.GroupBy(c => c.Date).Select(a => new MonthlySales { Date = a.Key, Amount = a.Sum(q => q.Amount) }).ToList();
                            // Groups company name and total
                            uploadCust.CustomersList = uploadCust.CustomersList.GroupBy(c => c.CompanyName).Select(a => new Customers { CompanyName = a.Key, Amount = a.Sum(q => q.Amount) }).ToList();
                        }
                    }          
                    return View(uploadCust);
                }
                // Need to display a message saying CSV has not been seected
                return View("Customer");
            }
            return View("Customer");
        }

        #endregion
        #region HTTP Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCustomer(UploadViewModel listofcustomers)
        {
            int? CustomerUploaded = listofcustomers.CustomersList.ToList().Count();
            foreach (var customer in listofcustomers.CustomersList)
            {
                _db.Customers.Add(customer);
            }
            string message;
            await _db.SaveChangesAsync();
            if(CustomerUploaded == null)
            {
                // Loads page "Nothing" in data folder.
                return View("Nothing");
            }
            if (CustomerUploaded == 1)
            {
                message = "1 customer uploaded";
            }
            else 
            {
                 message = CustomerUploaded.ToString() + " customers uploaded";
            }      
            // Displays page saving it has been successful and reporting how many customers have been uploaded
            return View("UploadSuccess", message);
        }



        public async Task<IActionResult> UpdateSales(UploadViewModel SalesData)
        {
            string message = null;
            //  int? CustomerUploaded = listofcustomers.CustomersList.ToList().Count();
            foreach (var month in SalesData.SalesList)
            {
                if(_db.MonthlySalesFigure.Where(c => c.Date == month.Date).Count() == 0)
                {
                    _db.MonthlySalesFigure.Add(month);
                    var tempDate = month.Date.Month + "/" + month.Date.Year;
                    if (message == null)
                    {
                        message = string.Format("Sales data for {0} has been uploaded", tempDate);
                    }
                    else
                    {

                        message = message += string.Format(Environment.NewLine + "Sales data for {0} has been uploaded", tempDate);
                    }

                }
                else
                {
                    var tempDate = month.Date.Month + "/" + month.Date.Year;
                    if (message == null)
                    {
                        message = string.Format("Sales data for {0} has already been uploaded", tempDate);
                    }
                    else
                    {                      

                        message = message += string.Format(Environment.NewLine + "Sales data for {0} has already been uploaded", tempDate);
                    }
                }
            }
            
            await _db.SaveChangesAsync();
           if(message == null)
            {
                message = "OK";
            }
           
            // Displays page saving it has been successful and reporting how many customers have been uploaded
            return View("UploadSuccess", message);
        }
        #endregion
    }
    }

