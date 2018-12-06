Public Class Form1
    Dim vowels As String() = {"a", "e", "i", "o", "u"}
    Private Sub ButtonTranslate_Click(sender As Object, e As EventArgs) Handles ButtonTranslate.Click
        TextBox2.Clear()
        If (TextBox1.Text IsNot "") Then
            TextBox2.Text = EngToPig(TextBox1.Text)
        End If
    End Sub

    Function EngToPig(EngText As String)    '"Main" translator "controller"  ¯\_(ツ)_/¯
        EngText = EngText.Trim(" ") 'Sometimes it broke when there were spaces at the end of the string. This fixes that apprently

        Dim PigText As String = ""
        Dim EngWords As String() = EngText.Split(" ")
        Dim PigWords As String() = EngWords.ToArray
        Dim FirstChars As String() = EngWords.ToArray

        For i As Int16 = 0 To EngWords.Length - 1
            FirstChars(i) = EngWords(i).First                                               'gets the first chars of every word 
            PigWords(i) = PigWords(i).Remove(0, 1)                                          'remove first character
            PigWords(i) = EndOfWord(PigWords(i).Insert(0, FirstChars(i)), FirstChars(i))    'add it to the end (with all the weird rules)
            PigWords(i) = PunctuationFix(PigWords(i))                                       'fix the punctuation 
            PigWords(i) = PigWords(i).ToLower                                               'Makes everything lowercase so it doesn't look super weird.
        Next


        PigWords = Capitalization(PigWords)         'Capitalizes the beginning of each sentence.

        For i As Int16 = 0 To EngWords.Length - 1
            PigText += (PigWords(i) + " ")          'create final text (with spaces)
        Next



        Return PigText
    End Function

    '/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\/\/\/\BUTTONS/\/\/\'
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/\/\/\/FUNCTIONS\/\/\/''

    Function PigToEng(PigText As String)        'Potentially to do, but more than likely not

        Return 1
    End Function
    Function EndOfWord(MainWord As String, FirstChar As String) 'Decides how to end the word to make it pig latin
        FirstChar = FirstChar.ToLower
        Dim allchars() As Char = MainWord.ToCharArray
        Try
            If vowels.Contains(FirstChar) Then              'For words that begin with vowel sounds, one just adds "way" or "yay" to the end(egg to eggway)
                MainWord += "way"
            ElseIf IsNumeric(MainWord) Then             'Does nothing, because numbers shouldn't change

            ElseIf Not vowels.Contains(FirstChar) And Not vowels.Contains(allchars(1)) Then 'When words begin with consonant clusters, the whole sound is added to the end(string to ingstray)
                MainWord = IsConsonant(MainWord)
                MainWord += "ay"
            Else

                MainWord = MainWord.Remove(0, 1)
                MainWord += FirstChar + "ay"
            End If
        Catch ex As Exception
            MainWord = MainWord.Insert(0, FirstChar)
            Return MainWord
        End Try


        Return MainWord
    End Function

    Function PunctuationFix(Word As String) 'Makes sure punctuation isn't in the middle of words
        Dim ch As Char
        Dim n As Int16 = Word.Length - 1

        For i As Int16 = 0 To n
            ch = Word.Chars(i)
            If ch = "'" Then

            ElseIf Char.IsPunctuation(ch) Then
                Word = Word.Remove(i, 1)
                Word = (PunctuationFix(Word))   'recursion with 'Word without ch' to find more punctuation and put them at the end too

                Word += ch
            End If
        Next

        Return Word
    End Function

    Function IsConsonant(word As String)
        Dim count As Int16 = 0
        Dim front As String = ""
        If word.Length > 3 Then
            For i As Int16 = 0 To 2 'Looks for a general consonant cluster, ie: "str" or "pr" or "dr". Nothing longer than 4 characters
                If vowels.Contains(word.ToLower.Chars(i)) Then
                    Exit For
                Else
                    count += 1
                    front += word.Substring(i, 1)
                End If
            Next
        End If

        If count > 0 Then
            word = word.Replace(front, "")  'if theres a consonant, then it places the front in the back.
            word += front
        End If


        Return word
    End Function

    Function Capitalization(words As String())         'Makes sure to captialize only the first letters of the sentences. 
        Dim first As String = words(0).Substring(0, 1).ToUpper
        words(0) = words(0).Substring(1, words(0).Length - 1)
        words(0) = words(0).Insert(0, first)

        For i As Int16 = 0 To words.Length - 2
            If words(i).Contains(".") Or words(i).Contains("!") Or words(i).Contains("?") Then
                Dim secondfirst As String = words(i + 1).Substring(0, 1).ToUpper
                words(i + 1) = words(i + 1).Substring(1, words(i + 1).Length - 1)
                words(i + 1) = words(i + 1).Insert(0, secondfirst)
            End If
        Next



        Return words
    End Function


    '/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\/\/\/\FUNCTIONS/\/\/\'
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/\/\/\/MENUSTRIP\/\/\/'


    'FILE TOOLS
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim filename As String
        Dim reader As String

        fd.Title = "Select File"
        fd.InitialDirectory = "C:\Users\"
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            filename = fd.FileName
            reader = IO.File.ReadAllText(filename)

            TextBox1.Text = reader
        End If
    End Sub

    Private Sub MostOfTheMenuStrip(sender As Object, e As EventArgs) Handles GaramondToolStripMenuItem.Click, DefaultToolStripMenuItem1.Click, ArialToolStripMenuItem.Click, TimesNewRomanToolStripMenuItem.Click, WingdingsToolStripMenuItem.Click, ComicSansToolStripMenuItem.Click, UndoToolStripMenuItem.Click, RedoToolStripMenuItem.Click, NewToolStripMenuItem.Click, QuitToolStripMenuItem.Click, ContactToolStripMenuItem.Click, InstructionsToolStripMenuItem.Click, SelectAllToolStripMenuItem.Click, DeleteToolStripMenuItem.Click, PasteToolStripMenuItem.Click, CopyToolStripMenuItem.Click, CutToolStripMenuItem.Click
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Select Case item.Name

            'EDIT BUTTONS
            Case "CutToolStripMenuItem"
                If Me.ActiveControl Is TextBox1 Then
                    Clipboard.SetText(TextBox1.SelectedText)
                    TextBox1.SelectedText = ""
                ElseIf Me.ActiveControl Is TextBox2 Then
                    Clipboard.SetText(TextBox2.SelectedText)
                    TextBox2.SelectedText = ""
                End If
            Case "CopyToolStripMenuItem"
                If Me.ActiveControl Is TextBox1 Then
                    Clipboard.SetText(TextBox1.SelectedText)
                ElseIf Me.ActiveControl Is TextBox2 Then
                    Clipboard.SetText(TextBox2.SelectedText)
                End If
            Case "PasteToolStripMenuItem"
                Dim selectstart As Int16 = 0
                If Me.ActiveControl Is TextBox1 Then
                    selectstart = TextBox1.SelectionStart
                    TextBox1.SelectedText = ""
                    TextBox1.Text = TextBox1.Text.Insert(TextBox1.SelectionStart, Clipboard.GetText)
                    TextBox1.SelectionStart = selectstart + Clipboard.GetText.Length
                ElseIf Me.ActiveControl Is TextBox2 Then
                    selectstart = TextBox2.SelectionStart
                    TextBox2.SelectedText = ""
                    TextBox2.Text = TextBox2.Text.Insert(TextBox2.SelectionStart, Clipboard.GetText)
                    TextBox2.SelectionStart = selectstart + Clipboard.GetText.Length
                End If
            Case "DeleteToolStripMenuItem"
                If Me.ActiveControl Is TextBox1 Then
                    TextBox1.SelectedText = ""
                ElseIf Me.ActiveControl Is TextBox2 Then
                    TextBox2.SelectedText = ""
                End If
            Case "SelectAllToolStripMenuItem"
                If Me.ActiveControl Is TextBox1 Then
                    TextBox1.SelectAll()
                ElseIf Me.ActiveControl Is TextBox2 Then
                    TextBox2.SelectAll()
                End If

            'FILE BUTTONS
            Case "QuitToolStripMenuItem"
                End
            Case "NewToolStripMenuItem"
                TextBox1.Clear()
                TextBox2.Clear()

            'HELP BUTTONS
            Case "InstructionsToolStripMenuItem"
                MessageBox.Show("1. Type a sentence into the box on the left.
2. Press the button below to translate it into Pig Latin.

-Alternatively, open a text file by going to File - Open.", "Instructions")
            Case "ContactToolStripMenuItem"
                MessageBox.Show("Send an email to: randja@my.easternct.edu or jocsona@my.easternct.edu")

            'FONT BUTTONS
            Case "TimesNewRomanToolStripMenuItem"
                TextBox1.Font = New Font("Times New Roman", TextBox1.Font.Size, TextBox1.Font.Style)
                TextBox2.Font = New Font("Times New Roman", TextBox1.Font.Size, TextBox1.Font.Style)
            Case "WingdingsToolStripMenuItem"
                TextBox1.Font = New Font("Wingdings", TextBox1.Font.Size, TextBox1.Font.Style)
                TextBox2.Font = New Font("Wingdings", TextBox1.Font.Size, TextBox1.Font.Style)
            Case "ComicSansToolStripMenuItem"
                TextBox1.Font = New Font("Comic Sans MS", TextBox1.Font.Size, TextBox1.Font.Style)
                TextBox2.Font = New Font("Comic Sans MS", TextBox1.Font.Size, TextBox1.Font.Style)
            Case "ArialToolStripMenuItem"
                TextBox1.Font = New Font("Arial", TextBox1.Font.Size, TextBox1.Font.Style)
                TextBox2.Font = New Font("Arial", TextBox1.Font.Size, TextBox1.Font.Style)
            Case "DefaultToolStripMenuItem1"
                TextBox1.Font = New Font("Microsoft Sans Serif", TextBox1.Font.Size, TextBox1.Font.Style)
                TextBox2.Font = New Font("Microsoft Sans Serif", TextBox1.Font.Size, TextBox1.Font.Style)
            Case "GaramondToolStripMenuItem"
                TextBox1.Font = New Font("Garamond", TextBox1.Font.Size, TextBox1.Font.Style)
                TextBox2.Font = New Font("Garamond", TextBox1.Font.Size, TextBox1.Font.Style)
            Case "RedoToolStripMenuItem"
                'TODO
            Case "UndoToolStripMenuItem"
                'TODO
        End Select

    End Sub


    Private Sub ThemeColorButtons(sender As Object, e As EventArgs) Handles MoodyToolStripMenuItem.Click, DarkToolStripMenuItem.Click, DefaultToolStripMenuItem.Click, OtherToolStripMenuItem.Click
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim colorTextboxBack, color1, colorFormBack, colorMenuStrip, colorButtonBack, colorButtonBorder, colorBaseColors, colorTextColors As New Color

        'THEMES
        Select Case item.Name
            Case "MoodyToolStripMenuItem"
                colorTextboxBack = Color.FromArgb(57, 63, 77)
                colorFormBack = Color.FromArgb(29, 30, 34)
                colorMenuStrip = Color.FromArgb(30, 31, 35)
                colorButtonBack = Color.FromArgb(254, 218, 106)
                colorButtonBorder = Color.FromArgb(226, 233, 241)
                colorBaseColors = Color.White
                TextBox1.BorderStyle = BorderStyle.Fixed3D
                TextBox2.BorderStyle = BorderStyle.Fixed3D

            Case "OtherToolStripMenuItem"
                colorTextboxBack = Color.FromArgb(110, 211, 207)
                colorFormBack = Color.FromArgb(225, 232, 240)
                colorMenuStrip = Color.FromArgb(226, 233, 241)
                colorButtonBack = Color.FromArgb(144, 104, 190)
                colorButtonBorder = Color.FromArgb(226, 233, 241)
                colorBaseColors = Color.Black
                TextBox1.BorderStyle = BorderStyle.Fixed3D
                TextBox2.BorderStyle = BorderStyle.Fixed3D

            Case "DarkToolStripMenuItem"
                colorTextboxBack = Color.FromArgb(66, 66, 66)
                colorFormBack = Color.FromArgb(48, 48, 48)
                colorMenuStrip = Color.FromArgb(30, 31, 35)
                colorButtonBack = Color.FromArgb(68, 68, 68)
                colorButtonBorder = Color.FromArgb(68, 68, 68)
                colorBaseColors = Color.White
                TextBox1.BorderStyle = BorderStyle.None
                TextBox2.BorderStyle = BorderStyle.None

            Case "DefaultToolStripMenuItem"
                colorTextboxBack = Color.White
                colorFormBack = Color.FromArgb(240, 240, 240)
                colorMenuStrip = Color.FromArgb(241, 241, 241)
                colorButtonBack = Color.FromArgb(225, 225, 225)
                colorButtonBorder = Color.FromArgb(226, 233, 241)
                colorBaseColors = Color.Black
                TextBox1.BorderStyle = BorderStyle.Fixed3D
                TextBox2.BorderStyle = BorderStyle.Fixed3D

        End Select

        TextBox1.BackColor = colorTextboxBack
        TextBox2.BackColor = colorTextboxBack
        TextBox1.ForeColor = colorBaseColors
        TextBox2.ForeColor = colorBaseColors
        TextBox1.BorderStyle = BorderStyle.Fixed3D
        TextBox2.BorderStyle = BorderStyle.Fixed3D

        MenuStrip1.ForeColor = colorBaseColors
        Label1.ForeColor = colorBaseColors
        Label2.ForeColor = colorBaseColors


        Me.BackColor = colorFormBack
        MenuStrip1.BackColor = colorMenuStrip

        ButtonTranslate.BackColor = colorButtonBack
        ButtonTranslate.ForeColor = colorBaseColors
        ButtonTranslate.FlatAppearance.BorderColor = colorButtonBorder
    End Sub

    Private Sub FontSizeToolStripMenuItem_Click(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles FontSizeToolStripMenuItem.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If IsNumeric(FontSizeToolStripMenuItem.Text) Then
                Dim fontsize As Int16 = TextBox1.Font.Size
                If FontSizeToolStripMenuItem.Text > 0 And FontSizeToolStripMenuItem.Text <= 100 Then
                    fontsize = FontSizeToolStripMenuItem.Text
                    Dim font As New Font(TextBox1.Font.FontFamily, fontsize, TextBox1.Font.Style)
                    TextBox1.Font = font
                    TextBox2.Font = font
                ElseIf FontSizeToolStripMenuItem.Text > 100 Then
                    MessageBox.Show("Font too large")
                    FontSizeToolStripMenuItem.Text = fontsize
                Else
                    MessageBox.Show("Font too small")
                    FontSizeToolStripMenuItem.Text = fontsize
                End If
            Else
                MessageBox.Show("Inapplicable as font size")
            End If
        End If

    End Sub
End Class
