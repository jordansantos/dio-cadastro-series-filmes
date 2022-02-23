using System.Collections.Generic;

namespace CadastroSeriesEFilmes.Interface
{
  public interface IRepository<T>
  {
    List<T> BuscarTodos();
    T BuscarPeloId(int id);
    void Inserir(T entity);
    bool Deletar(int id);
    bool Atualizar(int id, T entity);
  }
}