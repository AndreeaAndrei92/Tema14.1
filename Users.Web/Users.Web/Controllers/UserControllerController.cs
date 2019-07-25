using System.Linq;
using System.Web.Mvc;
using Users.BusinessLogic;
using Users.Data;

namespace Users.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController()
        {
            _repo = new UserRepository(ConnectionManager.GetConnection());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allUsers = _repo.GetAll();
            var userListModels = allUsers.Select(x => new UserListViewModel
            {
                Id = x.Id,
                Email = x.Email,
                UserName = x.Username
            }).ToList();

            return View(userListModels);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", user);
            }

            if (user.Id != null && user.Id != 0)
            {
                var existingUser = Users.Find(x => x.Id == user.Id);
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
            }
            else
            {
                user.Id = Users.Count + 1;
                Users.Add(user);
            }

            return RedirectToAction("Index");
        }
    }
}