using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Sentiment_Analytics_Courses.Models;
using Sentiment_Analytics_CoursesML.Model;

namespace Sentiment_Analytics_Courses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Context_ db = new Context_();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Analytics
        [HttpGet]
        public IActionResult Analysis()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Analysis(ModelInput input)
        {
            // Load the model  
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(@"T:\AI\Sentiment-Analytics-Courses\Sentiment-Analytics-CoursesML.Model\MLModel.zip", out var modelInputSchema);
            // Create predection engine related to the loaded train model
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            //Input  
            //input.Year = DateTime.Now.Year;
            // Try model on sample data and find the score
            ModelOutput result = predEngine.Predict(input);
            // Store result into ViewBag
            ViewBag.Result = result;

            // 1- tích cực
            // 2- trung tính
            // 3- tiêu cực
            // 4- rất tiêu cực
            // 5- hạnh phúc
            // 6- phẫn nộ
            //List<ModelInput> model = new List<ModelInput>();
            string[] name = new string[] { "Tích Cực", "Trung Tính", "Tiêu Cực", "Rất Tiêu Cực", "Hạnh Phúc", "Phẫn Nộ" };
            string[] theme = new string[] { "alert-success", "alert-warning", "alert-secondary", "alert-dark", "alert-info", "alert-danger" };
            int i = 0;
            List<ModelInput> model=new List<ModelInput>();
            ModelInput model_ = new ModelInput();

            double sum = 0;
            foreach (var s in result.Score)
            {
                sum += s;
            }
            foreach (var s in result.Score)
            {
                model_ = new ModelInput
                {
                    Sentiment = name[i],
                    Point = Math.Round(s, 2),
                    Percent = (Math.Round(Math.Round(s, 2) * 100 / sum, 2)).ToString(),
                    Theme = theme[i]
                };

                model.Add(model_);
                i++;
            }
            //model.AddRange(obj1);

            ViewBag.Context = input.SentimentText;
            ViewBag.Result = result.Prediction;
            return View(model);
        }
        #endregion

        [HttpPost]
        public IActionResult Deleted(IEnumerable<string> checkbox)
        {
            int? status = null;
            string result = result = db.delete_sentiment(checkbox);
            if (result == "error")
            {
                //Response.StatusCode = 500;
                status = -1;
                return RedirectToAction("Data", new { status = status });
            }
            else if (result == "success")
            {
                status = 1;
                return RedirectToAction("Data", new { status = status });
            }

            return RedirectToAction("Data", new { status = status });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert_Data(Sentiment ss)
        {
            int? status = null;
            if (ss.sentimentText!=null)
            {
                Sentiment emp = new Sentiment();
                var result = db.create_sentiment(ss);
                
                if (result == "error")
                {
                    Response.StatusCode = 500;
                    status = -1;
                    return NotFound();
                }
                else if (result == "exist")
                {
                    status = 0;
                    ModelState.AddModelError("", "Dữ liệu đã tồn tại"); //-sumary
                    return RedirectToAction("Data", new { status = status, s = ss });
                }
                else if(result=="success")
                {
                    status = 1;
                    return RedirectToAction("Data", new { status = status });
                }
            }
            return RedirectToAction("Data", new { status = status,s=ss });
        }

        public IActionResult Data(int? status,Sentiment s)
        {
            if (status != null)
            {
                if (status == 1)
                {
                    ViewBag.alert = "alert-success";
                    ViewBag.message = "Xử lý dữ liệu thành công";
                }
                else if (status == -1)
                {
                    ViewBag.alert = "alert-danger";
                    ViewBag.message = "Xử lý dữ liệu thất bại";
                }
                else if (status == 0)
                {
                    ViewBag.alert = "alert-danger";
                    ViewBag.message = "Dữ liệu đã tồn tại";
                }
            }
            Sentiment emp = new Sentiment();
            DataSet ds = db.get_sentiment();
            List<Sentiment> list = new List<Sentiment>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Sentiment
                {
                    sentiment = dr["Sentiment"].ToString(),
                    sentimentText = dr["SentimentText"].ToString()
                });
            }
            ViewBag.list = list;

            if (status == null)
            {
                return View(s);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
