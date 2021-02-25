using AutoMapper;
using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Infrastructure;
using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccSys.BLL.Services
{
    public class StatisticsService : IStatisticService
    {
        readonly IUnitOfWork db;

        public StatisticsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Add(StatisticDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<StatisticDTO, Statistic>.GetMapper();
                Statistic statistic = mapper.Map<StatisticDTO, Statistic>(item);
                db.Statistics.Add(statistic);
                db.Save();
            }   
        }

        public async Task AddAsync(StatisticDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<StatisticDTO, Statistic>.GetMapper();
                Statistic statistic = mapper.Map<StatisticDTO, Statistic>(item);
                await db.Statistics.AddAsync(statistic);
                await db.SaveAsync();
            }  
        }

        public void Delete(int id)
        {
            db.Statistics.Delete(id);
            db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Statistics.DeleteAsync(id);
            await db.SaveAsync();
        }

        public IEnumerable<StatisticDTO> Find(Func<StatisticDTO, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<StatisticDTO> GetAll(bool isDeleted = false)
        {
            var mapper = MapperHelper<Statistic, StatisticDTO>.GetMapper();

            return mapper
                .Map<IEnumerable<Statistic>, IEnumerable<StatisticDTO>>(db.Statistics.GetAll()
                .Where(x => x.IsDeleted == isDeleted));
        }

        public async Task<IEnumerable<StatisticDTO>> GetAllAsync(bool isDeleted = false)
        {
            var mapper = MapperHelper<Statistic, StatisticDTO>.GetMapper();
            var stats = mapper.Map<IEnumerable<Statistic>, IEnumerable<StatisticDTO>>(await db.Statistics.GetAllAsync());

            return stats.Where(x => x.IsDeleted == isDeleted);
        }

        public StatisticDTO GetById(int id)
        {
            var mapper = MapperHelper<Statistic, StatisticDTO>.GetMapper();

            return mapper.Map<Statistic, StatisticDTO>(db.Statistics.GetById(id));
        }

        public async Task<StatisticDTO> GetByIdAsync(int id)
        {
            var mapper = MapperHelper<Statistic, StatisticDTO>.GetMapper();

            return mapper.Map<Statistic, StatisticDTO>(await db.Statistics.GetByIdAsync(id));
        }

        public void Update(StatisticDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<StatisticDTO, Statistic>.GetMapper();
                db.Statistics.Update(mapper.Map<StatisticDTO, Statistic>(item));
                db.Save();
            }   
        }

        public async Task<double> CalculateUserRating(int correctAnswers, int test_id)
        {
            TestsService testService = new TestsService(db);
            var test = await testService.GetByIdAsync(test_id);
            if(test != null)
            {
                int questionsCount = test.Questions.ToList().Count;
                if (questionsCount < correctAnswers || questionsCount < 1) return 0;

                double questionWeight = test.MaxRate / questionsCount;
                return correctAnswers * questionWeight;
            }
            return 0;
        }

        public bool CheckTestIsPassed(double userRating, double minRate)
        {
            if (minRate < 0 || userRating < 0) return false;

            if(minRate > userRating) return false;

            return true;
        }
    }
}
