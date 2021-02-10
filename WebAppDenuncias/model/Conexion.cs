using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//imports requeridos
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebAppDenuncias.model
{
    public class Conexion
    {
        private SqlConnection sqlConnection;

        /// <summary>
        /// SPO: Genera la conexion al BD
        /// </summary>
        public Conexion()
        {
            string connection = ConfigurationManager.ConnectionStrings["dsDenuncias"].ConnectionString.Trim();
            sqlConnection = new SqlConnection(connection);
        }

        /// <summary>
        /// Obtiene los datos de la BD
        /// </summary>
        /// <param name="sql">La sentencia a ejecutar</param>
        /// <returns></returns>
        public DataSet getData(string sql)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        /// <summary>
        /// Realiza el insert, update y delete
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool saveData(string sql)
        {
            int registrosAfectados = 0;
            bool registroSave = false;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                registrosAfectados = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

               if(registrosAfectados > 0)
                {
                    registroSave = true;
                }
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
                sqlConnection.Close();
            }

            return registroSave;
        }

        public bool iudData(string sp, SqlParameter[] sqlParameters)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlTransaction sqlTransaction = null;

            int registrosAfectados = 0;
            bool registroSave = false;

            try
            {
                sqlConnection = getConecction();
                using (sqlConnection)
                {
                    sqlTransaction = sqlConnection.BeginTransaction();
                    sqlCommand = new SqlCommand(sp, sqlConnection);
                    using (sqlCommand)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(sqlParameters);

                        registrosAfectados = sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }

                    if(registrosAfectados > 0)
                    {
                        registroSave = true;
                    }
                }
            }
            catch (Exception e)
            {

                try
                {
                    sqlTransaction.Rollback();
                }
                catch (Exception e2)
                {
                    e2.Message.ToString();
                    
                }

                e.Message.ToString();
            }

            return registroSave;

        }

        private SqlConnection getConecction()
        {
            string strCadena = ConfigurationManager.ConnectionStrings["dsDenuncias"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strCadena);

            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {

                sqlConnection.Close();
            }

            return sqlConnection;
        }

        public DataSet getData(string sp, SqlParameter[] sqlParameters)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter;
            try
            {
                SqlConnection sqlConnection = getConecction();
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sp, sqlConnection);
                    using (sqlCommand)
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(sqlParameters);
                        sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.Fill(dataSet);   
                    }
                }
            }
            catch (Exception e)
            {

                e.Message.ToString();
            }
            return dataSet;
        }
    }
}