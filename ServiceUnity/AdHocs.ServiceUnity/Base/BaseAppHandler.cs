using E.Quiz.Shared.Mapper.Contract;
using AdHocs.Core.Domain.Model.Base;
using AdHocs.Core.Domain.Model.Contract;
using AdHocs.CoreComponent.Contract;
using System;

namespace AdHocs.Core.QuizUnity.Base
{
    public abstract class BaseAppHandler<TDto, TEntity> : IAppHandler<TDto> where TDto : BaseDto, IEntityDto<int> where TEntity : BaseEntity, IEntity<int>
    {
        public readonly IRepository<TEntity, int> _repository;

        protected BaseAppHandler(IRepository<TEntity, int> repository)
        {
            _repository = repository;
        }


        public TDto GetById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                return IMapper.Map<entity,TDto>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Insert(TDto dto)
        {
            var entity = dto.MapTo<TEntity>();
            var result = _repository.Add(entity);
            return result;
        }


        public void Update(TDto dto)
        {
            var entity = dto.MapTo<TEntity>();
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id).MapTo<TEntity>();
            _repository.Delete(entity);
        }

    }
}
