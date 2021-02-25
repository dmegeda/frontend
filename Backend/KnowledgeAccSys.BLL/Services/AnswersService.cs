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
    public class AnswersService : IService<AnswerDTO>
    {
        readonly IUnitOfWork db;

        public AnswersService(IUnitOfWork context)
        {
            db = context;
        }

        public void Add(AnswerDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<AnswerDTO, Answer>.GetMapper();
                Answer answer = mapper.Map<AnswerDTO, Answer>(item);
                db.Answers.Add(answer);
            }  
        }

        public async Task AddAsync(AnswerDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<AnswerDTO, Answer>.GetMapper();
                Answer answer = mapper.Map<AnswerDTO, Answer>(item);
                await db.Answers.AddAsync(answer);
            }    
        }

        public void Delete(int id)
        {
            db.Answers.Delete(id);
            db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Answers.DeleteAsync(id);
            await db.SaveAsync();
        }

        public IEnumerable<AnswerDTO> Find(Func<AnswerDTO, bool> predicate)
        {
            var mapper = MapperHelper<Answer, AnswerDTO>.GetMapper();
            var mapped_predicate = MapperHelper<AnswerDTO, Answer>.MapPredicate(predicate);
            var answers = db.Answers.Find(mapped_predicate);

            return mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);
        }

        public IEnumerable<AnswerDTO> GetAll(bool isDeleted = false)
        {
            var mapper = MapperHelper<Answer, AnswerDTO>.GetMapper();
            return mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(db.Answers.GetAll()
                .Where(x => x.IsDeleted == isDeleted));
        }

        public async Task<IEnumerable<AnswerDTO>> GetAllAsync(bool isDeleted = false)
        {
            var mapper = MapperHelper<Answer, AnswerDTO>.GetMapper();
            var answers = mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(await db.Answers.GetAllAsync());
            return answers.Where(x => x.IsDeleted == isDeleted);
        }

        public AnswerDTO GetById(int id)
        {
            var mapper = MapperHelper<TestQuestion, TestQuestionDTO>.GetMapper();

            return mapper.Map<Answer, AnswerDTO>(db.Answers.GetById(id));
        }

        public async Task<AnswerDTO> GetByIdAsync(int id)
        {
            var mapper = MapperHelper<TestQuestion, TestQuestionDTO>.GetMapper();

            return mapper.Map<Answer, AnswerDTO>(await db.Answers.GetByIdAsync(id));
        }

        public void Update(AnswerDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<AnswerDTO, Answer>.GetMapper();
                db.Answers.Update(mapper.Map<AnswerDTO, Answer>(item));
                db.Save();
            }   
        }
    }
}
