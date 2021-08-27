using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Models
{
    public class ClientesDAL : IClientesDAL
    {

       

        string connectionString = @"Data Source = localhost\SQLEXPRESS01;Initial Catalog=AdoCadastroDeClientes;Integrated Security=True; User ID=root;Password=Cadmus@123";

        public IEnumerable<Cliente> GetAllDbClientes()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ClienteId, Nome, RG, CPF, Telefone, NomeMae, NomePai, Email from DbClientes", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cliente Cliente = new Cliente();
                    Cliente.ClienteId = Convert.ToInt32(rdr["ClienteId"]);
                    Cliente.Nome = rdr["Nome"].ToString();
                    Cliente.RG = rdr["RG"].ToString();
                    Cliente.CPF = rdr["CPF"].ToString();
                    Cliente.Telefone = rdr["Telefone"].ToString();
                    Cliente.NomeMae = rdr["NomeMae"].ToString();
                    Cliente.NomePai = rdr["NomePai"].ToString();
                    Cliente.Email = rdr["Email"].ToString();
                    lstCliente.Add(Cliente);
                }
                con.Close();
            }
            return lstCliente;
        }
        public void AddCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into DbClientes (Nome, RG, CPF, Telefone, NomeMae, NomePai, Email) Values(@Nome, @RG, @CPF, @Telefone, @NomeMae, @NomePai, @Email)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@RG", cliente.RG);
                cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@NomeMae", cliente.NomeMae);
                cmd.Parameters.AddWithValue("@NomePai", cliente.NomePai);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update DbClientes set Nome = @Nome, RG = @RG, CPF = @CPF, Telefone = @Telefone, NomeMae = @NomeMae, NomePai = @NomePai, Email = @Email where ClienteId = @ClienteId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@RG", cliente.RG);
                cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@NomeMae", cliente.NomeMae);
                cmd.Parameters.AddWithValue("@NomePai", cliente.NomePai);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Cliente GetCliente(int? id)
        {
            Cliente cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM DbClientes WHERE ClienteId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cliente.ClienteId = Convert.ToInt32(rdr["ClienteId"]);
                    cliente.Nome = rdr["Nome"].ToString();
                    cliente.RG = rdr["RG"].ToString();
                    cliente.CPF = rdr["CPF"].ToString();
                    cliente.Telefone = rdr["Telefone"].ToString();
                    cliente.NomeMae = rdr["NomeMae"].ToString();
                    cliente.NomePai = rdr["NomePai"].ToString();
                    cliente.Email = rdr["Email"].ToString();
                }
            }
            return cliente;
        }

        public void DeleteCliente(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from DbClientes where ClienteId=" +id;
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ClienteId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
} 