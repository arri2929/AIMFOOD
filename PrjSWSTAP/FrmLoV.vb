Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmLoV

    Private Sub FrmLoV_Load(sender As Object, e As EventArgs) Handles Me.Load
        ValueLoV = ""
        LabelControl1.Text = LHeader & " Information"
        LabelControl2.Text = LHeader & " Search "
        TextEdit1.Text = ""
        LoadView()


        If My.Settings.SAP = "Y" Then SimpleButton1.Enabled = False  'SAP tombol new disebel
    End Sub

    Private Sub LoadView()
        GridView1.Columns.Clear()
        SQL = LSQL
        FILLGridView(SQL, GridControl1)
    End Sub

    Private Sub Search()
        Dim nSQL As String = ""
        nSQL = "and UPPER(" & LField & ") like '%" & UCase(Trim(TextEdit1.Text)) & "%'"
        nSQL = SQL & nSQL
        FILLGridView(nSQL, GridControl1)
        If GridView1.RowCount.ToString = 0 Then MsgBox(LField & " Salah atau Masih Kosong..!! ", vbInformation, "Secure Weighbridge System")
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        On Error Resume Next
        If e.RowHandle < 0 Then
            Exit Sub
        Else
            ValueLoV = GridView1.GetRowCellValue(e.RowHandle, LField).ToString()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If ValueLoV = "" Then MsgBox("Data Belum di Pilih atau Masih Kosong..!! ", vbInformation, "Secure Weighbridge System")
        Close()
    End Sub

    Private Sub TextEdit1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEdit1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Search()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If TextEdit1.Text <> "" Then Search()
    End Sub
End Class