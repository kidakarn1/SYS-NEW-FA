Public Class Chang_Loss
	Public G_loss_cd As String = ""
	Private Sub Button1_Click(sender As Object, e As EventArgs)
		Time_Loss.Show()
		Me.Close()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Working_Pro.Enabled = True
		Me.Close()
	End Sub

	Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
		Dim sel_cd As Integer = ListView2.SelectedIndices(0)
		Dim line_id As String = MainFrm.line_id.Text
		Try
			If My.Computer.Network.Ping("192.168.161.101") Then
				Try
					If My.Computer.Network.Ping("192.168.161.101") Then
						Backoffice_model.line_status_upd(line_id)
						Backoffice_model.line_status_upd_sqlite(line_id)
					Else
						Backoffice_model.line_status_upd_sqlite(line_id)
					End If
				Catch ex As Exception
					Backoffice_model.line_status_upd_sqlite(line_id)
				End Try
				Dim date_st As String = DateTime.Now.ToString("yyyy/MM/dd H:m:s")
				Dim date_end As String = DateTime.Now.ToString("yyyy/MM/dd H:m:s")
				Try
					If My.Computer.Network.Ping("192.168.161.101") Then
						Backoffice_model.line_status_ins(line_id, date_st, date_end, "1", "0", ListView2.Items(sel_cd).SubItems(0).Text, "0", Prd_detail.lb_wi.Text)
						Backoffice_model.line_status_ins_sqlite(line_id, date_st, date_end, "1", "0", ListView2.Items(sel_cd).SubItems(0).Text, "0", Prd_detail.lb_wi.Text)
					Else
						Backoffice_model.line_status_ins_sqlite(line_id, date_st, date_end, "1", "0", ListView2.Items(sel_cd).SubItems(0).Text, "0", Prd_detail.lb_wi.Text)
					End If
				Catch ex As Exception
					Backoffice_model.line_status_ins_sqlite(line_id, date_st, date_end, "1", "0", ListView2.Items(sel_cd).SubItems(0).Text, "0", Prd_detail.lb_wi.Text)
				End Try
				Loss_reg.loss_cd.Text = ListView2.Items(sel_cd).SubItems(0).Text
				G_loss_cd = ListView2.Items(sel_cd).SubItems(0).Text
				Loss_reg.Label7.Text = ListView2.Items(sel_cd).SubItems(1).Text
				Loss_reg.TextBox1.Text = ListView2.Items(sel_cd).SubItems(2).Text
				'MsgBox(ListView2.Items(sel_cd).Text)
				'MsgBox(ListBox1.Items(sel_cd))
				Loss_reg.Label2.Text = MainFrm.Label4.Text
				If ListBox1.Items(sel_cd) = 1 Then
					Dim LoadSQL
					Try
						If My.Computer.Network.Ping("192.168.161.101") Then
							LoadSQL = Backoffice_model.get_loss_op_mst(MainFrm.Label4.Text)
						Else
							LoadSQL = Backoffice_model.get_loss_op_mst_sqlite(MainFrm.Label4.Text)
						End If
					Catch ex As Exception
						LoadSQL = Backoffice_model.get_loss_op_mst_sqlite(MainFrm.Label4.Text)
					End Try
					Dim numm As Integer = 0
					While LoadSQL.Read()
						'Loss_reg.ComboBox1.Items.Add("Proc :" & LoadSQL("process_no").ToString() & " [" & LoadSQL("sk_name").ToString() & "]")
						'MsgBox(LoadSQL("process_no").ToString())
						'MsgBox(LoadSQL("sk_name").ToString())
						Loss_reg.ComboBox1.Items.Insert(numm, "Proc :" & LoadSQL("process_no").ToString() & "     [ " & LoadSQL("sk_name").ToString() & " ]")
						Loss_reg.ListBox1.Items.Add(LoadSQL("sk_id"))
						numm = numm + 1
					End While
					Loss_reg.ComboBox1.Visible = True
					Loss_reg.Label10.Visible = True
					Loss_reg.ComboBox1.SelectedIndex = 0
				End If
				'Loss_reg.lb_line_cd.Text = MainFrm.Label4.Text
				'Loss_reg.Label2.Text = MainFrm.Label4.Text
				Loss_reg.Label8.Text = TimeOfDay.ToString("H:mm:ss")
				'Working_Pro.Enabled = True
				Dim pd As String = MainFrm.Label6.Text
				Dim sel_combo As String = 0 'ComboBox1.SelectedIndex
				Dim wi_plan As String = Working_Pro.wi_no.Text
				Dim line_cd As String = MainFrm.Label4.Text
				Dim item_cd As String = Working_Pro.Label3.Text
				Dim seq_no As Integer = Working_Pro.Label22.Text
				Dim shift_prd As String = Working_Pro.Label14.Text
				Dim start_loss As Date = Date.Parse(TimeOfDay.ToString("H:mm:ss"))

				Dim end_loss As Date = Date.Parse(TimeOfDay.ToString("H:mm:ss"))
				Dim date1 As Date = Date.Parse(TimeOfDay.ToString("H:mm:ss"))
				Dim date2 As Date = Date.Parse(TimeOfDay.ToString("H:mm:ss"))
				Dim total_loss As Integer = DateDiff(DateInterval.Minute, date1, date2)
				Dim loss_type As String = "0"  '0:Normally,1:Manual
				Dim loss_cd_id As String = G_loss_cd
				Dim op_id As String
				If sel_combo < 0 Then
					op_id = "0"
				Else
					op_id = ListBox1.Items(sel_combo).ToString()
				End If
				Loss_reg.date_start_data = Date.Parse(TimeOfDay.ToString("H:mm:ss"))
				Try
					If My.Computer.Network.Ping("192.168.161.101") Then
						transfer_flg = "1"
						Backoffice_model.ins_loss_act(pd, line_cd, wi_plan, item_cd, seq_no, shift_prd, start_loss, end_loss, total_loss, loss_type, loss_cd_id, op_id, transfer_flg, "0")
						Backoffice_model.ins_loss_act_sqlite(pd, line_cd, wi_plan, item_cd, seq_no, shift_prd, start_loss, end_loss, total_loss, loss_type, loss_cd_id, op_id, transfer_flg, "0")
					Else
						transfer_flg = "0"
						Backoffice_model.ins_loss_act_sqlite(pd, line_cd, wi_plan, item_cd, seq_no, shift_prd, start_loss, end_loss, total_loss, loss_type, loss_cd_id, op_id, transfer_flg, "0")
					End If
				Catch ex As Exception
					transfer_flg = "0"
					Backoffice_model.ins_loss_act_sqlite(pd, line_cd, wi_plan, item_cd, seq_no, shift_prd, start_loss, end_loss, total_loss, loss_type, loss_cd_id, op_id, transfer_flg, "0")
				End Try
				Loss_reg.Show()
				Me.Close()
			End If
		Catch ex As Exception
			load_show.Show()
		End Try
	End Sub

	Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

		If ListView2.SelectedItems.Count <= 0 Then
			Button1.Enabled = False
			ListView2.ForeColor = Color.White
		ElseIf ListView2.SelectedItems.Count > 0 Then
			Button1.Enabled = True
			ListView2.ForeColor = Color.White
		End If
	End Sub

	Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

	End Sub

	Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

	End Sub

	Private Sub Chang_Loss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ListView2.Items(0).Selected = True
	End Sub
End Class
