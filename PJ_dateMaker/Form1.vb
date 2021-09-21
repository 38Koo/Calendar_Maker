Public Class Form1

#Region "定数"
    Const c_word As String = "以下の日程でご都合いかがでしょうか？" + vbCrLf
#End Region

#Region "変数"
    ''' <summary>
    ''' システム日付の年
    ''' </summary>
    Private m_Year As Integer

    ''' <summary>
    ''' システム日付の月
    ''' </summary>
    Private m_Month As Integer

    ''' <summary>
    ''' システム日付の日
    ''' </summary>
    Private m_Day As Integer

    ''' <summary>
    ''' 今月最後の日付を格納
    ''' </summary>
    Private m_LastDay_Month As Integer

    ''' <summary>
    ''' 先月最後の日付を格納
    ''' </summary>
    Private m_LastDay_LastMonth As Integer
#End Region

#Region "列挙体"
    ''' <summary>
    ''' 曜日///日曜日始まり
    ''' </summary>
    Enum enumDayOfWeek
        Sunday = 0
        Monday
        Tuesday
        Wednesday
        Thursday
        Friday
        Saturday
    End Enum

    ''' <summary>
    ''' 月
    ''' </summary>
    Enum enumMonths
        January = 1
        February
        March
        April
        May
        June
        July
        August
        September
        October
        November
        December
    End Enum
#End Region

    ''デフォルトのセルスタイル
    'Private defaultCellStyle As DataGridViewCellStyle
    ''マウスポインタの下にあるセルのセルスタイル
    'Private mouseCellStyle As DataGridViewCellStyle

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dt As DateTime = DateTime.Now
            txtDate.Text = c_word
            txtDate.SelectionStart = c_word.Length + 1

            'システム日付の各要素取得
            m_Year = dt.Year
            m_Month = dt.Month
            m_Day = dt.Day

            '今日の年月表示
            lblDate.Text = m_Year.ToString + "/" + m_Month.ToString

            'カレンダー作成
            getCalender()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "関数"

#Region "カレンダー作成"
    ''' <summary>
    ''' カレンダー作成
    ''' </summary>
    Private Sub getCalender()
        Try
            Dim intDayOfWeek_LastDay As Integer
            Dim intDayOfWeek_1st As Integer
            Dim intPreMonth As Integer
            Dim intCountWeek As Integer
            Dim intRow As Integer = 0

            'ヘッダテキスト配列
            Dim arrWeek As String() = {"日", "月", "火", "水", "木", "金", "土"}
            'ヘッダ名配列
            Dim arrWeekNm As String() = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
            'dgvCalendarにヘッダ追加、幅決定、Alignment指定
            For i As Integer = 0 To arrWeek.Length - 1
                dgvCalendar.Columns.Add(arrWeekNm(i), arrWeek(i))
                dgvCalendar.Columns(i).Width = 75
                dgvCalendar.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            '今はヘッダしかないのでとりあえず一行追加
            dgvCalendar.Rows.Add()

            '今月最後の日付を取得
            m_LastDay_Month = getLastDayOfMonth(m_Month)
            intDayOfWeek_LastDay = Array.IndexOf(arrWeek, CDate(lblDate.Text + $"/{m_LastDay_Month}").ToString("ddd"))

            '表示されている年月の一日が何曜日かを取得（カレンダーの始まる曜日を取得）
            intDayOfWeek_1st = Array.IndexOf(arrWeek, CDate(lblDate.Text + "/1").ToString("ddd"))

            '日曜日始まりでない場合、前月の後ろの日付を表示する必要がある
            If intDayOfWeek_1st <> enumDayOfWeek.Sunday Then

                '先月最後の日付も取得する///1月の場合は先月は12月
                intPreMonth = If(m_Month = enumMonths.January, enumMonths.December, m_Month - 1)
                m_LastDay_LastMonth = getLastDayOfMonth(intPreMonth)

                'カレンダーが月曜日以降から始まる場合、先月の最後の方の日付も表示する
                For i As Integer = intDayOfWeek_1st - 1 To enumDayOfWeek.Sunday Step -1
                    '日曜日（左端の列）まで前月の最終日から-1ずつ減らして表示する
                    dgvCalendar.Item(i, intRow).Value = m_LastDay_LastMonth
                    m_LastDay_LastMonth -= 1
                Next
            End If

            intCountWeek = intDayOfWeek_1st
            '表示されている年月のカレンダー作成
            For i As Integer = 1 To m_LastDay_Month
                '日にち表示
                dgvCalendar.Item(intCountWeek, intRow).Value = i

                If i <> m_LastDay_Month Then
                    If intCountWeek = enumDayOfWeek.Saturday Then
                        '最終日じゃないかつ土曜日の場合、行数追加
                        dgvCalendar.Rows.Add()
                        '日曜日に戻す
                        intCountWeek = enumDayOfWeek.Sunday
                        intRow += 1
                    Else
                        intCountWeek += 1
                    End If
                End If
            Next

            'カレンダーが土曜日よりも前で終わった場合、来月の最初の方の日付も表示する
            If intCountWeek <> enumDayOfWeek.Saturday Then
                For i As Integer = intCountWeek + 1 To enumDayOfWeek.Saturday
                    '土曜日になるまで1から加算して表示する///i - intCountWeek = （1から加算された数）
                    dgvCalendar.Item(i, dgvCalendar.Rows.Count - 1).Value = i - intCountWeek
                Next
            End If

            '行の高さ設定
            For i As Integer = 0 To dgvCalendar.Rows.Count - 1
                dgvCalendar.Rows(i).Height = 75
            Next

            'dgvCalendarの高さを設定
            dgvCalendar.Height = 75 * dgvCalendar.Rows.Count + 20

            '土曜日、日曜日に色付け、文字サイズ変更
            dgvCalendar.Columns(enumDayOfWeek.Sunday).DefaultCellStyle.ForeColor = Color.Red
            dgvCalendar.Columns(enumDayOfWeek.Saturday).DefaultCellStyle.ForeColor = Color.Blue
            dgvCalendar.DefaultCellStyle.Font = New Font(“ＭＳ ゴシック”, 20)

            '先月分と来月分の文字色を薄くする
            For i As Integer = enumDayOfWeek.Sunday To enumDayOfWeek.Saturday
                '先月分
                '1行の月初めの曜日よりも左側にある日付の色変更
                If i < intDayOfWeek_1st Then
                    '日曜日は別の色に色変更
                    dgvCalendar(i, 0).Style.ForeColor = If(i = enumDayOfWeek.Sunday, Color.FromArgb(255, 128, 128), Color.Silver)
                End If

                '翌月分
                '最終行の月最終日の曜日よりも右側にある日付の色変更
                If i > intDayOfWeek_LastDay Then
                    '土曜日は別の色に色変更
                    dgvCalendar(i, dgvCalendar.Rows.Count - 1).Style.ForeColor = If(i = enumDayOfWeek.Saturday, Color.FromArgb(128, 128, 255), Color.Silver)
                End If
            Next

            'ロード時のフォーカスを今日日付に充てたい
            'For i As Integer = 0 To dgvCalendar.Rows.Count - 1
            '    For j As Integer = 0 To 6
            '        If dgvCalendar.Item(j, i).Value = m_Day Then
            '            If m_Day > 20 AndAlso i <> 0 Then
            '                dgvCalendar.CurrentCell = dgvCalendar(j, i)
            '            End If
            '        End If
            '    Next
            'Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "最終日取得関数"
    ''' <summary>
    ''' 引数で与えられた月の最終日を返す関数
    ''' </summary>
    ''' <param name="intMonth"></param>
    ''' <returns></returns>
    Private Function getLastDayOfMonth(intMonth As Integer) As Integer
        Try
            '月によって最後の日付を取得
            Dim intLastDayOfMaonth As Integer
            Select Case intMonth
                Case 1, 3, 5, 7, 8, 10, 12
                    intLastDayOfMaonth = 31
                Case 4, 6, 9, 11
                    intLastDayOfMaonth = 30
                Case 2
                    'うるう年も判定
                    If DateTime.IsLeapYear(m_Year) = True Then
                        intLastDayOfMaonth = 29
                    Else
                        intLastDayOfMaonth = 28
                    End If
            End Select

            Return intLastDayOfMaonth
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "クリアボタン"
    ''' <summary>
    ''' クリア処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtDate.Clear()
            txtDate.Text = c_word
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "コピーボタン"
    ''' <summary>
    ''' コピー処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            Clipboard.SetText(txtDate.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "日付押下処理"
    ''' <summary>
    ''' 日付押下時にテキストボックスに押された日付を表示する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvCalendar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCalendar.CellClick
        Try
            Dim strText As String = txtDate.Text
            Dim strDate As String

            strDate = $"{m_Month.ToString}月{dgvCalendar(e.ColumnIndex, e.RowIndex).Value.ToString}日({dgvCalendar.Columns(e.ColumnIndex).HeaderText})"


            strText += strDate

            txtDate.Text = strText

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "前月ボタン押下処理"
    ''' <summary>
    ''' 前月ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLastMonth_Click(sender As Object, e As EventArgs) Handles btnLastMonth.Click
        Try
            'dgvCalendarをクリア
            dgvCalendar.DataSource = Nothing
            dgvCalendar.Rows.Clear()

            '前月の月を取得
            If m_Month = enumMonths.January Then
                m_Month = enumMonths.December
                m_Year -= 1
            Else
                m_Month -= 1
            End If

            '先月の年月表示
            lblDate.Text = $"{m_Year.ToString}/{m_Month.ToString}"

            'カレンダー作成
            getCalender()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "翌月ボタン押下処理"
    ''' <summary>
    ''' 翌月ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        Try
            'dgvCalendarをクリア
            dgvCalendar.DataSource = Nothing
            dgvCalendar.Rows.Clear()

            '来月の月を取得
            If m_Month = enumMonths.December Then
                m_Month = enumMonths.January
                m_Year += 1
            Else
                m_Month += 1
            End If

            '来月の年月表示
            lblDate.Text = $"{m_Year.ToString}/{m_Month.ToString}"

            'カレンダー作成
            getCalender()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "日付リセットボタン押下処理"
    ''' <summary>
    ''' 日付リセットボタン押下処理
    ''' 現在時刻のカレンダーを表示する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        Try
            'dgvCalendarをクリア
            dgvCalendar.DataSource = Nothing
            dgvCalendar.Rows.Clear()

            Dim dt As DateTime = DateTime.Now

            txtDate.Focus()

            '今日日付の各要素取得
            m_Year = dt.Year
            m_Month = dt.Month
            m_Day = dt.Day

            '今日の年月表示
            lblDate.Text = $"{m_Year.ToString}/{m_Month.ToString}"

            'カレンダー作成
            getCalender()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#End Region
End Class
