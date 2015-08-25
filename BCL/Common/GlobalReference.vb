
Namespace Common


    Public NotInheritable Class GlobalReference
        Private Shared _instance As GlobalReference

        Public Shared ReadOnly Property Instance() As GlobalReference
            Get
                If _instance Is Nothing Then
                    Throw New Exception("Class not Initalized")
                Else
                    Return _instance
                End If
            End Get
        End Property

        Public Shared ReadOnly Property UnitStat() As UnitStats
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.UnitStatInfo
                End If
            End Get
        End Property

        Public Shared ReadOnly Property Project() As Project
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.ProjectInfo
                End If
            End Get
        End Property

        Public Shared ReadOnly Property Fee() As Fees
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.FeeInfo
                End If
            End Get
        End Property

        Public Shared ReadOnly Property FeeSchedule() As FeeSchedule
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.FeeScheduleInfo
                End If
            End Get
        End Property

        Public Shared ReadOnly Property CustomerAccount() As CustomerAccount
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.CustAccountInfo
                End If
            End Get
        End Property

        Public Shared ReadOnly Property CustomerAccountDataAccess() As CustomerAccountDataAccess
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.CustAccountDA
                End If
            End Get
        End Property

        Public Shared ReadOnly Property AccountDataAccess() As Accounts.AccountsDA
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.AccountDA
                End If
            End Get
        End Property

        Public Shared ReadOnly Property ProjectParameters() As ProjectParameter
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.ProjectParams
                End If
            End Get
        End Property

        Public Shared ReadOnly Property CurrentUser() As SystemUser
            Get
                If _instance Is Nothing Then
                    Throw New Exception("GlobalReference class not Initalized")
                Else
                    Return _instance.CurrentUserInfo
                End If
            End Get
        End Property


        Private _feeInfo As Fees
        Public Property FeeInfo() As Fees
            Get
                Return _feeInfo
            End Get
            Set(ByVal value As Fees)
                _feeInfo = value
            End Set
        End Property


        Private _feeScheduleInfo As FeeSchedule
        Public Property FeeScheduleInfo() As FeeSchedule
            Get
                Return _feeScheduleInfo
            End Get
            Set(ByVal value As FeeSchedule)
                _feeScheduleInfo = value
            End Set
        End Property

        Private _projectInfo As Project
        Public Property ProjectInfo() As Project
            Get
                Return _projectInfo
            End Get
            Set(ByVal value As Project)
                _projectInfo = value
            End Set
        End Property


        Private _custAccountInfo As CustomerAccount
        Public Property CustAccountInfo() As CustomerAccount
            Get
                Return _custAccountInfo
            End Get
            Set(ByVal value As CustomerAccount)
                _custAccountInfo = value
            End Set
        End Property

        Private _custAccountDA As CustomerAccountDataAccess
        Public Property CustAccountDA() As CustomerAccountDataAccess
            Get
                Return _custAccountDA
            End Get
            Set(ByVal value As CustomerAccountDataAccess)
                _custAccountDA = value
            End Set
        End Property

        Public Property AccountDA As Accounts.AccountsDA

        Private _unitStatInfo As UnitStats
        Public Property UnitStatInfo() As UnitStats
            Get
                Return _unitStatInfo
            End Get
            Set(ByVal value As UnitStats)
                _unitStatInfo = value
            End Set
        End Property

        Private _projectParams As ProjectParameter
        Public Property ProjectParams() As ProjectParameter
            Get
                Return _projectParams
            End Get
            Set(ByVal value As ProjectParameter)
                _projectParams = value
            End Set
        End Property

        Private _currentUserInfo As SystemUser
        Public Property CurrentUserInfo As SystemUser
            Get
                Return _currentUserInfo
            End Get
            Set(value As SystemUser)
                _currentUserInfo = value
            End Set
        End Property

        Private Sub New(userID As String)
            FeeInfo = New Fees
            FeeScheduleInfo = New FeeSchedule
            CustAccountInfo = New CustomerAccount
            CustAccountDA = New CustomerAccountDataAccess
            AccountDA = New Accounts.AccountsDA
            UnitStatInfo = New UnitStats
            ProjectParams = New ProjectParameter
            CurrentUserInfo = New SystemUser(userID)
            ' ProjectInfo = New Project
        End Sub

        Public Shared Sub InitializeInstance(userID As String)
            _instance = New GlobalReference(userID)
        End Sub

    End Class



End Namespace
