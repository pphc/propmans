//***********************************************************************
// Assembly         : DALC
// Author           : Mark Angelo Rivo
// Created          : 02-24-2011
//
// Last Modified By : Mark Angelo Rivo
// Last Modified On : 07-01-2011
// Description      : 
//
// Copyright        : (c) Phinma Properties. All rights reserved.
//***********************************************************************

using Oracle.DataAccess.Client;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;




namespace DALC
    {

    public class x {}
    /// <summary>
    /// Global Oracle Connection.
    /// </summary>
    public sealed class OraConnection : IDisposable
        {

        private static OraConnection _instance;

        /// <summary>
        /// return instance of OraConnection
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static OraConnection Instance {
            get {
                if (_instance == null) {
                    throw new Exception("Connection has not been Initialize");
                    }
                else {
                    return _instance;
                    }
                }
            }

        private static string TnsString {
            get {

                StringBuilder connstr = new StringBuilder();
                connstr.Append("(DESCRIPTION = ");
                connstr.Append(" (ADDRESS = (PROTOCOL = TCP)");
                connstr.Append(" (HOST = {0})(PORT = {1}))");
                connstr.Append(" (CONNECT_DATA =");
                connstr.Append("    (SERVICE_NAME = {2})");
                connstr.Append("    (FAILOVER_MODE=");
                connstr.Append("        (TYPE=select)");
                connstr.Append("        (METHOD=basic)");
                connstr.Append("        (RETRIES=20)");
                connstr.Append("        (DELAY=15)");
                connstr.Append("     )");
                connstr.Append("  )");
                connstr.Append(")");

                return connstr.ToString();
                }
            }

        private string _hostName;
        /// <summary>
        /// returns computer host name
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string HostName {
            get { return _hostName; }
            }

        private string _hostPort;
        /// <summary>
        /// returns server host port
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string HostPort {
            get { return _hostPort; }
            }

        private string _serviceName;
        /// <summary>
        /// returns database server service name
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string ServiceName {
            get { return _serviceName; }
            }

        private string _appSchema;
        public string AppSchema {
            get { return _appSchema; }
        }

        private string _userID;
        /// <summary>
        /// get or sets current userID
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string UserID {
            get { return _userID; }
            set { _userID = value; }
            }

        private string _userPassword;
        /// <summary>
        /// set user password
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string UserPassword {
            get { return _userPassword; }
            set { _userPassword = value; }
            }

        private OracleConnection _oracleConnection;

        public OracleConnection OracleConnection {
            get {
                return _oracleConnection;
                }
            }

        private OraConnection(string userID, string userPass) {

            _userID  = userID;
            _userPassword = userPass;

            SetConnection();
            _oracleConnection = new OracleConnection(BuildConnectionString());
            
            }


        private void SetConnection()
        {

            try
            {
                AppSettingsReader reader = new AppSettingsReader();

                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                _hostName = appSettings.Get("Host");
                _hostPort = appSettings.Get("HostPort");
                _serviceName = appSettings.Get("ServiceName");
                _appSchema = appSettings.Get("AppSchema");
            }
            catch (ConfigurationErrorsException e)
            {
                throw e;
            }

        }

        /// <summary>
        /// initialize oracle connection to be used in application
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_userPass"></param>
        /// <remarks></remarks>
        public static void InitializeInstance(string userID, string userPass) {
            _instance = new OraConnection(userID, userPass);
            }


        private string BuildConnectionString() {

            OracleConnectionStringBuilder cnBuilder = new OracleConnectionStringBuilder();
                {
                cnBuilder.DataSource = string.Format(TnsString, HostName, HostPort, ServiceName);
                cnBuilder.UserID = UserID;
                cnBuilder.Password = UserPassword;
                //cnBuilder.MinPoolSize = 10;
                //cnBuilder.MaxPoolSize = 100;
                //cnBuilder.IncrPoolSize = 3;
                //cnBuilder.DecrPoolSize = 1;
                //cnBuilder.ConnectionTimeout = 60;
                //cnBuilder.ConnectionLifeTime = 120;
                }

            return cnBuilder.ConnectionString;
            }

        /// <summary>
        /// close oracle connection
        /// </summary>
        /// <remarks></remarks>
        public static void Release() {
            Oracle.DataAccess.Client.OracleConnection.ClearAllPools();
            _instance.OracleConnection.Close();
            _instance.Dispose();
            }


        private bool disposedValue;
        // To detect redundant calls

        // IDisposable
        private void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: free managed resources when explicitly called
                    _oracleConnection.Dispose();

                    }
                }
            // TODO: free shared unmanaged resources
            disposedValue = true;
            }

        #region " IDisposable Support "
        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
            }
        #endregion


        
        }
    }
