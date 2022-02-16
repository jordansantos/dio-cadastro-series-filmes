using System.Collections.Generic;

namespace CadastroSeriesEFilmes.Interface
{
  public interface IRepository<T>
  {
    List<T> FindAll();
    T FindById(int id);
    void Insert(T entity);
    void Delete(int id);
    void Update(int id, T entity);
  }
}