using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoAspMvc.DAL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(SqlConnection conn) : base(conn, "Author", "Id")
        {
        }

        protected override Author Convert(IDataRecord r)
        {
            return new Author()
            {
                Id = (int)r["Id"],
                Firstname = (string)r["Firstname"],
                Lastname = (string)r["Lastname"],
                PenName = r["Pen_name"] == DBNull.Value ? null : (string)r["Pen_name"],
                Birthdate = (DateTime)r["Birthdate"]
            };
        }

        public override int Create(Author e)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, Author e)
        {
            throw new NotImplementedException();
        }
    }
}
