using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Service.Dapper;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;

namespace JXTPortal.UnitTest
{    
    [TestFixture]
    public class KnowledgeBaseService_Tests
    {
        private IKnowledgeBaseRepository KnowledgebaseRepo;
        private KnowledgeBaseEntity Entity;

        [SetUp]
        public void Setup()
        {
            KnowledgebaseRepo = Substitute.For<IKnowledgeBaseRepository>();
            Entity = Substitute.For<KnowledgeBaseEntity>();
        }

        [Test]
        public void InsertTest()
        {
            //Arrange            
            var knowledgeBaseService = new KnowledgeBaseService(KnowledgebaseRepo);

            //Act
            knowledgeBaseService.Insert(Entity);

            //Assert
            knowledgeBaseService.Received();
        }

        [Test]
        public void UpdateTest()
        {
            //Arrange            
            var knowledgeBaseService = new KnowledgeBaseService(KnowledgebaseRepo);

            //Act
            knowledgeBaseService.Update(Entity);

            //Assert
            knowledgeBaseService.Received();
        }

        [Test]
        public void DeleteTest()
        {
            //Arrange
            var knowledgeBaseService = new KnowledgeBaseService(KnowledgebaseRepo);

            //Act
            knowledgeBaseService.Delete(1);

            //Assert
            knowledgeBaseService.Received();
        }

        [Test]
        public void SelectTest()
        {
            //Arrange
            var knowledgeBaseService = new KnowledgeBaseService(KnowledgebaseRepo);

            //Act
            knowledgeBaseService.Select(1);

            //Assert
            knowledgeBaseService.Received();
        }

        [Test]
        public void SelectAllTest()
        {
            //Arrange
            var knowledgeBaseService = new KnowledgeBaseService(KnowledgebaseRepo);

            //Act
            knowledgeBaseService.SelectAll();

            //Assert
            knowledgeBaseService.Received();
        }
    }

    [TestFixture]
    public class KnowledgeBaseCategoryService_Tests
    {
        private IKnowledgeBaseCategoryRepository KnowledgebaseCategoryRepo;
        private KnowledgeBaseCategoryEntity Entity;

        [SetUp]
        public void Setup()
        {
            KnowledgebaseCategoryRepo = Substitute.For<IKnowledgeBaseCategoryRepository>();
            Entity = Substitute.For<KnowledgeBaseCategoryEntity>();
        }

        [Test]
        public void InsertTest()
        {
            //Arrange            
            var knowledgeBaseCategoryService = new KnowledgeBaseCategoryService(KnowledgebaseCategoryRepo);

            //Act
            knowledgeBaseCategoryService.Insert(Entity);

            //Assert
            knowledgeBaseCategoryService.Received();
        }

        [Test]
        public void UpdateTest()
        {
            //Arrange
            var knowledgeBaseCategoryService = new KnowledgeBaseCategoryService(KnowledgebaseCategoryRepo);

            //Act
            knowledgeBaseCategoryService.Update(Entity);

            //Assert
            knowledgeBaseCategoryService.Received();
        }

        [Test]
        public void DeleteTest()
        {
            //Arrange
            var knowledgeBaseCategoryService = new KnowledgeBaseCategoryService(KnowledgebaseCategoryRepo);

            //Act
            knowledgeBaseCategoryService.Delete(1);

            //Assert
            knowledgeBaseCategoryService.Received();
        }

        [Test]
        public void SelectTest()
        {
            //Arrange
            var knowledgeBaseCategoryService = new KnowledgeBaseCategoryService(KnowledgebaseCategoryRepo);

            //Act
            knowledgeBaseCategoryService.Select(1);

            //Assert
            knowledgeBaseCategoryService.Received();
        }

        [Test]
        public void SelectAllTest()
        {
            //Arrange
            var knowledgeBaseCategoryService = new KnowledgeBaseCategoryService(KnowledgebaseCategoryRepo);

            //Act
            knowledgeBaseCategoryService.SelectAll();

            //Assert
            knowledgeBaseCategoryService.Received();
        }

        [Test]
        public void GetCategoryByParentCategoryIdTest()
        {
            //Arrange
            var knowledgeBaseCategoryService = new KnowledgeBaseCategoryService(KnowledgebaseCategoryRepo);

            //Act
            knowledgeBaseCategoryService.GetCategoryByParentCategoryId(1);

            //Assert
            knowledgeBaseCategoryService.Received();
        }
    }
}
