using AttachingITToDo.Application.VideModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachingITToDo.WebAPI.Tests
{
    [TestClass]
    public class ToDoDataControllerTests : TestServerFixture
    {
        [TestMethod]
        public async Task Test_ToDoDataController_GetAllToDoItems_Is_Ok()
        {
            var response = await Client.GetAsync("api/ToDoData/GetAllToDoItems");

            response.EnsureSuccessStatusCode();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Test_ToDoDataController_GetAllToDos_Returns_Hotel()
        {
            var response = await Client.GetAsync("api/ToDoData/GetAllToDoItems");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var toDos = JsonConvert.DeserializeObject<IEnumerable<ToDoViewModel>>(result);

            Assert.IsTrue(toDos.Count() != 0);
        }
    }
}