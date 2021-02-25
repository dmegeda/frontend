using KnowledgeAccSys.BLL.DTO;
using System.Threading.Tasks;

namespace KnowledgeAccSys.BLL.Abstracts
{
    public interface IStatisticService : IService<StatisticDTO>
    {
        Task<double> CalculateUserRating(int correctAnswers, int test_id);
        bool CheckTestIsPassed(double userRating, double minRate);
    }
}
