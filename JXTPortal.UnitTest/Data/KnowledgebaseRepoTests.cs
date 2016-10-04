using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Factories;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;

namespace JXTPortal.UnitTest
{
    [TestFixture]
    public class KnowledgeBaseRepo_Tests
    {
        private IConnectionFactory ConnectionFactory;
        private string ConnectionStringName;
        private KnowledgeBaseEntity Entity;

        [SetUp]
        public void Setup()
        {
            ConnectionFactory = Substitute.For<IConnectionFactory>();
            Entity = Substitute.For<KnowledgeBaseEntity>();
            ConnectionStringName =  Substitute.For<string>();
        }

        [Test]
        public void InsertTest()
        {
            //Arrange
            var knowledgeBaseRepo = new KnowledgeBaseRepository(ConnectionFactory, ConnectionStringName);
            
            //Act
            knowledgeBaseRepo.Insert(Entity);
            
            //Assert
            knowledgeBaseRepo.Received();
        }

        [Test]
        public void UpdateTest()
        {
            //Arrange
            var knowledgeBaseRepo = new KnowledgeBaseRepository(ConnectionFactory, ConnectionStringName);

            //Act
            knowledgeBaseRepo.Update(Entity);

            //Assert
            knowledgeBaseRepo.Received();
        }

        [Test]
        public void DeleteTest()
        {
            //Arrange
            var knowledgeBaseRepo = new KnowledgeBaseRepository(ConnectionFactory, ConnectionStringName);

            //Act
            knowledgeBaseRepo.Delete(1);

            //Assert
            knowledgeBaseRepo.Received();
        }

        [Test]
        public void SelectAllTest()
        {
            //Arrange
            var knowledgeBaseRepo = new KnowledgeBaseRepository(ConnectionFactory, ConnectionStringName);

            //Act
            knowledgeBaseRepo.SelectAll();

            //Assert
            knowledgeBaseRepo.Received();
        }

        [Test]
        public void SelectTest()
        {
            //Arrange
            var knowledgeBaseRepo = new KnowledgeBaseRepository(ConnectionFactory, ConnectionStringName);

            //Act
            knowledgeBaseRepo.Select(1);

            //Assert
            knowledgeBaseRepo.Received();
        }
    }

    [TestFixture]
    public class KnowledgeBaseCategoryRepo_Tests
    {
        private IConnectionFactory ConnectionFactory;
        private string ConnectionStringName;
        private KnowledgeBaseCategoryEntity Entity;
        private IKnowledgeBaseCategoryRepository knowledgeBaseCategoryRepo;
        [SetUp]
        public void Setup()
        {
            ConnectionFactory = Substitute.For<IConnectionFactory>();
            Entity = Substitute.For<KnowledgeBaseCategoryEntity>();
            ConnectionStringName = Substitute.For<string>();
            knowledgeBaseCategoryRepo = new KnowledgeBaseCategoryRepository(ConnectionFactory, ConnectionStringName);
        }

        [Test]
        public void InsertTest()
        {
            //Act
            knowledgeBaseCategoryRepo.Insert(Entity);

            //Assert
            knowledgeBaseCategoryRepo.Received(1).Insert(Arg.Is<KnowledgeBaseCategoryEntity>(Entity));
        }

        [Test]
        public void UpdateTest()
        {
            //Act
            knowledgeBaseCategoryRepo.Update(Entity);

            //Assert
            knowledgeBaseCategoryRepo.Received(1).Update(Arg.Is<KnowledgeBaseCategoryEntity>(Entity));
        }

        [Test]
        public void DeleteTest()
        {
            //Act
            knowledgeBaseCategoryRepo.Delete(1);

            //Assert
            knowledgeBaseCategoryRepo.Received(Arg.Is<int>(1));
        }

        [Test]
        public void SelectAllTest()
        {
            //Act
            knowledgeBaseCategoryRepo.SelectAll();

            //Assert
            knowledgeBaseCategoryRepo.Received(1).SelectAll();
        }

        [Test]
        public void SelectTest()
        {
            //Act
            knowledgeBaseCategoryRepo.Select(1);

            //Assert
            knowledgeBaseCategoryRepo.Received(1).Select(Arg.Is<int>(1));
        }

        [Test]
        public void GetCategoryByParentCategoryIdTest()
        {
            //Act
            knowledgeBaseCategoryRepo.GetCategoryByParentCategoryId(1);

            //Assert
            knowledgeBaseCategoryRepo.Received(1).GetCategoryByParentCategoryId(Arg.Is<int>(1));
        }
    }
}
