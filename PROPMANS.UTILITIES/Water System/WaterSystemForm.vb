Imports ComponentFactory.Krypton.Toolkit
Imports BCL

Imports PROPMANS.BASE_MOD

Public Class WaterSystemForm
    Private _bloaded As Boolean ' = False

#Region "Form Instance"

    Private Shared aForm As WaterSystemForm

    Public Shared Function Instance() As WaterSystemForm

        If aForm Is Nothing Then
            aForm = New WaterSystemForm
        End If
        Return aForm

    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        aForm = Nothing

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

#End Region

#Region "Properties"
    Private ReadOnly Property MeterID() As String
        Get
            Return dgMeterList.CurrentRow.Cells("meter_id").Value.ToString
        End Get
    End Property

    Private ReadOnly Property UnitID() As String
        Get
            Return dgMeterList.CurrentRow.Cells("unit_id").Value.ToString
        End Get
    End Property

    Private ReadOnly Property MeterNumber() As String
        Get
            Return dgMeterList.CurrentRow.Cells("meter_number").Value.ToString
        End Get
    End Property

    Private ReadOnly Property UnitNumber() As String
        Get
            Return dgMeterList.CurrentRow.Cells("unit_number").Value.ToString
        End Get
    End Property

    Private ReadOnly Property UnitOwnerName() As String
        Get
            Return dgMeterList.CurrentRow.Cells("unit_owner").Value.ToString
        End Get
    End Property
#End Region

#Region "Form & Control Events"

    Private Sub WaterSystemForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchType.SelectedIndexChanged
        txtSearchvalue.SelectAll()
        txtSearchvalue.Focus()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtSearchvalue.Text = String.Empty
        txtSearchvalue.Focus()
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        If Common.HasValue(txtSearchvalue) Then
            Dim searchvalue As String = txtSearchvalue.Text.Trim

            _bloaded = False
            Select Case cboSearchType.SelectedIndex
                Case 0 ' search by Unit Number
                    dgMeterList.DataSource = WaterSystem.WaterMeter.GetMetersByUnitNumber(searchvalue)
                Case 1 ' search by Meter Number
                    dgMeterList.DataSource = WaterSystem.WaterMeter.GetMetersByMeterNumber(searchvalue)
            End Select

            _bloaded = True

            dgMeterList_SelectionChanged(Nothing, Nothing)
            UpdateLabelText()
        Else
            txtSearchvalue.Focus()
        End If
    End Sub

    Private Sub btnViewAllCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAllCustomer.Click
        _bloaded = False
        dgMeterList.DataSource = WaterSystem.WaterMeter.GetAllMeters

        _bloaded = True

        dgMeterList_SelectionChanged(Nothing, Nothing)
        UpdateLabelText()
    End Sub


    Private Sub btnNewMeter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewMeter.Click

        Using frm As New MetertReplacementForm(Me.MeterID)

            'set / pass some fields
            frm.UnitID = Me.UnitID
            frm.UnitNumber = Me.UnitNumber
            frm.UnitOwnerName = Me.UnitOwnerName

            Dim dialogResult As DialogResult = frm.ShowDialog(Me)
            If dialogResult = Windows.Forms.DialogResult.OK Then
                txtSearchvalue.Text = Me.UnitNumber
                btnSearchCustomer_Click(Nothing, Nothing)
            End If

        End Using

    End Sub

    Private Sub btnNewMeterReading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewMeterReading.Click
        Using frm As New NewMeterReadingForm(Me.MeterID)

            'set / pass some fields

            frm.UnitNumber = Me.UnitNumber
            frm.UnitOwnerName = Me.UnitOwnerName
            frm.MeterNumber = Me.MeterNumber


            Dim dialogResult As DialogResult = frm.ShowDialog(Me)
            If dialogResult = Windows.Forms.DialogResult.OK Then
                DisplayMeterReadingList()
            End If

        End Using
    End Sub

    Private Sub btnUpdateReading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateReading.Click
        Using frm As New NewMeterReadingForm(Me.MeterID, dgMeterReadingList.CurrentRow.Cells("reading_id").Value.ToString)

            'set / pass some fields
            frm.UnitNumber = Me.UnitNumber
            frm.UnitOwnerName = Me.UnitOwnerName
            frm.MeterNumber = Me.MeterNumber



            Dim dialogResult As DialogResult = frm.ShowDialog(Me)
            If dialogResult = Windows.Forms.DialogResult.OK Then
                DisplayMeterReadingList()
            End If

        End Using
    End Sub

    Private Sub btnMeterConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeterConnection.Click

        If btnMeterConnection.Text.ToUpper = "DISCONNECT" Then

            Using frm As New MeterDisconnectionForm(Me.MeterID)

                'set / pass some fields
                frm.UnitNumber = Me.UnitNumber
                frm.UnitOwnerName = Me.UnitOwnerName
                frm.MeterNumber = Me.MeterNumber

                Dim dialogResult As DialogResult = frm.ShowDialog(Me)
                If dialogResult = Windows.Forms.DialogResult.OK Then
                    txtSearchvalue.Text = Me.UnitNumber
                    btnSearchCustomer_Click(Nothing, Nothing)
                End If

            End Using
        Else

            Using frm As New MeterReconnectionForm(Me.MeterID)

                'set / pass some fields
                frm.UnitNumber = Me.UnitNumber
                frm.UnitOwnerName = Me.UnitOwnerName
                frm.MeterNumber = Me.MeterNumber

                Dim dialogResult As DialogResult = frm.ShowDialog(Me)
                If dialogResult = Windows.Forms.DialogResult.OK Then
                    txtSearchvalue.Text = Me.UnitNumber
                    btnSearchCustomer_Click(Nothing, Nothing)
                End If

            End Using
        End If


    End Sub

    Private Sub dgMeterList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgMeterList.CellFormatting
        If _bloaded Then
            If dgMeterList.Columns(e.ColumnIndex).Name = "connection_status" Then
                e.Value = WaterSystem.WaterMeter.GetConnectionStatusDescription(e.Value.ToString)
            End If
        End If
    End Sub

    Private Sub dgMeterList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMeterList.SelectionChanged
        If _bloaded Then
            If dgMeterList.RowCount > 0 Then

                lblAccountName.Text = UnitNumber & " : " & UnitOwnerName

                WaterSystemTabControl.Visible = True

                DisplayMeterInfo()

                DisplayMeterConnectionHistory()
                DisplayMeterReadingList()

                btnNewMeter.Enabled = Not WaterSystem.WaterMeter.IsUnitHasActiveMeter(Me.UnitID)

            Else
                lblAccountName.Text = String.Empty

                WaterSystemTabControl.Visible = False
            End If
        End If

    End Sub

    Private Sub dgMeterReadingList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgMeterReadingList.CellFormatting
        If _bloaded Then
            If dgMeterReadingList.Columns(e.ColumnIndex).Name = "reading_flag" Then
                e.Value = WaterSystem.WaterMeterReading.GetReadingFlagDescription(e.Value.ToString)
            End If
        End If
    End Sub

    Private Sub dgMeterReadingList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMeterReadingList.SelectionChanged
        If _bloaded Then
            Try
                With dgMeterReadingList.CurrentRow
                    Dim status As String = .Cells("reading_status").Value.ToString
                    Dim billed As String = .Cells("billed").Value.ToString
                    btnUpdateReading.Enabled = Not (.Cells("reading_status").Value.ToString.Equals("START") Or _
                        .Cells("reading_status").Value.ToString.Equals("DISC") Or _
                        .Cells("billed").Value.ToString = "Y")
                End With
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub dgMeterConnectionHistory_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgMeterConnectionHistory.CellFormatting
        If _bloaded Then
            If dgMeterConnectionHistory.Columns(e.ColumnIndex).Name = "connection_status" Then
                e.Value = WaterSystem.WaterMeter.GetConnectionStatusDescription(e.Value.ToString)
            End If
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        'set default search type
        cboSearchType.SelectedIndex = 0
        txtSearchvalue.CharacterCasing = CharacterCasing.Upper

        'set datagridview column display
        GridHelper.SetGridDisplay(dgMeterList, New MeterListGridDisplay)
        GridHelper.SetGridDisplay(dgMeterReadingList, New MeterReadingListGridDisplay)
        GridHelper.SetGridDisplay(dgMeterConnectionHistory, New MeterConnectionHistoryGridDisplay)

        lblAccountName.Text = String.Empty
        WaterSystemTabControl.Visible = False

        btnNewMeter.Enabled = False
    End Sub

    Private Sub UpdateLabelText()
        lblRecordCount.Refresh()

        lblRecordCount.Text = dgMeterReadingList.RowCount & " Record(s) Found"
    End Sub

    Private Sub DisplayMeterReadingList()
        _bloaded = False
        dgMeterReadingList.DataSource = WaterSystem.WaterMeterReading.GetMeterReadings(Me.MeterID)
        _bloaded = True

        dgMeterReadingList_SelectionChanged(Nothing, Nothing)

    End Sub

    Private Sub DisplayMeterConnectionHistory()
        _bloaded = False

        dgMeterConnectionHistory.DataSource = WaterSystem.WaterMeterConnectionHistory.GetConnectionHistory(Me.MeterID)

        _bloaded = True


    End Sub

    Private Sub DisplayMeterInfo()

        Common.ClearFields(MeterDetailsPanel)

        With WaterSystem.WaterMeter.GetMeterInfoByMeterID(MeterID)

            lblMeterNumber.Text = .MeterNumber
            lblInstallationDate.Text = .InstallationDate.ToString("MMMM dd, yyyy")
            lblStartReading.Text = .StartReading.ToString("###0.0000")

            lblInstalledBy.Text = .InstalledBy

            txtMeterRemarks.Text = .MeterRemarks

            lblConnectionStatus.Text = .ConnectionStatusDescription

            btnUpdateReading.Enabled = (.ConnectionStatus = WaterSystem.MeterConnectionStatus.ACT)
            btnNewMeterReading.Enabled = (.ConnectionStatus = WaterSystem.MeterConnectionStatus.ACT)

            Select Case .ConnectionStatus
                Case WaterSystem.MeterConnectionStatus.ACT
                    btnMeterConnection.Enabled = True
                    btnMeterConnection.Text = "DISCONNECT"

                    'TODO , make a helper for meter reconnection
                    'check if reconnected
                    Dim reconDate As Date
                    Dim lastconnstat As WaterSystem.MeterReadingStatus
                    If WaterSystem.WaterMeter.IsMeterReconnected(Me.MeterID, reconDate, lastconnstat) Then
                        If lastconnstat = WaterSystem.MeterReadingStatus.NORMAL Then
                            lblReconnectionRemarks.Visible = False
                        Else
                            Dim nextReading As Date = WaterSystem.WaterMeterReading.NextReadingDateAfterReconnection(reconDate)
                            lblReconnectionRemarks.Visible = True
                            lblReconnectionRemarks.Text = _
                            String.Format("METER WAS RECONNECTED LAST {0:MMMM dd, yyyy}. NEXT READING WILL BE ON {1:MMMM dd, yyyy}", reconDate, nextReading).ToUpper
                            btnNewMeterReading.Enabled = Not (nextReading > Now.Date)
                        End If
                    Else
                        lblReconnectionRemarks.Visible = False
                    End If

                Case WaterSystem.MeterConnectionStatus.TEMP, WaterSystem.MeterConnectionStatus.VOLM
                    btnMeterConnection.Enabled = True
                    btnMeterConnection.Text = "RECONNECT"
                Case Else
                    btnMeterConnection.Enabled = False
            End Select



        End With
    End Sub

#End Region

  
End Class
