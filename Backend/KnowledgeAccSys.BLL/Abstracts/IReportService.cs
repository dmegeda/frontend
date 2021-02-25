using KnowledgeAccSys.BLL.DTO;
using System.Threading.Tasks;

namespace KnowledgeAccSys.BLL.Abstracts
{
    public interface IReportService : IService<ReportDTO>
    {
        int GetAllTestingUsersCount(int test_id);
        int GetPassedCount(int test_id);
        double GetAvgRate(int test_id);
    }
}
