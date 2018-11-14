using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
