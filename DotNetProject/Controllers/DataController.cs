using DotNetProject.Models;
using DotNetProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index(int pg =1)
        {
            List<DataModel> dataModels = new List<DataModel>();
            LuatDAO luatDAO = new LuatDAO();
            dataModels = luatDAO.FetchAll();
            const int pageSize = 10;
            if(pg < 1)
            {
                pg = 1;
            }
            int  recsCount  = dataModels.Count();
            Pager pagerIndex = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = dataModels.Skip(recSkip).Take(pageSize).ToList();
            ViewBag.PagerIndex = pagerIndex;
            ViewBag.Action = "Index";
            return View("Index", data);
        }
        public IActionResult Details(int id)
        {
            LuatDAO luatDAO = new LuatDAO();
            DataModel dataModel = new DataModel();
            dataModel = luatDAO.FetchOne(id);
            return View("Details", dataModel);
        }

        public IActionResult Create()
        {
            return View("CreateOrUpdate", new DataModel());
        }
        public IActionResult Edit(int id)
        {
            LuatDAO luatDAO = new LuatDAO();
            DataModel dataModel = new DataModel();
            dataModel = luatDAO.FetchOne(id);
            return View("CreateOrUpdate", dataModel);
        }
        public IActionResult ProcessCreate(DataModel dataModel)
        {
            LuatDAO luatDAO = new LuatDAO();
            luatDAO.CreateOrUpdate(dataModel);
            return View("Details", dataModel);
        }
        public IActionResult Delete(int id)
        {
            LuatDAO luatDAO=new LuatDAO();
            luatDAO.Delete(id);
            List<DataModel> dataModels = luatDAO.FetchAll();
            return View("Index", dataModels);
        }
        public IActionResult Search(string searchText)
        {
            LuatDAO luatDAO = new LuatDAO();
            List<DataModel> dataModels = luatDAO.Search(searchText);
            return View("Index", dataModels);
        }
        public IActionResult Filter(string chuong, int pg=1)
        {
            LuatDAO luatDAO = new LuatDAO();
            List<DataModel> dataModels = luatDAO.Filter(chuong);
            ViewBag.Parameter = chuong;
            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = dataModels.Count();
            Pager pagerFilter = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = dataModels.Skip(recSkip).Take(pageSize).ToList();
            ViewBag.PagerFilter = pagerFilter;
            ViewBag.Action = "Filter";
            ViewBag.Parameter = chuong;
            return View("Index", data);
        }
    }
}
