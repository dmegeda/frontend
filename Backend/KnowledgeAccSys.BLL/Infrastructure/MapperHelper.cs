using AutoMapper;
using System;

namespace KnowledgeAccSys.BLL.Infrastructure
{
    public static class MapperHelper<T, M> where T : class
        where M : class
    {
        public static IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => cfg
            .CreateMap<T, M>())
                .CreateMapper();
        }

        public static Func<M, bool> MapPredicate(Func<T, bool> predicate)
        {
            var mapper = GetMapper();
            return mapper.Map<Func<T, bool>, Func<M, bool>>(predicate);
        }
    }
}
