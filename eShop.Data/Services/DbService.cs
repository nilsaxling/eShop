﻿

namespace eShop.Data.Services;

public class DbService : IDbService
{
    private readonly EShopContext _db;
    private readonly IMapper _mapper;

    public DbService(EShopContext db, IMapper mapper) //Injicerad
    {
        _db = db;
        _mapper = mapper;
    }
    public virtual async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class
    {
        //IncludeNavigationsFor<TEntity>();
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }
}
