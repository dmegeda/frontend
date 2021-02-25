using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Infrastructure;
using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccSys.BLL.Services
{
    public class ReportsService : IReportService
    {
        readonly IUnitOfWork db;

        public ReportsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Add(ReportDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<ReportDTO, Report>.GetMapper();
                Report report = mapper.Map<ReportDTO, Report>(item);
                db.Reports.Add(report);
                db.Save();
            }     
        }

        public async Task AddAsync(ReportDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<ReportDTO, Report>.GetMapper();
                Report report = mapper.Map<ReportDTO, Report>(item);
                await db.Reports.AddAsync(report);
                await db.SaveAsync();
            }     
        }

        public void Delete(int id)
        {
            db.Reports.Delete(id);
            db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Reports.DeleteAsync(id);
            await db.SaveAsync();
        }

        public IEnumerable<ReportDTO> Find(Func<ReportDTO, bool> predicate)
        {
            var mapper = MapperHelper<Report, ReportDTO>.GetMapper();
            var mapped_predicate = MapperHelper<ReportDTO, Report>.MapPredicate(predicate);
            var reports = db.Reports.Find(mapped_predicate);

            return mapper.Map<IEnumerable<Report>, IEnumerable<ReportDTO>>(reports);
        }

        public IEnumerable<ReportDTO> GetAll(bool isDeleted = false)
        {
            var mapper = MapperHelper<Report, ReportDTO>.GetMapper();

            return mapper.Map<IEnumerable<Report>, IEnumerable<ReportDTO>>(db.Reports.GetAll()
                .Where(x => x.IsDeleted == isDeleted));
        }

        public async Task<IEnumerable<ReportDTO>> GetAllAsync(bool isDeleted = false)
        {
            var mapper = MapperHelper<Report, ReportDTO>.GetMapper();
            var reports = mapper.Map<IEnumerable<Report>, IEnumerable<ReportDTO>>(await db.Reports.GetAllAsync());
            return reports.Where(x => x.IsDeleted == isDeleted);
        }

        public ReportDTO GetById(int id)
        {
            var mapper = MapperHelper<Report, ReportDTO>.GetMapper();

            return mapper.Map<Report, ReportDTO>(db.Reports.GetById(id));
        }

        public async Task<ReportDTO> GetByIdAsync(int id)
        {
            var mapper = MapperHelper<Report, ReportDTO>.GetMapper();

            return mapper.Map<Report, ReportDTO>(await db.Reports.GetByIdAsync(id));
        }

        public void Update(ReportDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<ReportDTO, Report>.GetMapper();
                db.Reports.Update(mapper.Map<ReportDTO, Report>(item));
                db.Save();
            }    
        }

        public int GetAllTestingUsersCount(int test_id)
        {
            return db.Statistics.Find(x => x.TestId == test_id).ToList().Count;
        }

        public double GetAvgRate(int test_id)
        {
            var stats = db.Statistics.Find(x => x.TestId == test_id).ToList();
            if (stats.Count == 0) return 0;
            double sum = stats.Sum(x => x.UserRating);

            return sum / stats.Count;
        }

        public int GetPassedCount(int test_id)
        {
            return db.Statistics.Find(x => x.TestId == test_id && x.IsPassed).ToList().Count;
        }
    }
}
