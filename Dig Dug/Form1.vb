
Imports System
Imports System.Drawing
Imports System.Drawing.Graphics


Public Class Form1
    Dim G As Graphics
    Dim picguy As New PictureBox
    Dim intguy As Integer
    Dim blntmr As Boolean
    Dim blnSm As Boolean
    Dim blnSt As Boolean
    Dim rDirt(30, 20) As Rectangle
    Dim bDirt(30, 20) As Boolean
    Dim picBadR(5, 5) As PictureBox
    Dim picBadG(5, 5) As PictureBox


    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If blnSm = False Then
            If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
                If blntmr = False Then
                    R()
                End If
                tmrRight.Start()

            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
                If blntmr = False Then
                    U()
                End If
                tmrUp.Start()
            ElseIf e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
                If blntmr = False Then
                    L()
                End If
                tmrLeft.Start()
            ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
                If blntmr = False Then
                    D()
                End If
                tmrDown.Start()
            ElseIf e.KeyCode = Keys.Space Then
                S()
                blnSm = True
            End If
            blnSm = True
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            tmrRight.Stop()
            blntmr = False
            blnSm = False
        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            tmrUp.Stop()
            blntmr = False
            blnSm = False
        ElseIf e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            tmrLeft.Stop()
            blntmr = False
            blnSm = False
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            tmrDown.Stop()
            blntmr = False
            blnSm = False
        ElseIf e.KeyCode = Keys.Space Then
            blnSm = False
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        G = Me.CreateGraphics

        tmrInitialize.Start()
        
        picguy.Visible = True
        picguy.Top = 300
        picguy.Width = 20
        picguy.Height = 20
        picguy.Left = 280
        Controls.Add(picguy)
        intguy = 1
        picguy.Image = My.Resources.Forward
        picguy.SizeMode = PictureBoxSizeMode.Zoom

        For intCount = 1 To 5
            For intCount1 = 1 To 5
                picBadR(intCount, intCount1) = New PictureBox
                Controls.Add(picBadR(intCount, intCount1))
                picBadG(intCount, intCount1) = New PictureBox
                Controls.Add(picBadG(intCount, intCount1))
            Next
            SpawnBad(1, intCount, "R")
        Next



        blntmr = False
        blnSm = False
        blnSt = False

    End Sub

    Private Sub tmrUp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUp.Tick
        U()
    End Sub

    Private Sub tmrLeft_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLeft.Tick
        L()
    End Sub

    Private Sub tmrRight_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRight.Tick
        R()
    End Sub

    Private Sub tmrDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDown.Tick
        D()
    End Sub

    Sub U()
        If blnSt = False Then
            If intguy = 1 Then
                picguy.Image = My.Resources.BackU
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardU
                intguy = 1
            End If
        Else
            If intguy = 1 Then
                picguy.Image = My.Resources.BackGU
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardGU
                intguy = 1
            End If
        End If
        If picguy.Location.Y <> 120 Then
            picguy.Top -= 20
            Moves()
        End If
    End Sub
    Sub D()
        If blnSt = False Then
            If intguy = 1 Then
                picguy.Image = My.Resources.BackD
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardD
                intguy = 1
            End If
        Else
            If intguy = 1 Then
                picguy.Image = My.Resources.BackGD
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardGD
                intguy = 1
            End If
        End If
        If picguy.Location.Y <> 540 Then
            picguy.Top += 20
            Moves()


        End If
    End Sub
    Sub L()
        If blnSt = False Then
            If intguy = 1 Then
                picguy.Image = My.Resources.BackL
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardL
                intguy = 1
            End If
        Else
            If intguy = 1 Then
                picguy.Image = My.Resources.BackGL
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardGL
                intguy = 1
            End If
        End If
        picguy.Left -= 20
        Moves()
    End Sub
    Sub R()
        If blnSt = False Then
            If intguy = 1 Then
                picguy.Image = My.Resources.Back
                intguy = 2
            Else
                picguy.Image = My.Resources.Forward
                intguy = 1
            End If
        Else
            If intguy = 1 Then
                picguy.Image = My.Resources.BackG
                intguy = 2
            Else
                picguy.Image = My.Resources.ForwardG
                intguy = 1
            End If
        End If
        picguy.Left += 20
        Moves()
    End Sub
    Sub S()
        blnSt = True
    End Sub
    Sub Moves()
        For intCount = 0 To 30
            For intCount1 = 0 To 20
                If bDirt(intCount, intCount1) = True Then
                    If picguy.Bounds.IntersectsWith(rDirt(intCount, intCount1)) Then
                        bDirt(intCount, intCount1) = False
                    Else
                        G.FillRectangle(Brushes.Brown, rDirt(intCount, intCount1))
                    End If
                End If
            Next
        Next
        blntmr = True
    End Sub

    Sub SpawnBad(ByVal intLevel As Integer, ByVal intNum As Integer, ByVal chrBad As Char)
        If intLevel = 1 Then
            If chrBad = "R" Then
                picBadR(1, intNum).Visible = True
                picBadR(1, intNum).Width = 20
                picBadR(1, intNum).Height = 20
                picBadR(1, intNum).Image = My.Resources.red
                picBadR(1, intNum).SizeMode = PictureBoxSizeMode.Zoom
                Select Case intNum
                    Case 1
                        picBadR(1, 1).Top = 300
                        picBadR(1, 1).Left = 100


                    Case 2
                        picBadR(1, 2).Top = 300
                        picBadR(1, 2).Left = 200


                    Case 3
                        picBadR(1, 3).Top = 380
                        picBadR(1, 3).Left = 300



                    Case 4
                        picBadR(1, 4).Top = 340
                        picBadR(1, 4).Left = 320

                    Case 5
                        picBadR(1, 5).Top = 280
                        picBadR(1, 5).Left = 480

                End Select
            End If
            End If

    End Sub

    Private Sub tmrInitialize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrInitialize.Tick
        For intCount = 0 To 30
            For intCount1 = 0 To 20
                rDirt(intCount, intCount1) = New Rectangle(intCount * 20, intCount1 * 20 + 140, 20, 20)
                bDirt(intCount, intCount1) = True
                G.FillRectangle(Brushes.Brown, rDirt(intCount, intCount1))
            Next
        Next
        For intCount = 13 To 15
            G.FillRectangle(Brushes.Black, rDirt(intCount, 8))
            bDirt(intCount, 8) = False
        Next

        tmrInitialize.Enabled = False



    End Sub

End Class
