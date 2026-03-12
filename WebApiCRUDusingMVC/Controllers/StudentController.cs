using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApiCRUDusingMVC.Models;    

namespace WebApiCRUDusingMVC.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7205/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(result);
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(result);

                if (data != null)
                {
                    students = data;
                }
            }

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student stud)
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(stud);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Student created successfully.";
                return RedirectToAction("Index");
            }

            return View(stud);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = await client.GetAsync(url + id);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student stud)
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(stud);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url + stud.StudentId, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["UpdateMessage"] = "Student Updated successfully.";
                return RedirectToAction("Index");
            }

            return View(stud);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = await client.GetAsync(url + id);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = await client.GetAsync(url + id);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
        
            HttpResponseMessage response = await client.DeleteAsync(url + id);
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteMessage"] = "Student Deleted successfully.";
                return RedirectToAction("Index");
            }
            
            return View();
        }


    }
}
