Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.DataTable
Public Class FrmPenerimaanBarang
    Dim DTDetail As New DataTable
    Dim nKode As String = ""
    Private Sub FrmPenerimaanBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        LockAll()
        LockAllDetail()
        SimpleButton6.Enabled = False
        SimpleButton7.Enabled = False
        SimpleButton8.Enabled = False

        If nMENUMAIN = "PENERIMAAN BARANG" Then
            nKode = "TR1"
            TextEdit2.Text = 1
        ElseIf nMENUMAIN = "PENGELUARAN BARANG" Then
            nKode = "TR2"
            TextEdit2.Text = 2
        ElseIf nMENUMAIN = "MUTASI BARANG" Then
            nKode = "TR0"
            TextEdit2.Text = 0
        End If
        Me.Text = nMENUMAIN
        LabelControl21.Text = nMENUMAIN
        loadview()
        CreateDtDetail()

    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UnlockAll()

        SimpleButton6.Enabled = True
        SimpleButton7.Enabled = True
        SimpleButton8.Enabled = True
        LockAllDetail()

        TextEdit1.Text = GetTAG(nKode)
        TextEdit2.Text = "1"
        TextEdit1.Enabled = False
        TextEdit2.Enabled = False

        UnlockAllDetail()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        LockAll()
        LockAllDetail()
        SimpleButton6.Enabled = False
        SimpleButton7.Enabled = False
        SimpleButton8.Enabled = False
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Close()
    End Sub

    Private Sub loadview()
        SQL = "select TRSMG_C,TRSMG_T,REFF,NO_SJ,NO_FAK,NO_PO,TRSMG_DATE,TRANSPORTER_C,VENDOR_C,CUSTOMER_C,NO_VEHICLE,PENERIMA,PENGEIRIM,DEP_C from trsmg"
        FILLGridView(SQL, GridControl1)
    End Sub
    Private Sub LoadView1()

        'SQL = "select ITEM_C,QTY,UNIT,LOKASI,BATCH,TAGNO from trsmg_detail "
        'FILLGridView(SQL, GridControl2)


    End Sub
    Private Sub LockAll()
        TextEdit1.Text = ""
        TextEdit2.Text = ""
        TextEdit3.Text = ""
        TextEdit4.Text = ""
        TextEdit5.Text = ""
        TextEdit6.Text = ""
        DateEdit1.Text = ""
        TextEdit8.Text = ""
        TextEdit9.Text = ""
        TextEdit10.Text = ""
        TextEdit11.Text = ""
        TextEdit11.Text = ""
        TextEdit12.Text = ""
        TextEdit13.Text = ""
        TextEdit14.Text = ""
        TextEdit15.Text = ""
        TextEdit16.Text = ""
        ComboBoxEdit2.Text = ""
        TextEdit18.Text = ""
        TextEdit19.Text = ""
        TextEdit21.Text = ""
        TextEdit1.Enabled = False
        TextEdit2.Enabled = False
        TextEdit3.Enabled = False
        TextEdit4.Enabled = False
        TextEdit5.Enabled = False
        TextEdit6.Enabled = False
        DateEdit1.Enabled = False
        TextEdit8.Enabled = False
        TextEdit9.Enabled = False
        TextEdit10.Enabled = False
        TextEdit11.Enabled = False
        TextEdit11.Enabled = False
        TextEdit12.Enabled = False
        TextEdit13.Enabled = False
        TextEdit14.Enabled = False

        SimpleButton1.Enabled = True 'add
        SimpleButton2.Enabled = False 'save
        SimpleButton3.Enabled = False 'del


    End Sub

    Private Sub LockAllDetail()
        TextEdit21.Text = ""

        ComboBoxEdit1.Enabled = False
        TextEdit15.Enabled = False
        TextEdit16.Enabled = False
        ComboBoxEdit2.Enabled = False
        TextEdit18.Enabled = False
        TextEdit19.Enabled = False
        TextEdit21.Enabled = False

    End Sub
    Private Sub UnlockAll()
        TextEdit1.Enabled = True
        TextEdit2.Enabled = True
        TextEdit3.Enabled = True
        TextEdit4.Enabled = True
        TextEdit5.Enabled = True
        TextEdit6.Enabled = True
        DateEdit1.Enabled = True
        TextEdit8.Enabled = True
        TextEdit9.Enabled = True
        TextEdit10.Enabled = True
        TextEdit11.Enabled = True
        TextEdit11.Enabled = True
        TextEdit12.Enabled = True
        TextEdit13.Enabled = True
        TextEdit14.Enabled = True

        UnlockAllDetail()
    End Sub

    Private Sub UnlockAllDetail()
        ComboBoxEdit1.Enabled = True
        TextEdit15.Enabled = True
        TextEdit16.Enabled = True
        ComboBoxEdit2.Enabled = True
        TextEdit18.Enabled = True
        TextEdit19.Enabled = True
        TextEdit21.Enabled = True

        SimpleButton6.Enabled = True 'cancel detail
        SimpleButton7.Enabled = True 'save detail
        SimpleButton8.Enabled = True 'add detail

    End Sub

    Private Sub CreateDtDetail()
        '1. BUAT DT DULU YA DT NYA CUKUP 1 X SAAT LOAD
        DTDetail = New DataTable
        DTDetail.Columns.Add("TRSMG_C")
        DTDetail.Columns.Add("ITEM_C")
        DTDetail.Columns.Add("QTY")
        DTDetail.Columns.Add("UNIT")
        DTDetail.Columns.Add("LOKASI")
        DTDetail.Columns.Add("BATCH")
        DTDetail.Columns.Add("TAGNO")
        GridControl2.DataSource = DTDetail

    End Sub
    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        'ADD DT KE GRID DETAIL 
        TextEdit21.Text = "0000" : TextEdit21.Enabled = False
        If Not IsEmptyCombo({ComboBoxEdit1, ComboBoxEdit2}) Then
            If Not IsEmptyText({TextEdit15, TextEdit16, TextEdit18, TextEdit19}) Then
                Dim DRDA As DataRow = DTDetail.NewRow
                DRDA(0) = TextEdit1.Text  'trsmg
                DRDA(1) = TextEdit15.Text  'item
                DRDA(2) = TextEdit16.Text  'qty
                DRDA(3) = ComboBoxEdit2.Text  'unit
                DRDA(4) = TextEdit21.Text    'lokasi
                DRDA(5) = TextEdit18.Text  'batch
                DRDA(6) = TextEdit19.Text  'tagno
                DTDetail.Rows.Add(DRDA)
                GridControl2.DataSource = DTDetail
            End If
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        LockAllDetail()
        TextEdit15.Text = ""
        TextEdit16.Text = ""
        ComboBoxEdit2.Text = ""
        TextEdit18.Text = ""
        TextEdit19.Text = ""
        TextEdit21.Text = ""
        SimpleButton7.Text = "Save Detail"
        GridView2.ClearDocument()
    End Sub
    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.RowHandle < 0 Then
            SimpleButton1.Enabled = True 'add
            SimpleButton2.Enabled = False 'save
            SimpleButton3.Enabled = False 'delete
        Else
            SimpleButton1.Enabled = False 'add
            SimpleButton2.Enabled = True 'save
            SimpleButton3.Enabled = True 'delete


            SimpleButton2.Text = "Update" 'save
            TextEdit1.Text = GridView1.GetRowCellValue(e.RowHandle, "TRSMG_C").ToString() 'CODE
            TextEdit2.Text = GridView1.GetRowCellValue(e.RowHandle, "TRSMG_T").ToString() 'NAME
            TextEdit3.Text = GridView1.GetRowCellValue(e.RowHandle, "REFF").ToString() 'REFF
            TextEdit4.Text = GridView1.GetRowCellValue(e.RowHandle, "NO_SJ").ToString() 'SURATJALAN
            TextEdit5.Text = GridView1.GetRowCellValue(e.RowHandle, "NO_FAK").ToString() 'NO FAKTUR
            TextEdit6.Text = GridView1.GetRowCellValue(e.RowHandle, "NO_PO").ToString() 'NO PO
            DateEdit1.Text = GridView1.GetRowCellValue(e.RowHandle, "TRSMG_DATE").ToString() 'TGL MASUK
            TextEdit8.Text = GridView1.GetRowCellValue(e.RowHandle, "TRANSPORTER_C").ToString() 'TRANSPORTER CODE
            TextEdit9.Text = GridView1.GetRowCellValue(e.RowHandle, "VENDOR_C").ToString() 'VENDOR CODE
            TextEdit10.Text = GridView1.GetRowCellValue(e.RowHandle, "CUSTOMER_C").ToString() 'CUSTOMER CODE
            TextEdit11.Text = GridView1.GetRowCellValue(e.RowHandle, "NO_VEHICLE").ToString() 'NO KENDARAAN
            TextEdit12.Text = GridView1.GetRowCellValue(e.RowHandle, "PENERIMA").ToString() 'PENERIMA
            TextEdit13.Text = GridView1.GetRowCellValue(e.RowHandle, "PENGEIRIM").ToString() 'PENGIRIM
            TextEdit14.Text = GridView1.GetRowCellValue(e.RowHandle, "DEP_C").ToString() 'DEP CODE
            TextEdit1.Enabled = False
            UnlockAll()
            Dim TRSMG_C As String
            TRSMG_C = TextEdit1.Text
            SQL = "Select ITEM_C, QTY, UNIT, LOKASI, BATCH, TAGNO from trsmg_detail WHERE TRSMG_C = '" & TRSMG_C & "' "
            FILLGridView(SQL, GridControl2)

        End If
    End Sub
    Private Sub GridView2_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView2.RowCellClick
        If e.RowHandle < 0 Then
            SimpleButton8.Enabled = True 'add
            SimpleButton7.Enabled = False 'save
            SimpleButton6.Enabled = False 'delete
        Else
            SimpleButton8.Enabled = False 'add
            SimpleButton7.Enabled = True 'save
            SimpleButton6.Enabled = True 'delete

            SimpleButton7.Text = "Update Detail" 'save
            TextEdit15.Text = GridView2.GetRowCellValue(e.RowHandle, "ITEM_C").ToString() 'CODE
            TextEdit16.Text = GridView2.GetRowCellValue(e.RowHandle, "QTY").ToString() 'NAME
            ComboBoxEdit2.Text = GridView2.GetRowCellValue(e.RowHandle, "UNIT").ToString() 'REFF
            TextEdit18.Text = GridView2.GetRowCellValue(e.RowHandle, "BATCH").ToString() 'SURATJALAN
            TextEdit19.Text = GridView2.GetRowCellValue(e.RowHandle, "TAGNO").ToString() 'NO FAKTUR
            TextEdit21.Text = GridView2.GetRowCellValue(e.RowHandle, "LOKASI").ToString() 'TGL MASUK

            UnlockAllDetail()
        End If
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'save
        If Not IsEmptyText({TextEdit1, TextEdit2}) = True Then

            Dim TRSMG_C As String = TextEdit1.Text
            Dim TRSMG_T As String = TextEdit2.Text
            Dim REFF As String = TextEdit3.Text
            Dim NO_SJ As String = TextEdit4.Text
            Dim NO_FAK As String = TextEdit5.Text
            Dim NO_PO As String = TextEdit6.Text

            Dim TRSMG_DATE As String = DateEdit1.Text
            Dim TRANSPORTER_C As String = TextEdit8.Text
            Dim VENDOR_C As String = TextEdit9.Text
            Dim CUSTOMER_C As String = TextEdit10.Text
            Dim NO_VEHICLE As String = TextEdit11.Text
            Dim PENERIMA As String = TextEdit12.Text
            Dim PENGEIRIM As String = TextEdit13.Text
            Dim DEP_C As String = TextEdit14.Text

            'KALO GW INSERT DETAIL BARU  HEADER
            'gw insert header dulu baru detail
            'karna create trsmg_c nya dulu
            'YO GPP HEHE
            'GW EMAIL CONTOH ENTRY TRANSAKSI YA.. TINGGAL MODIF (SESUAIKAN TABEL FIELD NYA
            'DETAIL SAVE DARI GRID KE DB 
            'HEADER SAVE DARI TEXT INPUT KE DB
            'UDAH ADA CONTOH TGL HEHE 

            SQL = "SELECT * FROM trsmg WHERE VENDOR_C='" & TRSMG_C & "'"
            If CheckRecord(SQL) = 0 Then
                'INSERT
                SQL = "INSERT INTO TRSMG (TRSMG_C,TRSMG_T,REFF,NO_SJ,NO_FAK,NO_PO,TRSMG_DATE,TRANSPORTER_C,VENDOR_C,CUSTOMER_C,NO_VEHICLE,PENERIMA,PENGEIRIM,DEP_C) VALUES ('" & TRSMG_C & "','" & TRSMG_T & "','" & REFF & "','" & NO_SJ & "','" & NO_FAK & "','" & NO_PO & "','" & TRSMG_DATE & "','" & TRANSPORTER_C & "','" & VENDOR_C & "','" & CUSTOMER_C & "','" & NO_VEHICLE & "','" & PENERIMA & "','" & PENGEIRIM & "','" & DEP_C & "')"
                ExecuteNonQuery(SQL)
                loadview()
                SQL = "UPDATE M_CODE SET URUT = URUT+1 WHERE"
                MsgBox("SAVE SUCCESSFUL", vbInformation, "UNIT")
            Else
                'UPDATE
                If UCase(SimpleButton2.Text) = "UPDATE" Then
                    SQL = "UPDATE TRSMG SET TRSMG_T = '" & TRSMG_T & "',REFF = '" & REFF & "',NO_SJ = '" & NO_SJ & "',NO_FAK ='" & NO_FAK & "',NO_PO = '" & NO_PO & "',TRSMG_DATE = '" & TRSMG_DATE & "',TRANSPORTER_C = '" & TRANSPORTER_C & "',VENDOR_C = '" & VENDOR_C & "',CUSTOMER_C = '" & CUSTOMER_C & "',NO_VEHICLE = '" & NO_VEHICLE & "',PENERIMA ='" & PENERIMA & "',PENGEIRIM = '" & PENGEIRIM & "',DEP_C = '" & DEP_C & "' WHERE TRSMG_C = '" & TRSMG_C & "')"
                    ExecuteNonQuery(SQL)
                    loadview()
                    MsgBox("UPDATE SUCCESSFUL", vbInformation, "UNIT")
                End If
            End If
        End If
    End Sub


    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        'LUV ITEM
        'LSQL TAMBAHKAN DI MODULE SBG PUBLIC 
        If Not IsEmptyCombo({ComboBoxEdit1}) = True Then   'JENIS HARUS ADA
            LSQL = "SELECT DISTINCT ITEM_C,ITEM FROM M_ITEM WHERE JENIS='" & ComboBoxEdit1.Text & "' "  '' QUERY INI HARUS EXPIRE DATE TERDEKAT YANG MUNCUL SELAIN ITU TIDAK UNTUK PENGELUARAN
            LField = "ITEM"
            ValueLOV = ""
            TextEdit15.Text = FrmShowLOV(FrmLoV, LSQL, "ITEM_BARANG", "ITEM")  'text yang akan di isi
            'buat tagno
            TextEdit19.Text = GetTAG("AIM")
        End If
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        If TextEdit2.Text = 1 Then
            SQL = ""
            ShowReport("rptPermintaan", SQL, "TRIN")
        ElseIf TextEdit2.Text = 2 Then
            SQL = ""
            ShowReport("rptPengeluaran", SQL, "TROUT")
        ElseIf TextEdit2.Text = 0 Then
            SQL = ""
            ShowReport("rptMutasi", SQL, "TRMUTASI")
        End If
    End Sub
End Class
