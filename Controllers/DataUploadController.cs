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

namespace BlueMoonAdmin.Controllers
{
    public class DataUploadController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DataUploadController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        
        List<Customers> myList = new List<Customers>();

        [HttpPost]

        public IActionResult Customer(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                if (postedFile.FileName.EndsWith(".csv"))
                {
                    UploadViewModel uploadCust = new UploadViewModel();
                    
                    using (var sreader = new StreamReader(postedFile.OpenReadStream()))
                    {
                        string[] headers = sreader.ReadLine().Split(',');     //Title
                         uploadCust.CustomersList = new List<Customers>();
                        // providing the column names remain the same, this will account for the column order changing
                        // searches for the column name and returns the column index (location)
                        #region col int based on name
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

                        while (!sreader.EndOfStream)                          //get all the content in rows 
                        {

                           
                            string[] rows = sreader.ReadLine().Split(',');
                            DateTime dateTime;
                            DateTime.TryParse(rows[sinceInt], out dateTime);
                            uploadCust.CustomersList.Add  (
                                        new Customers() 
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


            }
            return View("Customer");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(UploadViewModel listofcustomers)
        {
            int? CustomerUploaded = listofcustomers.CustomersList.ToList().Count();
            foreach (var customer in listofcustomers.CustomersList)
            {
                _db.Customers.Add(customer);
            }
            string message;
            _db.SaveChanges();
            if(CustomerUploaded == null)
            {
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
            return View("UploadSuccess", message);
        }

        public IActionResult UploadSuccess()
        {
            return View();
        }
        public IActionResult Nothing()
        {
            return View();
        }
        public IActionResult SampleFile()
        {
 
    return View();
        }
    }
    }

