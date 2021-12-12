using System;
using System.Collections.Generic;
using MySqlConnector;

namespace SpaceHair.Models
{
    public class ColaboradorRepository
    {
        private const string DadosConexao = "Database=spacehair;Data source=localhost;User Id=root;";

        public void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando!");
            Conexao.Close();
        }
        // operacoes de manipulacao no banco de dados da classe 'Usuario'
        // CRUD ==> inserir(C) Usuario no Banco,listar(R), alterar(U) e excluir(D)

        public Colaborador validarLogin(Colaborador colab)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query 
            String Query = "select * from Colaborador where Login=@Login and Senha=@Senha";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);// segurança do sistema, controle para o sql-injection
            Comando.Parameters.AddWithValue("@Login", colab.Login);
            Comando.Parameters.AddWithValue("@Senha", colab.Senha);  // controle para o sql-injection
            MySqlDataReader Reader = Comando.ExecuteReader();

            Colaborador colabEncontrado = null;

            if (Reader.Read())
            {
                colabEncontrado = new Colaborador();
                colabEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    colabEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    colabEncontrado.Login = Reader.GetString("Login");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    colabEncontrado.Senha = Reader.GetString("Senha");
                colabEncontrado.DataContratacao = Reader.GetDateTime("DataContratacao");

            }

            Conexao.Close();

            return colabEncontrado;

        }

        public Colaborador buscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query = "select * from Colaborador"
            String Query = "select * from Colaborador where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);// controle para o sql-injection
            MySqlDataReader Reader = Comando.ExecuteReader();
            Colaborador colabEncontrado = new Colaborador();

            if (Reader.Read())
            {
                colabEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    colabEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    colabEncontrado.Login = Reader.GetString("Login");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    colabEncontrado.Senha = Reader.GetString("Senha");
                colabEncontrado.DataContratacao = Reader.GetDateTime("DataContratacao"); 
            } 
            Conexao.Close();

            return colabEncontrado; 
        }

        public List<Colaborador> listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query = "select * from Colaborador"
            String Query = "select * from Colaborador";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Colaborador> Lista = new List<Colaborador>();

            while (Reader.Read())
            {
                Colaborador colabEncontrado = new Colaborador();
                colabEncontrado.Id = Reader.GetInt32("Id");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    colabEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    colabEncontrado.Login = Reader.GetString("Login");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    colabEncontrado.Senha = Reader.GetString("Senha");

                colabEncontrado.DataContratacao = Reader.GetDateTime("DataContratacao");

                Lista.Add(colabEncontrado);
            } 
            Conexao.Close();

            return Lista; // retornar Lista de usuarios 
        }
        public void inserir(Colaborador colab)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query "insert into TABELA (campo1,campo2) Values (info1,info2)";
            String Query = "insert into Colaborador (Nome, Login, Senha, DataContratacao)values (@Nome, @Login, @Senha, @DataContratacao)";

            // comando e os controles para sql-injecton
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", colab.Nome); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Login", colab.Login);
            Comando.Parameters.AddWithValue("@Senha", colab.Senha);
            Comando.Parameters.AddWithValue("@DataContratacao", colab.DataContratacao);

            Comando.ExecuteNonQuery(); //executar no banco de dados 

            Conexao.Close();
        }

        public void atualizar(Colaborador colab)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query "update TABELA SET campo 1=info1, campo2=info2 where Id=@Id"
            String Query = "Update Colaborador SET Nome=@Nome, Login=@Login, Senha=@Senha, DataContratacao=@DataContratacao Where Id=@Id";

            // comando e os controles para sql-injecton
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", colab.Id);
            Comando.Parameters.AddWithValue("@Nome", colab.Nome);
            Comando.Parameters.AddWithValue("@Login", colab.Login);
            Comando.Parameters.AddWithValue("@Senha", colab.Senha);
            Comando.Parameters.AddWithValue("@DataContratacao", colab.DataContratacao);

            Comando.ExecuteNonQuery();// executar no banco de dados 

            Conexao.Close(); 
        }

        public void remover(Colaborador colab)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query(SQL) deletar da TABELA quando ID = codigo          
            String Query = "delete from Colaborador where Id =@Id";

            // define linha de comando para ser executada
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", colab.Id);// controle para o sql-injection 

            Comando.ExecuteNonQuery(); // executar no banco de dados

            Conexao.Close();

        }

    }
}