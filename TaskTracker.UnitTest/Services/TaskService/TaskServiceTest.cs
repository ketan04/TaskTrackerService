using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Services;
using TaskTracker.Models.Dto.Task;
using TaskTracker.Test.MockData;

namespace TaskTracker.Test.Services.TaskService
{
    [TestFixture]
    public class TaskServiceTest
    {
        private Mock<IQueryHandler<List<GetTaskListResponse>>> queryHandler;

        private Mock<ICommandHandler<CreateTaskRequest>> commandHandler;

        private ITaskService taskService;

        private List<GetTaskListResponse> getTaskListResponses;

        [SetUp]
        public void SetUp()
        {
            this.queryHandler = new Mock<IQueryHandler<List<GetTaskListResponse>>>();
            this.commandHandler = new Mock<ICommandHandler<CreateTaskRequest>>();
            //need to correct the namespace and class name
            this.taskService = new TaskTracker.Services.TaskService.TaskService();
            this.getTaskListResponses = new GetTaskListResponseMock().GetTaskListResponse();
        }

        [Test]
        public void GetTaskListTest_Invokes_GetTaskListQuery_Returns_GetTaskListResponse()
        {
            // -Arrange
            this.queryHandler.Setup(i => i.ExecuteAsync()).Returns(Task.FromResult(this.getTaskListResponses));

            //Act
            List <GetTaskListResponse> result =  this.taskService.GetTaskList(this.queryHandler.Object)?.Result;

            //Assert
            Assert.That (this.getTaskListResponses.FirstOrDefault().Equals(result.FirstOrDefault()));
        }
    }
}
