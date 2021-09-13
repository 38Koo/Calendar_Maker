Public Class Form1
    Const word As String = "以下の日程でご都合いかがでしょうか？" + vbCrLf
    Dim Year As Integer
    Dim month As Integer
    Dim day As Integer
    Dim lastMonth As Integer　'今月最後の日付を格納
    Dim preLastMonth As Integer '先月最後の日付を格納

    ''デフォルトのセルスタイル
    'Private defaultCellStyle As DataGridViewCellStyle
    ''マウスポインタの下にあるセルのセルスタイル
    'Private mouseCellStyle As DataGridViewCellStyle

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dt As DateTime = DateTime.Now
            txtDate.Text = word
            txtDate.SelectionStart = word.Length + 1

            '今日日付の各要素取得
            Year = dt.Year
            month = dt.Month
            day = dt.Day

            '今日の年月表示
            lblDate.Text = Year.ToString + "/" + month.ToString

            'カレンダー作成
            getCalender()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#Region "関数"

#Region "カレンダー作成"
    Private Sub getCalender()
        Try
            Dim num As Integer = 1
            Dim memdt As New Date
            Dim row As Integer = 0
            Dim column As Integer
            Dim num2 As Integer = 1
            Dim preMonth As Integer
            'Dim style As New DataGridViewCellStyle

            'ヘッダテキスト配列
            Dim week As String() = {"日", "月", "火", "水", "木", "金", "土"}
            'ヘッダ名配列
            Dim weekNm As String() = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
            'dgv1にヘッダ追加、幅決定、Alignment指定
            For i As Integer = 0 To week.Length - 1
                dgv1.Columns.Add(weekNm(i), week(i))
                dgv1.Columns(i).Width = 75
                dgv1.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            '今はヘッダしかないのでとりあえず一行追加
            dgv1.Rows.Add()

            '今月最後の日付を取得
            lastMonth = DecLastMonth(month)

            '表示されている年月の一日を取得
            memdt = CDate(lblDate.Text + "/1")

            'Debug.WriteLine(Array.IndexOf(week, memdt.ToString("ddd")))

            '表示されている年月の一日が何曜日かを取得（カレンダーの始まる曜日を取得
            column = Array.IndexOf(week, memdt.ToString("ddd"))

            '先月最後の日付も取得する
            If column <> 0 Then
                preMonth = month
                If preMonth = 1 Then
                    preMonth = 12
                Else
                    preMonth -= 1
                End If
                preLastMonth = DecLastMonth(preMonth)
                'カレンダーが月曜日以降から始まる場合、先月の最後の方の日付も表示する
                For i As Integer = column - 1 To 0 Step -1
                    dgv1.Item(i, row).Value = preLastMonth
                    preLastMonth -= 1
                Next
            End If

            '表示されている年月のカレンダー作成
            For i As Integer = 1 To lastMonth
                dgv1.Item(column, row).Value = i

                If i <> lastMonth Then
                    If column = 6 Then
                        dgv1.Rows.Add()
                        column = 0
                        row += 1
                    Else
                        column += 1
                    End If
                End If
            Next

            'カレンダーが土曜日よりも前で終わった場合、来月の最初の方の日付も表示する
            If column <> 6 Then
                For i As Integer = column + 1 To 6
                    dgv1.Item(i, dgv1.Rows.Count - 1).Value = num2
                    num2 += 1
                Next
            End If

            '行の高さ設定
            For i As Integer = 0 To dgv1.Rows.Count - 1
                dgv1.Rows(i).Height = 75
            Next

            'dgv1の高さを設定
            dgv1.Height = 75 * dgv1.Rows.Count + 20

            '土曜日、日曜日に色付け、文字サイズ変更
            dgv1.Columns(0).DefaultCellStyle.ForeColor = Color.Red
            dgv1.Columns(6).DefaultCellStyle.ForeColor = Color.Blue
            dgv1.DefaultCellStyle.Font = New Font(“ＭＳ ゴシック”, 20)

            '先月分と来月分の文字色を薄くする
            For i As Integer = 0 To 6
                If dgv1.Item(i, 0).Value > 10 Then
                    Select Case i
                        Case 0
                            dgv1(i, 0).Style.ForeColor = Color.FromArgb(255, 128, 128)
                        Case Else
                            dgv1(i, 0).Style.ForeColor = Color.Silver
                    End Select
                End If

                If dgv1.Item(i, dgv1.Rows.Count - 1).Value < 10 Then
                    Select Case i
                        Case 6
                            dgv1(i, dgv1.Rows.Count - 1).Style.ForeColor = Color.FromArgb(128, 128, 255)
                        Case Else
                            dgv1(i, dgv1.Rows.Count - 1).Style.ForeColor = Color.Silver
                    End Select
                End If
            Next

            'ロード時のフォーカスを今日日付に充てたい
            'For i As Integer = 0 To dgv1.Rows.Count - 1
            '    For j As Integer = 0 To 6
            '        If dgv1.Item(j, i).Value = day Then
            '            If day > 20 AndAlso i <> 0 Then
            '                dgv1.CurrentCell = dgv1(j, i)
            '            End If
            '        End If
            '    Next
            'Next

            'Debug.WriteLine(dgv1.ColumnHeadersHeight)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#End Region

    Private Function DecLastMonth(month As Integer) As Integer
        Try
            '月によって最後の日付を取得
            Dim lastMonthDate As Integer
            Select Case month
                Case 1, 3, 5, 7, 8, 10, 12
                    lastMonthDate = 31
                Case 4, 6, 9, 11
                    lastMonthDate = 30
                Case 2
                    'うるう年も判定
                    If DateTime.IsLeapYear(Year) = True Then
                        lastMonthDate = 29
                    Else
                        lastMonthDate = 28
                    End If
            End Select

            Return lastMonthDate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            txtDate.Clear()
            txtDate.Text = word
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Clipboard.SetText(txtDate.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellClick
        Try
            Dim strText As String = txtDate.Text
            Dim dateText As String
            dateText = month.ToString + "月" + dgv1(e.ColumnIndex, e.RowIndex).Value.ToString + "日" _
                + "(" + dgv1.Columns(e.ColumnIndex).HeaderText + ")"

            strText += dateText

            txtDate.Text = strText

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            'dgv1をクリア
            dgv1.DataSource = Nothing
            dgv1.Rows.Clear()


            '先月の月を取得
            If month = 1 Then
                month = 12
                Year -= 1
            Else
                month -= 1
            End If

            '先月の年月表示
            lblDate.Text = Year.ToString + "/" + month.ToString

            'カレンダー作成
            getCalender()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            'dgv1をクリア
            dgv1.DataSource = Nothing
            dgv1.Rows.Clear()


            '来月の月を取得
            If month = 12 Then
                month = 1
                Year += 1
            Else
                month += 1
            End If

            '来月の年月表示
            lblDate.Text = Year.ToString + "/" + month.ToString

            'カレンダー作成
            getCalender()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            'dgv1をクリア
            dgv1.DataSource = Nothing
            dgv1.Rows.Clear()

            Dim dt As DateTime = DateTime.Now

            txtDate.Focus()

            '今日日付の各要素取得
            Year = dt.Year
            month = dt.Month
            day = dt.Day

            '今日の年月表示
            lblDate.Text = Year.ToString + "/" + month.ToString

            'カレンダー作成
            getCalender()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
