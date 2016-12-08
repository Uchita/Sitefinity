using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Service.Dapper
{
    public interface IMemberFilesService : IMemberFilesRepository
    {
    }

    public class MemberFilesService : IMemberFilesService
    {
        IMemberFilesRepository memberfilesRepository;
        public MemberFilesService(IMemberFilesRepository memberfilesRepository)
        {
            this.memberfilesRepository = memberfilesRepository;
        }

        public int Insert(MemberFilesEntity entity)
        {
            return memberfilesRepository.Insert(entity);
        }

        public void Update(MemberFilesEntity entity)
        {
            memberfilesRepository.Update(entity);
        }

        public void Delete(int id)
        {
            memberfilesRepository.Delete(id);
        }

        public MemberFilesEntity Select(int id)
        {
            return memberfilesRepository.Select(id);
        }

        public List<MemberFilesEntity> SelectAll()
        {
            return memberfilesRepository.SelectAll();
        }

        public List<MemberFilesEntity> SelectAllNonBinary()
        {
            return memberfilesRepository.SelectAllNonBinary();
        }
    }
}
