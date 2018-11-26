using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using PredictiveApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PredictiveApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult HealthGoPredict()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Predict()
        {
            return View();
        }


        public ActionResult Predict1()
        {
            //HealthCostPredict("a", "b");

            return View();
        }

        public ActionResult Predict2()
        {
            string parameter = "ok"; int serviceid=0;
                var engine = Python.CreateEngine();
                var scope = engine.CreateScope(); 
                var d = new Dictionary<string, object>
            {
                { "x", 2},
                { "y", 4}
            }; 
       
                scope.SetVariable("params", d); 
                ScriptSource source = engine.CreateScriptSourceFromFile("C:\\Research\\machine learning images\\hellopython.py"); // Load the script
                object result = source.Execute(scope);
                parameter = scope.GetVariable<string>("parameter"); 
               
            
            return View();
        }


        [HttpGet]
        public ActionResult GetResult(string num1,string num2)
        {

            string parameter = "ok"; int serviceid = 0;
            var engine1 = Python.CreateEngine(); // Extract Python language engine from their grasp
            var scope = engine1.CreateScope(); // Introduce Python namespace (scope)
            var d = new Dictionary<string, object>
            {
                { "x", 2},
                { "y", 4}
            };

            //workingfn
            var engine = Python.CreateEngine();
            dynamic py = engine.ExecuteFile(@"C:\Work\calculator.py");
            CalcModel objCalcModel = new CalcModel();

           
            dynamic calc = py.Calculator();
            string cl = calc.__class__.__name__;
            Console.WriteLine(calc.__class__.__name__);

            double a = Convert.ToDouble(num1);
            double b = Convert.ToDouble(num2);
            double res;
            res = calc.add(a, b);
            string add = res.ToString();
            objCalcModel.add = add;
            res = calc.sub(a, b);
            string sub = res.ToString();
            objCalcModel.sub = sub;
            
            return Json(objCalcModel, JsonRequestBehavior.AllowGet);

        }


        //[HttpGet]
        //public ActionResult ActualFun(string num1, string num2)
        //{
        //    var engine = Python.CreateEngine();
        //    dynamic py = engine.ExecuteFile(@"C:\Work\calculator.py");
        //    CalcModel objCalcModel = new CalcModel();


        //    dynamic calc = py.Calculator();
        //    string cl = calc.__class__.__name__;
        //    Console.WriteLine(calc.__class__.__name__);

        //    double a = Convert.ToDouble(num1);
        //    double b = Convert.ToDouble(num2);
        //    double res;
        //    res = calc.add(a, b);
        //    string add = res.ToString();
        //    objCalcModel.add = add;
        //    res = calc.sub(a, b);
        //    string sub = res.ToString();
        //    objCalcModel.sub = add;

        //    return Json(objCalcModel, JsonRequestBehavior.AllowGet);

        //}



        [HttpGet]
        public ActionResult HealthCostPredict()
        {
            string num1 = "a"; string num2 = "b";
            var engine = Python.CreateEngine();

            var scope = engine.CreateScope();
            var libs = new[] {
    //"C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\Extensions\\Microsoft\\Python Tools for Visual Studio\\2.2",
   "C:\\Users\\rruhela1\\AppData\\Local\\Programs\\Python\\Python37\\Lib\\site-packages",
    "C:\\Users\\rruhela1\\AppData\\Local\\Programs\\Python\\Python37\\Lib\\site-packages\\pandas",
    "C:\\Users\\rruhela1\\AppData\\Local\\Programs\\Python\\Python37\\Lib\\site-packages\\numpy",
  
};

            engine.SetSearchPaths(libs);
            //engine.ExecuteFile("Test.py", scope);

            dynamic py = engine.ExecuteFile(@"C:\Users\rruhela1\AppData\Local\Programs\Python\Python37\test2.py", scope);
            py.ExecuteFile(@"C:\\Users\\rruhela1\\AppData\\Local\\Programs\\Python\\Python37\\test2.py");
            CalcModel objCalcModel = new CalcModel();            
            dynamic calc = py.Healthcare_Cost_Predictor_02();
            string cl = calc.__class__.__name__;
            //Console.WriteLine(calc.__class__.__name__);

            double a = Convert.ToDouble(num1);
            double b = Convert.ToDouble(num2);
            string res;
            res = calc.calc_insurance(40,40,1);
            string add = res.ToString();
            objCalcModel.add = res;
           

            return Json(objCalcModel, JsonRequestBehavior.AllowGet);

        }














    }
}
