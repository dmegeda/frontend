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
    public class ThemesService : IService<ThemeDTO>
    {
        readonly IUnitOfWork db;

        public ThemesService(IUnitOfWork context)
        {
            db = context;
        }

        public void Add(ThemeDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<ThemeDTO, Theme>.GetMapper();
                Theme theme = mapper.Map<ThemeDTO, Theme>(item);
                db.Themes.Add(theme);
                db.Save();
            }   
        }

        public async Task AddAsync(ThemeDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<ThemeDTO, Theme>.GetMapper();
                Theme theme = mapper.Map<ThemeDTO, Theme>(item);
                await db.Themes.AddAsync(theme);
                await db.SaveAsync();
            }  
        }

        public void Delete(int id)
        {
            db.Themes.Delete(id);
            db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Themes.DeleteAsync(id);
            await db.SaveAsync();
        }

        public IEnumerable<ThemeDTO> Find(Func<ThemeDTO, bool> predicate)
        {
            var mapper = MapperHelper<Theme, ThemeDTO>.GetMapper();
            var mapped_predicate = MapperHelper<ThemeDTO, Theme>.MapPredicate(predicate);
            var themes = db.Themes.Find(mapped_predicate);

            return mapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDTO>>(themes);
        }

        public IEnumerable<ThemeDTO> GetAll(bool isDeleted = false)
        {
            var mapper = MapperHelper<Theme, ThemeDTO>.GetMapper();

            return mapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDTO>>(db.Themes.GetAll()
                .Where(x => x.IsDeleted == isDeleted));
        }

        public async Task<IEnumerable<ThemeDTO>> GetAllAsync(bool isDeleted = false)
        {
            var mapper = MapperHelper<Theme, ThemeDTO>.GetMapper();
            var themes = mapper
                .Map<IEnumerable<Theme>, IEnumerable<ThemeDTO>>(await db.Themes.GetAllAsync());
            return themes.Where(x => x.IsDeleted == isDeleted);
        }

        public ThemeDTO GetById(int id)
        {
            var mapper = MapperHelper<Theme, ThemeDTO>.GetMapper();

            return mapper.Map<Theme, ThemeDTO>(db.Themes.GetById(id));
        }

        public async Task<ThemeDTO> GetByIdAsync(int id)
        {
            var mapper = MapperHelper<Theme, ThemeDTO>.GetMapper();

            return mapper.Map<Theme, ThemeDTO>(await db.Themes.GetByIdAsync(id));
        }

        public void Update(ThemeDTO item)
        {
            if(item != null)
            {
                var mapper = MapperHelper<ThemeDTO, Theme>.GetMapper();
                db.Themes.Update(mapper.Map<ThemeDTO, Theme>(item));
                db.SaveAsync();
            }   
        }
    }
}
