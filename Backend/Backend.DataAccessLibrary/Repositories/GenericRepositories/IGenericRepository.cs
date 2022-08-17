namespace Backend.DataAccessLibrary;

public interface IGenericRepository < TEntity > where TEntity: class {
        TEntity Get(int Id);  
        IEnumerable<TEntity> GetAll();  
        long Add(TEntity entity);  
        void Delete(TEntity entity);  
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAllByCondition(string condition);
}