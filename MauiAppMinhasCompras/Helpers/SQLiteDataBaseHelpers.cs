using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDataBaseHelpers(string path)
        {
            _conn = new SQLiteAsyncConnection(path); 
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE produto SET Descricao = ?, Quantidade = ?, " +
                "Quantidade = ?, Preco = ? WHERE Id = ?";

            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }
    }
}
