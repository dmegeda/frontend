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
    public class QuestionsService : IService<TestQuestionDTO>
    {
        readonly IUnitOfWork db;

        public QuestionsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Add(TestQuestionDTO item)
        {
            if(item != null)
            {
                var mapper = GetMapperToEntity();
                TestQuestion question = mapper.Map<TestQuestionDTO, TestQuestion>(item);
                db.Questions.Add(question);
                db.Save();
            }    
        }

        public async Task AddAsync(TestQuestionDTO item)
        {
            if(item != null)
            {
                var mapper = GetMapperToEntity();
                TestQuestion question = mapper.Map<TestQuestionDTO, TestQuestion>(item);
                await db.Questions.AddAsync(question);
                await db.SaveAsync();
            }    
        }

        public void Delete(int id)
        {
            db.Questions.Delete(id);
            db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Questions.DeleteAsync(id);
            await db.SaveAsync();
        }

        public IEnumerable<TestQuestionDTO> Find(Func<TestQuestionDTO, bool> predicate)
        {
            var mapper = GetMapperToDto();
            var mapped_predicate = MapperHelper<TestQuestionDTO, TestQuestion>.MapPredicate(predicate);
            var questions = db.Questions.Find(mapped_predicate);

            return mapper.Map<IEnumerable<TestQuestion>, IEnumerable<TestQuestionDTO>>(questions);
        }

        public IEnumerable<TestQuestionDTO> GetAll(bool isDeleted = false)
        {
            var mapper = GetMapperToDto();

            return mapper.Map<IEnumerable<TestQuestion>, 
                IEnumerable<TestQuestionDTO>>(db.Questions.GetAll()
                .Where(x => x.IsDeleted == isDeleted));
        }

        public async Task<IEnumerable<TestQuestionDTO>> GetAllAsync(bool isDeleted = false)
        {
            var mapper = GetMapperToDto();
            var questions = mapper.Map<IEnumerable<TestQuestion>, IEnumerable<TestQuestionDTO>>(await db.Questions.GetAllAsync());
            return questions.Where(x => x.IsDeleted == isDeleted);
        }

        public TestQuestionDTO GetById(int id)
        {
            var mapper = GetMapperToDto();

            return mapper.Map<TestQuestion, TestQuestionDTO>(db.Questions.GetById(id));
        }

        public async Task<TestQuestionDTO> GetByIdAsync(int id)
        {
            var mapper = GetMapperToDto();

            return mapper.Map<TestQuestion, TestQuestionDTO>(await db.Questions.GetByIdAsync(id));
        }

        public void Update(TestQuestionDTO item)
        {
            if(item != null)
            {
                var mapper = GetMapperToEntity();
                db.Questions.Update(mapper.Map<TestQuestionDTO, TestQuestion>(item));
            } 
        }

        private IMapper GetMapperToEntity()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestQuestionDTO, TestQuestion>();
                cfg.CreateMap<AnswerDTO, Answer>();
            }).CreateMapper();
        }

        private IMapper GetMapperToDto()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestQuestion, TestQuestionDTO>();
                cfg.CreateMap<Answer, AnswerDTO>();
            }).CreateMapper();
        }
    }
}
