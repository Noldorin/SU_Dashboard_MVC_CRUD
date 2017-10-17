using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard_FrontEnd_Prototype.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The first prototype build of our Kenworth Dashboard";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Get in touch!";

            return View();
        }

        public ActionResult UserIndex()
        {
            var freshIndex = new Models.UserList();
            freshIndex.list = DataConfig.UserTable.ToList();

            return View(freshIndex);
        }

        public ActionResult CreateUser()
       {
            TempData["Message"] = "Please enter the name and roll of the new user";
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(string name, string role)
        {
            var newUser = new Dashboard_FrontEnd_Prototype.Models.UserModel();

            newUser.name = name;
            if (role == "Engineer")
            {
                newUser.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Engineer;
            }
            else
            {
                newUser.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Manager;
            }

            SaveNewUser(newUser.name, newUser.role.ToString());

            TempData["Message"] = "The user has been created! Review their information below.";

            return View("CreateUserPost", newUser);
        }

        public ActionResult UserSearch()
        {
            //TO-DO Complete User Search method and associated views (if any)
            ViewBag.Message = "Enter the Name of the user you are looking for";

            return View();
        }

        [HttpPost]
        public ActionResult UserSearch(string name, string role)
        {
            //TO-DO Complete User Search method and associated views (if any)
            var userSearch = new Dashboard_FrontEnd_Prototype.Models.UserModel();

            userSearch.name = name;

            var searchResult = SearchForUser(name);

            if (searchResult == null)
            {
                return View("UserSearchResult", null);
            }
            else
            {
                userSearch.name = searchResult.Name;
                if (searchResult.Role == "Engineer")
                {
                    userSearch.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Engineer;
                }
                else
                {
                    userSearch.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Manager;
                }

                return View("UserSearchResult", userSearch);
            }
        }

        [HttpPost]
        public ActionResult UpdateUser(string name, string role)
        {
            ViewBag.Message = "Please enter the new info for " + name;

            var updateUser = new Dashboard_FrontEnd_Prototype.Models.UserModel();

            updateUser.name = name;
            if (updateUser.name == "Engineer")
            {
                updateUser.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Engineer;
            }
            else
            {
                updateUser.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Manager;
            }
            return View(updateUser);
        }

        [HttpPost]
        public ActionResult UpdateUserFromIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserConfirm(string name, string newRole)
        {
            DeleteUserRow(name);
            SaveNewUser(name, newRole);
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(string name, string role)
        {
            var delUser = new Dashboard_FrontEnd_Prototype.Models.UserModel();

            delUser.name = name;
            if (delUser.name == "Engineer")
            {
                delUser.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Engineer;
            }
            else
            {
                delUser.role = Dashboard_FrontEnd_Prototype.Models.UserModel.Roles.Manager;
            }
            return View(delUser);
        }

        [HttpPost]
        public ActionResult DeleteUserFromIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUserConfirm(string name)
        {
            DeleteUserRow(name);
            return View("DeleteUserConfirm");
        }

        [HttpPost]
        public ActionResult ConfirmDeleteFromIndex()
        { 
            DeleteUserRow(Request.Form["nameFromIndex"]);
            return View("DeleteUserConfirm");
        }

    private void DeleteUserRow(string name)
        {
            DataConfig.UserTable.RemoveUserRow(DataConfig.UserTable.FindByName(name));
            DataConfig.UserTable.AcceptChanges();
        }

        private void SaveNewUser(string name, string role)
        {
            DataConfig.UserTable.AddUserRow(name, role);
            DataConfig.UserTable.AcceptChanges();
        }

        private DashboardDataStore.UserRow SearchForUser(string name)
        {
            return DataConfig.UserTable.FindByName(name);    
        }


    }

   
}