using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using JXTPortal.Data.Dapper.Factories;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTPortal.UnitTest1
{
    [TestFixture]
    public class KnowledgeBaseRepo_Tests
    {
        [Test]
        public void InsertTest()
        {
            //Arrange
            var connectionFactory = Substitute.For<IConnectionFactory>();
            var connectionStringName = Substitute.For<string>();
            var entity = Substitute.For<KnowledgeBaseEntity>();

            var knowledgeBaseRepo = new KnowledgeBaseRepository(connectionFactory, connectionStringName);

            //Act
            knowledgeBaseRepo.Insert(entity);

            //Assert
            knowledgeBaseRepo.Received();
        }
    }

    [TestFixture]
    public class KnowledgeBaseCaegoryRepo_Tests
    {

    }
}
