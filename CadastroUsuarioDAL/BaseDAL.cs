using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioDAL
{
    public class BaseDAL
    {
        protected string stringDB = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected SqlCommand command;
        protected SqlConnection connection;
        protected SqlDataAdapter dataAdapter;
    }
}
