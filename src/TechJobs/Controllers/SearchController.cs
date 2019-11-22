using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm = "")
        {
            //Create a list to store queried results to be returned
            List<Dictionary<string, string>> searchResults;

            if (searchType.Equals("all"))
                {
                //Use FindByValue passing searchTerm and store the values in the list
                searchResults = JobData.FindByValue(searchTerm);
                
            }

            else
            {
                //Use the searchTerm and searchType and use the FindByColumnAndValue mehod and save that to the list
                searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                
            }
            //set the value of ViewBag.columns property to the columnChoices of the ListController class, 
            //then set the Viewing jobs property to the list, 
            //then return the index view
            ViewBag.columns = ListController.columnChoices;
            ViewBag.jobs = searchResults;
            return View("Index");


        }

    }
}
