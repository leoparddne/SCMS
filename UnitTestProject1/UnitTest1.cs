using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClubBLL bll = new ClubBLL();
            var model=bll.GetModel(p=>p.id==1);

            JsonSerializer serializer = new JsonSerializer();
            Console.WriteLine(JsonConvert.SerializeObject(model));

        }
        [TestMethod]
        public void add()
        {
            ClubBLL bll = new ClubBLL();
            var model = new Model.club();
            model.date = DateTime.Now;
            model.logo = "d";
            model.name = "d";
            model.state = 1;
            bll.Add(model);
            JsonSerializer serializer = new JsonSerializer();
            Console.WriteLine(JsonConvert.SerializeObject(model));

        }
        [TestMethod]
        public void delete()
        {
            ClubBLL bll = new ClubBLL();
            var model = bll.GetModel(p => p.id == 1);
            bll.Delete(model, true);
            JsonSerializer serializer = new JsonSerializer();
            Console.WriteLine(JsonConvert.SerializeObject(model));

        }
        [TestMethod]
        public void update()
        {
            ClubBLL bll = new ClubBLL();
            var model = new Model.club();
            model.id = 2;
            model.name = "123321";
            model.logo = "123321";
            bll.Update(model, new []{ "id","name","logo"});
            JsonSerializer serializer = new JsonSerializer();
            Console.WriteLine(JsonConvert.SerializeObject(model));

        }
    }
}
