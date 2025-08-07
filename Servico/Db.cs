using MySql.Data.MySqlClient;

namespace Servico
{
    public class Db
    {
        private readonly MySqlConnection _con;
        private MySqlCommand? _command;
        private MySqlDataReader? _reader;

        public Db()
        {
            _con = new MySqlConnection("Server=127.0.0.1;Database=cadusuario;Uid=root;Pwd=;SslMode=none;");
        }

        public List<UsuarioDTO> GetUsuario()
        {
            //para parar de criticar o GetData, coloquei o retorno de uma lista vazia -->  return [];
            _con.Open();
            _command = new MySqlCommand();
            _command.Connection = _con;
            _command.CommandText = "SELECT * FROM usuario";
            _reader = _command.ExecuteReader();

            List<UsuarioDTO> lisdaUsuarios = new List<UsuarioDTO>();

            while (_reader.Read())
            {
                var UsuarioDTO = new UsuarioDTO
                {
                    id = int.Parse(_reader["Id"].ToString()!),
                    nome = _reader["Nome"].ToString()!,
                    sobrenome = _reader["Sobrenome"].ToString()!,
                    email = _reader["Email"].ToString()!
                };
                lisdaUsuarios.Add(UsuarioDTO);
            }

            _con.Close();

            return lisdaUsuarios;
        }

        public void AddUsuario(string nome, string sobrenome, string email)
        {
            _con.Open();
            _command = new MySqlCommand();
            _command.Connection = _con;

            _command.CommandText = "INSERT INTO usuario (nome, sobrenome, email) VALUES (?nome, ?sobrenome, ?email)";
            _command.Parameters.Add("?nome", MySqlDbType.String).Value = nome;
            _command.Parameters.Add("?sobrenome", MySqlDbType.String).Value = sobrenome;
            _command.Parameters.Add("?email", MySqlDbType.String).Value = email;

            _command.ExecuteNonQuery();

            _con.Close();
        }
    }
}
