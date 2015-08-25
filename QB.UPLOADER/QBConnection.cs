using Interop.QBFC12;
using System;
using System.Runtime.InteropServices;

namespace QBooksUploader
    {
    public class QBConnection : IDisposable
        {

        public  int StatusCode {
            get {
                return _response.StatusCode;
                }
            }

        public  string StatusMessage {
            get {
                return _response.StatusMessage;
                }
            }

        private QBSessionManager _sessionManager;
        public  QBSessionManager SessionManager {
            get { 
                return _sessionManager; }
            }

        private string _qBXMLVersion;
        public  string QBXMLVersion {
            get {
                return _qBXMLVersion;
                }
            }


        private IMsgSetRequest _requestSet;
        public  IMsgSetRequest RequestSet {
            get {
                return _requestSet;}
            }

        private IMsgSetResponse _responseSet;
        public  IMsgSetResponse ResponseSet {
            get {
                return _responseSet;
                }
            }

        private IResponseList _responseList;
        public IResponseList ResponseList {
            get {
                return _responseList;
                }
            }

        private IResponse _response ;
        public IResponse Response {
            get {
                return _response;
                }
            set {
                 _response =value;
                }
            }
        private Boolean booSessionBegun=false;

        public QBConnection() {

            try {

                // Create the session manager object using QBFC
                _sessionManager = new QBSessionManager();


                // Open the connection and begin a session to QuickBooks
                _sessionManager.OpenConnection("", "Quickbooks Transactions Uploader");
                _sessionManager.BeginSession("", ENOpenMode.omDontCare);

                booSessionBegun = true;

                _qBXMLVersion = Convert.ToString(QBFCLatestVersion(_sessionManager)) + ".0";


                // Get the RequestMsgSet based on the correct QB Version
                _requestSet = getLatestMsgSetRequest(_sessionManager);

                // Initialize the message set request object
                _requestSet.Attributes.OnError = ENRqOnError.roeContinue;

                }
            catch (COMException ex) {
                if (ex.ErrorCode == -2147220457) {
                    throw new Exception(ex.Message);
                    }
                else{
                    throw new Exception("QB Connection Failed "+  ex.ErrorCode,ex );
                    }
                }
            catch (Exception ex){
                throw ex;
                }
            }

        public void PerformRequest() {
                _responseSet = SessionManager.DoRequests(RequestSet);

                _responseList = _responseSet.ResponseList;


            }

        // Code for handling different versions of QuickBooks
        private double QBFCLatestVersion(QBSessionManager SessionManager) {
            // Use oldest version to ensure that this application work with any QuickBooks (US)
            IMsgSetRequest msgset = SessionManager.CreateMsgSetRequest("US", 1, 0);
            msgset.AppendHostQueryRq();
            IMsgSetResponse QueryResponse = SessionManager.DoRequests(msgset);
            //MessageBox.Show("Host query = " + msgset.ToXMLString());
            //SaveXML(msgset.ToXMLString());


            // The response list contains only one response,
            // which corresponds to our single HostQuery request
            IResponse response = QueryResponse.ResponseList.GetAt(0);

            // Please refer to QBFC Developers Guide for details on why 
            // "as" clause was used to link this derrived class to its base class
            IHostRet HostResponse = response.Detail as IHostRet;
            IBSTRList supportedVersions = HostResponse.SupportedQBXMLVersionList as IBSTRList;

            int i;
            double vers;
            double LastVers = 0;
            string svers = null;

            for (i = 0; i <= supportedVersions.Count - 1; i++) {
                svers = supportedVersions.GetAt(i);
                vers = Convert.ToDouble(svers);
                if (vers > LastVers) {
                    LastVers = vers;
                    }
                }
            return LastVers;
            }

        public IMsgSetRequest getLatestMsgSetRequest(QBSessionManager sessionManager) {
            // Find and adapt to supported version of QuickBooks
            double supportedVersion = QBFCLatestVersion(sessionManager);

            short qbXMLMajorVer = 0;
            short qbXMLMinorVer = 0;

            if (supportedVersion >= 6.0) {
                qbXMLMajorVer = 6;
                qbXMLMinorVer = 0;
                }
            else if (supportedVersion >= 5.0) {
                qbXMLMajorVer = 5;
                qbXMLMinorVer = 0;
                }
            else if (supportedVersion >= 4.0) {
                qbXMLMajorVer = 4;
                qbXMLMinorVer = 0;
                }
            else if (supportedVersion >= 3.0) {
                qbXMLMajorVer = 3;
                qbXMLMinorVer = 0;
                }
            else if (supportedVersion >= 2.0) {
                qbXMLMajorVer = 2;
                qbXMLMinorVer = 0;
                }
            else if (supportedVersion >= 1.1) {
                qbXMLMajorVer = 1;
                qbXMLMinorVer = 1;
                }
            else {
                qbXMLMajorVer = 1;
                qbXMLMinorVer = 0;
                }

            // Create the message set request object
            IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("US", qbXMLMajorVer, qbXMLMinorVer);
            return requestMsgSet;
            }



        #region IDisposable Members

        public void Dispose() {
            _sessionManager.EndSession();
            booSessionBegun = false;
            _sessionManager.CloseConnection();
            }

        #endregion
        }
    }
