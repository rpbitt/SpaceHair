using System;
using System.Collections.Generic;
using MySqlConnector;

namespace SpaceHair.Models
{

    public class ServicoRepository
    {
        private const string DadosConexao = "Database=spacehair;Data source=localhost;User Id=root;";
        public Servico buscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query = "select * from Servico"
            String Query = "select * from Servico where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id); // controle para o sql-injection
            MySqlDataReader Reader = Comando.ExecuteReader();
            Servico servEncontrado = new Servico();

            if (Reader.Read())
            {
                servEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    servEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Setor")))
                    servEncontrado.Setor = Reader.GetString("Setor");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Preco")))
                    servEncontrado.Preco = Reader.GetInt32("Preco");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Unidade")))
                    servEncontrado.Unidade = Reader.GetString("Unidade");
                if (!Reader.IsDBNull(Reader.GetOrdinal("DataServico")))
                    servEncontrado.DataServico = Reader.GetDateTime("DataServico");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Colaborador")))
                    servEncontrado.Colaborador = Reader.GetInt32("Colaborador");
            }
            Conexao.Close();

            return servEncontrado;
        }

        public List<Servico> listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query = "select * from Servico"
            String Query = "select * from Servico";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Servico> Lista = new List<Servico>();

            while (Reader.Read())
            {
                Servico servEncontrado = new Servico();
                servEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    servEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Setor")))
                    servEncontrado.Setor = Reader.GetString("Setor");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Preco")))
                    servEncontrado.Preco = Reader.GetInt32("Preco");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Unidade")))
                    servEncontrado.Unidade = Reader.GetString("Unidade");
                if (!Reader.IsDBNull(Reader.GetOrdinal("DataServico")))
                    servEncontrado.DataServico = Reader.GetDateTime("DataServico");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Colaborador")))
                    servEncontrado.Colaborador = Reader.GetInt32("Colaborador");

                Lista.Add(servEncontrado);
            }

            Conexao.Close();

            return Lista; // retornar Lista de usuarios 

        }
        public void inserir(Servico serv)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query "insert into TABELA (campo1,campo2) Values (info1,info2";
            String Query = "insert into Servico (Nome, Setor, Preco, Unidade, DataServico, Colaborador) values (@Nome, @Setor, @Preco, @Unidade, @DataServico, @Colaborador)";

            // comando e os controles para sql-injecton
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", serv.Nome); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Setor", serv.Setor); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Preco", serv.Preco); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Unidade", serv.Unidade); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@DataServico", serv.DataServico); //controle para o sql-injection            
            Comando.Parameters.AddWithValue("@Colaborador", serv.Colaborador);

            Comando.ExecuteNonQuery(); //executar no banco de dados 

            Conexao.Close();
        }

        public void atualizar(Servico serv)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query "update TABELA SET campo 1=info1, campo2=info2 where Id=@Id"
            String Query = "Update PacoteTuristico SET Nome=@Nome, Setor=@Setor, Preco=@Preco, Unidade=@Unidade, DataServico=@DataServico, Colaborador=@Colaborador Where Id=@Id";

            // comando e os controles para sql-injecton
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", serv.Id);// controle para o sql-injection             
            Comando.Parameters.AddWithValue("@Nome", serv.Nome); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Setor", serv.Setor); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Preco", serv.Preco); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@Unidade", serv.Unidade); //controle para o sql-injection
            Comando.Parameters.AddWithValue("@DataServico", serv.DataServico); //controle para o sql-injection            
            Comando.Parameters.AddWithValue("@Colaborador", serv.Colaborador);

            Comando.ExecuteNonQuery();// executar no banco de dados 

            Conexao.Close(); 
        }
        public void remover(Servico serv)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // definir a query(SQL) deletar da TABELA quando ID = codigo          
            String Query = "delete from Servico where Id =@Id";

            // define linha de comando para ser executada
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", serv.Id);// controle para o sql-injection 

            Comando.ExecuteNonQuery(); // executar no banco de dados

            Conexao.Close();
        }

    }

}