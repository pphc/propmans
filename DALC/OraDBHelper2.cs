//***********************************************************************
// Assembly         : DALC
// Author           : Mark Angelo Rivo
// Created          : 04-27-2011
//
// Last Modified By : Mark Angelo Rivo
// Last Modified On : 07-01-2011
// Description      : 
//
// Copyright        : (c) Phinma Properties. All rights reserved.
//***********************************************************************

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;


namespace DALC
{

    /// <summary>
    /// DB Helper for Oracle
    /// </summary>
    public sealed class OraDBHelper2
    {
        private OraDBHelper2()
        {

        }
        public static void SetCurrentWorkingSchema()
        {
            try
            {
                string appSchema = OraConnection.Instance.AppSchema;
                string command = string.Format("ALTER SESSION SET CURRENT_SCHEMA={0}", appSchema);
                int result;
                using (OracleCommand cmd = new OracleCommand(command,OraConnection.Instance.OracleConnection))
                {

                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                 result=cmd.ExecuteNonQuery();
                }
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// for select querries without parameters, equivalent to ExecuteReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DataTable GetResultSet(string strSql)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(strSql, OraConnection.Instance.OracleConnection))
                {
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }

                    using (OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        //if (reader.HasRows) {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(reader);
                            return dt;
                        }
                        //    }
                        //else {
                        //    return null;
                        //    }

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// for select queries with parameters, equivalent to ExecuteReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DataTable GetResultSet(string strSql, List<OracleParameter> @params)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(strSql, OraConnection.Instance.OracleConnection))
                {
                    cmd.BindByName = true;

                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }


                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }

                    using (OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        //if (reader.HasRows) {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(reader, LoadOption.OverwriteChanges);
                            return dt;
                        }
                        //    }
                        //else {
                        //    return null;
                        //    }

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// for insert,update,delete operations without paramaters, equivalent to ExecuteNonQuery
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>no. rows affected</returns>
        /// <remarks></remarks>
        public static int SqlExecute(string strSql)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(strSql, OraConnection.Instance.OracleConnection))
                {
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// for insert,update,delete operations with paramaters , equivalent to ExecuteNonQuery
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="params"></param>
        /// <returns>no. rows affected</returns>
        /// <remarks></remarks>
        public static int SqlExecute(string strSql, List<OracleParameter> @params)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(strSql, OraConnection.Instance.OracleConnection))
                {
                    cmd.BindByName = true;
                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// for querries retrieving single value, equivalent to ExecuteNonScalar
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Object SqlExecuteScalar(string strSql)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(strSql, OraConnection.Instance.OracleConnection))
                {
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// for querries retrieving single value with parameters,, equivalent to ExecuteNonScalar
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Object SqlExecuteScalar(string strSql, List<OracleParameter> @params)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(strSql, OraConnection.Instance.OracleConnection))
                {

                    cmd.BindByName = true;
                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// for PL/SQL Function with returning value
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object ExecuteFunction(string functionName, List<OracleParameter> @params)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = true;
                    //specify that you are working with
                    //stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //provide the name of stored procedure
                    cmd.CommandText = functionName;
                    //provide parameter details

                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.Connection = OraConnection.Instance.OracleConnection;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.ExecuteNonQuery();

                    foreach (OracleParameter param in @params)
                    {
                        if (param.Direction == ParameterDirection.ReturnValue)
                        {
                            return cmd.Parameters[param.ParameterName].Value;
                        }
                    }
                    return null;
                }
            }
            catch (OracleException ex)
            {
                if (ex.ErrorCode == 1)
                {
                    throw new Exception("A similar transaction is already existing");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
                        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExecuteProcedure(string procedureName)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    //specify that you are working with
                    //stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //provide the name of stored procedure
                    cmd.CommandText = procedureName;
                    //provide parameter details

                    cmd.Connection = OraConnection.Instance.OracleConnection;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// for PL/SQL Procedure with one or many output parameters
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Dictionary<string, object> ExecuteProcedure(string procedureName, List<OracleParameter> @params)
        {

            try
            {

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = true;
                    //specify that you are working with
                    //stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //provide the name of stored procedure
                    cmd.CommandText = procedureName;
                    //provide parameter details

                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.Connection = OraConnection.Instance.OracleConnection;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.ExecuteNonQuery();

                    Dictionary<string, object> dict = new Dictionary<string, object>();

                    foreach (OracleParameter param in @params)
                    {
                        if (param.Direction == ParameterDirection.Output)
                        {
                            dict.Add(param.ParameterName, cmd.Parameters[param.ParameterName].Value);
                        }
                    }
                    return dict;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        ///  for PL/SQL Procedure with input paramaters only
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="params"></param>
        public static void ExecuteProcedureforInput(string procedureName, List<OracleParameter> @params)
        {

            try
            {

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = true;
                    //specify that you are working with
                    //stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //provide the name of stored procedure
                    cmd.CommandText = procedureName;
                    //provide parameter details

                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.Connection = OraConnection.Instance.OracleConnection;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// for PL/SQL Procedure that returns ref cursor 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DataTable ExecuteProcedureRefCursor(string procedureName, List<OracleParameter> @params)
        {

            try
            {

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = true;
                    //specify that you are working with
                    //stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //provide the name of stored procedure
                    cmd.CommandText = procedureName;
                    //provide parameter details

                    foreach (OracleParameter param in @params)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.Connection = OraConnection.Instance.OracleConnection;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.ExecuteNonQuery();

                    OracleRefCursor oreref = null;

                    foreach (OracleParameter param in cmd.Parameters)
                    {
                        if (param.Direction == ParameterDirection.ReturnValue)
                        {
                            oreref = (OracleRefCursor)param.Value;
                        }
                    }

                    using (OracleDataReader reader = oreref.GetDataReader())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(reader, LoadOption.OverwriteChanges);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
