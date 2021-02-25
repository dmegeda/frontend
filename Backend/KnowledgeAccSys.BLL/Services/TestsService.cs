using AutoMapper;
using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Infrastructure;
using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccSys.BLL.Services
{
    public class TestsService : IService<TestDTO>
    {
        readonly IUnitOfWork db;

        public TestsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Add(TestDTO item)
        {
            if(item != null)
            {
                var mapper = GetMapperToEntity();
                Test test = mapper.Map<TestDTO, Test>(item);
                db.Tests.Add(test);
                db.Save();
            }   
        }

        public async Task AddAsync(TestDTO item)
        {
            if(item != null)
            {
                var mapper = GetMapperToEntity();
                Test test = mapper.Map<TestDTO, Test>(item);
                await db.Tests.AddAsync(test);
                await db.SaveAsync();
            }  
        }

        public void Delete(int id)
        {
            db.Tests.Delete(id);
            db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Tests.DeleteAsync(id);
            await db.SaveAsync();
        }

        public IEnumerable<TestDTO> Find(Func<TestDTO, bool> predicate)
        {
            var mapper = GetMapperToDto();
            var mapped_predicate = MapperHelper<TestDTO, Test>.MapPredicate(predicate);
            var tests = db.Tests.Find(mapped_predicate);

            return mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(tests);
        }

        public IEnumerable<TestDTO> GetAll(bool isDeleted = false)
        {
            var mapper = GetMapperToDto();

            return mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(db.Tests.GetAll()
                .Where(x => x.IsDeleted == isDeleted));
        }

        public async Task<IEnumerable<TestDTO>> GetAllAsync(bool isDeleted = false)
        {
            var mapper = GetMapperToDto();
            var tests = mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(await db.Tests.GetAllAsync());
            return tests.Where(x => x.IsDeleted == isDeleted);
        }

        public TestDTO GetById(int id)
        {
            var mapper = GetMapperToDto();
            return mapper.Map<Test, TestDTO>(db.Tests.GetById(id));
        }

        public async Task<TestDTO> GetByIdAsync(int id)
        {
            var mapper = GetMapperToDto();

            return mapper.Map<Test, TestDTO>(await db.Tests.GetByIdAsync(id));
        }

        public void Update(TestDTO item)
        {
            if(item != null)
            {
                var mapper = GetMapperToEntity();
                db.Tests.Update(mapper.Map<TestDTO, Test>(item));
                db.Save();
            } 
        }

        private IMapper GetMapperToEntity()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestDTO, Test>();
                cfg.CreateMap<ThemeDTO, Theme>();
                cfg.CreateMap<TestQuestionDTO, TestQuestion>();
                cfg.CreateMap<AnswerDTO, Answer>();
            }).CreateMapper();
        }

        private IMapper GetMapperToDto()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Test, TestDTO>();
                cfg.CreateMap<Theme, ThemeDTO>();
                cfg.CreateMap<TestQuestion, TestQuestionDTO>();
                cfg.CreateMap<Answer, AnswerDTO>();
            }).CreateMapper();
        }
    }
}
