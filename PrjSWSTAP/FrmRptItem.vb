Public Class FrmRptItem
    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged
        LabelControl1.Visible = False
        ComboBoxEdit3.Visible = False

        ComboBoxEdit2.Text = ""
        ComboBoxEdit3.Text = ""

        GridView1.Columns.Clear()

        If ComboBoxEdit1.SelectedIndex = 0 Then
            LabelControl2.Text = "ITEM NAME"
            LabelControl1.Visible = True
            ComboBoxEdit3.Visible = True
            MJENIS()
            MITEM()
        ElseIf ComboBoxEdit1.SelectedIndex = 1 Then
            LabelControl2.Text = "CUSTOMER NAME"
            MCUSTOMER()
        ElseIf ComboBoxEdit1.SelectedIndex = 2 Then
            LabelControl2.Text = "VENDOR NAME"
            MVENDOR()
        ElseIf ComboBoxEdit1.SelectedIndex = 3 Then
            LabelControl2.Text = "TRANSPORTER NAME"
            MTRANSPORTER()
        End If
    End Sub

    Private Sub FrmRptItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "REPORT MASTER"
        LabelControl1.Visible = False
    End Sub

    Private Sub MJENIS()
        SQL = "SELECT DISTINCT JENIS FROM M_ITEM"
        FILLComboBoxEdit(SQL, 0, ComboBoxEdit3, False)
        ComboBoxEdit3.SelectedIndex = 0
    End Sub
    Private Sub MITEM()
        If ComboBoxEdit3.Text <> "" Then
            SQL = "SELECT DISTINCT ITEM FROM M_ITEM WHERE JENIS='" & ComboBoxEdit3.Text & "'"
            FILLComboBoxEdit(SQL, 0, ComboBoxEdit3, False)
            FILLGridView(SQL, GridControl1)
            GridView1.BestFitColumns()
        Else
            SQL = "SELECT DISTINCT ITEM FROM M_ITEM"
            FILLComboBoxEdit(SQL, 0, ComboBoxEdit2, False)
            FILLGridView(SQL, GridControl1)
            GridView1.BestFitColumns()
        End If
    End Sub

    Private Sub MVENDOR()
        SQL = "Select VENDOR_N FROM M_VENDOR"
        FILLComboBoxEdit(SQL, 0, ComboBoxEdit2, False)
        FILLGridView(SQL, GridControl1)
        GridView1.BestFitColumns()
    End Sub

    Private Sub MTRANSPORTER()
        SQL = "Select TRANSPORTER_N FROM M_TRANSPORTER"
        FILLComboBoxEdit(SQL, 0, ComboBoxEdit2, False)
        FILLGridView(SQL, GridControl1)
        GridView1.BestFitColumns()
    End Sub

    Private Sub MCUSTOMER()
        SQL = "Select CUSTOMER_N FROM M_CUSTOMER"
        FILLComboBoxEdit(SQL, 0, ComboBoxEdit2, False)
        FILLGridView(SQL, GridControl1)
        GridView1.BestFitColumns()
    End Sub

    Private Sub ComboBoxEdit3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit3.SelectedIndexChanged
        MITEM()
    End Sub
End Class