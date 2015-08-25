using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DALC
{
    public class OraDBAccess : IDisposable
    {
        private OracleParameterCollection oraparams;
        private OracleCommand command;
        private OracleConnection connection;
        public   OracleConnection Connection {
            private set { connection = value; }
            get { return connection; }
        }
        public  OraDBAccess() {
            connection = OraConnection.Instance.OracleConnection;
        }

        public void AddParameter(string paramaterName,object paramValue) {
            var param = new OracleParameter();
            //param.ParameterName  
            param.OracleDbType = OracleDbType.Varchar2;

            oraparams.Add(param);
      
        }

        public OracleDataReader ExecuteReader(string strSQL)
        {
            try
            {
                command = new OracleCommand(strSQL, this.Connection);
                command.BindByName =true;
                if (oraparams.Count>0){
                 foreach (OracleParameter param in oraparams)
                    {
                        command.Parameters.Add(param);
                    }
                }

                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                return command.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ExecuteNonQuery(string strSQL) {
            try
            {
                
                command = new OracleCommand(strSQL, this.Connection);
                command.BindByName = true;
                if (oraparams.Count > 0)
                {
                    foreach (OracleParameter param in oraparams)
                    {
                        command.Parameters.Add(param);
                    }
                }

                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                return command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Object ExecuteScalar(string strSQL) {
            try
            {
                command = new OracleCommand(strSQL, this.Connection);
                command.BindByName = true;
                if (oraparams.Count > 0)
                {
                    foreach (OracleParameter param in oraparams)
                    {
                        command.Parameters.Add(param);
                    }
                }

                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                return command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ExecuteProcedure(string procedureName) {
            try
            {
                command = new OracleCommand(procedureName, this.Connection);
                command.BindByName = true;
                command.CommandType = CommandType.StoredProcedure;
                if (oraparams.Count > 0)
                {
                    foreach (OracleParameter param in oraparams)
                    {
                        command.Parameters.Add(param);
                    }
                }

                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                return command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public void Dispose()

        {
            command.Dispose();
            connection.Dispose();
        }
    }
  

}
