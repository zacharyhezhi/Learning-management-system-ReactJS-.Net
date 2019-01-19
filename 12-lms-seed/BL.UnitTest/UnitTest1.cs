using BL.Managers;
using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Model;
using NSubstitute;
using System;
using Xunit;

namespace BL.UnitTest
{
    public class HashTest
    {
        [Fact]
        public void CanHash()
        {
            var password = "Password123";
            var hashPassword = Util.HashHelper.GetMD5HashData(password);
            var expectedResult = "3244185981728979115075721453575112";
            Assert.Equal(expectedResult, hashPassword);
        }

        [Theory]
        [InlineData("123", "3244185981728979115075721453575112")]
        [InlineData("456", "37122481812811963631412001801901341221542")]
        [InlineData("789", "1045582421466203276601671981632112247")]
        public void CanHashMultiple(string password, string expectedResult)
        {
            var hashPassword = Util.HashHelper.GetMD5HashData(password);
            Assert.Equal(expectedResult, hashPassword);
        }

        [Fact]
        public void CanSave()
        {
            var userRepo  = Substitute.For<IUserRepository>();
            userRepo.GetById(1).Returns(new User
            {
                Id = 1,
                FirstName = "William",
                LastName = "Liu"
            });
            var mockResult = userRepo.GetById(1);
            
            Assert.Equal("William", mockResult.FirstName);
        }

        [Fact]
        public void CanEnroleStudent()
        {
            var studentRepo = Substitute.For<IStudentReporsitory>();
            var student = new Student
            {
                Id = 1,
                Credit = 40
            };
            studentRepo.GetById(1).Returns(student);
            var studentManager = new StudentManager(studentRepo);
            studentManager.EnroleCourse(1, 1);

            Assert.Equal(36, student.Credit);
        }
    }
}
