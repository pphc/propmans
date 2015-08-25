'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: Connection Settings Form
'Module Description: 
'Date Created: 11/8/2013
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ExceptionHandler
Imports System.Configuration
Imports System.Collections

Public Class ConnectionSettingForm
    Public Property HostName As String
    Public Property HostPort As String
    Public Property ServiceName As String
    Public Property AppSchema As String

#Region "Form and Control Events"

    Private Sub ConnectionSettingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadSettings()
        UISetup()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateSettings()
        MessageBox.Show("Connection Settings Updated")
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


#End Region

#Region "Local Procedure"
    Private Sub LoadSettings()
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)


        Dim settings As KeyValueConfigurationCollection = config.AppSettings.Settings

        HostName = settings("Host").Value
        HostPort = settings("HostPort").Value
        ServiceName = settings("ServiceName").Value
        AppSchema = settings("AppSchema").Value

    End Sub

    Private Sub UpdateSettings()

        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        Dim settings As AppSettingsSection = config.AppSettings

        settings.Settings.Item("Host").Value = txtHostName.Text.Trim
        settings.Settings.Item("HostPort").Value = txtHostPort.Text.Trim
        settings.Settings.Item("ServiceName").Value = txtServiceName.Text.Trim
        settings.Settings.Item("AppSchema").Value = txtAppSchema.Text.Trim

        config.Save(ConfigurationSaveMode.Modified)

        ConfigurationManager.RefreshSection("appSettings")
    End Sub
    Private Sub UISetup()
        txtHostName.Text = HostName
        txtHostPort.Text = HostPort
        txtServiceName.Text = ServiceName
        txtAppSchema.Text = AppSchema
    End Sub

#End Region



End Class
