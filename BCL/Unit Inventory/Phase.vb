Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common
Namespace UnitInventory

    Public Class Phase

#Region "PROPERTIES"

        Private _phaseId As String

        Public Property PhaseId() As String
            Get
                Return _phaseId
            End Get
            Set(ByVal Value As String)
                _phaseId = Value
            End Set
        End Property

        Private _phaseName As String

        Public Property PhaseName() As String
            Get
                Return _phaseName
            End Get
            Set(ByVal Value As String)
                _phaseName = Value
            End Set
        End Property

        Private _phaseNumber As String

        Public Property PhaseNumber() As String
            Get
                Return _phaseNumber
            End Get
            Set(ByVal Value As String)
                _phaseNumber = Value
            End Set
        End Property

        Private _phaseRemarks As String

        Public Property PhaseRemarks() As String
            Get
                Return _phaseRemarks
            End Get
            Set(ByVal Value As String)
                _phaseRemarks = Value
            End Set
        End Property

#End Region

        Public Shared Function GetPhase() As DataTable

            Dim query As String = "SELECT PHASE_ID                          " & _
                                  "     , PHASE_NAME                        " & _
                                  "     , PHASE_NUMBER                      " & _
                                  "     , REMARKS                           " & _
                                  "FROM AM_PHASE                            " & _
                                  "ORDER BY TO_NUMBER(PHASE_NUMBER) ASC     "

            Return OraDBHelper2.GetResultSet(query)

        End Function

    End Class

End Namespace