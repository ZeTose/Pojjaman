Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Imports System.IO
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Specialized
Imports Longkong.Pojjaman.Internal.Templates
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Text
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class NewFileDialog
        Inherits BasePojjamanForm
        Implements INewFileCreator

#Region "Members"
        Private m_allowUntitledFiles As Boolean
        Private m_alltemplates As ArrayList
        Private m_basePath As String
        Private m_categories As ArrayList
        Private m_createdFiles As StringCollection
        Private m_icons As Hashtable
        Private m_localizedTypeDescriptor As LocalizedTypeDescriptor
        Private m_propertyGrid As PropertyGrid

        Private Const GridMargin As Integer = 8
        Private Const GridWidth As Integer = 256
#End Region

#Region "Constructors"
        Public Sub New(ByVal basePath As String)
            Me.m_alltemplates = New ArrayList
            Me.m_categories = New ArrayList
            Me.m_icons = New Hashtable
            Me.m_createdFiles = New StringCollection
            Me.m_propertyGrid = New PropertyGrid
            Me.m_localizedTypeDescriptor = Nothing

            StandardHeader.SetHeaders()

            Me.m_basePath = basePath
            Me.m_allowUntitledFiles = (basePath Is Nothing OrElse basePath.Length = 0)
            Try
                Me.InitializeComponents()
                Me.InitializeTemplates()
                Me.InitializeView()
                CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).Select()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
#End Region

#Region "Methods"
        Private Sub CategoryChange(ByVal sender As Object, ByVal e As TreeViewEventArgs)
            Me.HidePropertyGrid()
            CType(MyBase.ControlDictionary.Item("templateListView"), ListView).Items.Clear()
            If (Not CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).SelectedNode Is Nothing) Then
                For Each item As TemplateItem In CType(CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).SelectedNode, Category).Templates
                    CType(MyBase.ControlDictionary.Item("templateListView"), ListView).Items.Add(item)
                Next
            End If
        End Sub
        Private Sub CheckedChange(ByVal sender As Object, ByVal e As EventArgs)
            CType(MyBase.ControlDictionary.Item("templateListView"), ListView).View = CType(IIf(CType(MyBase.ControlDictionary.Item("smallIconsRadioButton"), RadioButton).Checked, View.List, View.LargeIcon), View)
        End Sub
        Private Function GenerateCurrentFileName() As String
            If (Me.SelectedTemplate.DefaultName.IndexOf("${Number}") >= 0) Then
                Try
                    Dim suffix As Integer = 1
                    Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
Label_0037:
                    BasePojjamanForm.StringParserService.Properties("Number") = suffix.ToString
                    Dim fileName As String = BasePojjamanForm.StringParserService.Parse(Me.SelectedTemplate.DefaultName)
                    If Me.m_allowUntitledFiles Then
                        If myFileService.IsOpen(fileName) Then
                            GoTo Label_008E
                        End If
                        GoTo Label_009F
                    End If
                    If Not File.Exists(Path.Combine(Me.m_basePath, fileName)) Then
                        GoTo Label_009F
                    End If
Label_008E:
                    suffix += 1
                    GoTo Label_0037
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            End If
Label_009F:
            Return BasePojjamanForm.StringParserService.Parse(Me.SelectedTemplate.DefaultName)
        End Function
        Private Function GenerateValidClassName(ByVal className As String) As String
            Dim num1 As Integer = 0
            Do While (((num1 < className.Length) AndAlso (className.Chars(num1) <> "_"c)) AndAlso Not Char.IsLetter(className.Chars(num1)))
                num1 += 1
            Loop
            Dim builder1 As New StringBuilder
            Do While (num1 < className.Length)
                If (Char.IsLetterOrDigit(className.Chars(num1)) OrElse (className.Chars(num1) = "_"c)) Then
                    builder1.Append(className.Chars(num1))
                End If
                If ((className.Chars(num1) = " "c) OrElse (className.Chars(num1) = "-"c)) Then
                    builder1.Append("_"c)
                End If
                num1 += 1
            Loop
            Return builder1.ToString
        End Function
        Private Function GetCategory(ByVal categoryname As String) As Category
            For Each cat As Category In Me.m_categories
                If (cat.Name = categoryname) Then
                    Return cat
                End If
            Next
            Dim myCategory As New Category(categoryname)
            Me.m_categories.Add(myCategory)
            Return myCategory
        End Function
        Private Sub HidePropertyGrid()
            If MyBase.Controls.Contains(Me.m_propertyGrid) Then
                MyBase.SuspendLayout()
                MyBase.Controls.Remove(Me.m_propertyGrid)
                MyBase.Width = (MyBase.Width - 256)
                MyBase.ResumeLayout(False)
            End If
        End Sub
        Private Sub InitializeComponents()
            If Me.m_allowUntitledFiles Then
                MyBase.SetupFromXml(Path.Combine(BasePojjamanForm.PropertyService.DataDirectory, "resources\dialogs\NewFileDialog.xfrm"))
            Else
                MyBase.SetupFromXml(Path.Combine(BasePojjamanForm.PropertyService.DataDirectory, "resources\dialogs\NewFileWithNameDialog.xfrm"))
            End If
            Dim iml As New ImageList
            iml.ColorDepth = ColorDepth.Depth32Bit
            iml.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.16x16.OpenFolderBitmap"))
            iml.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.16x16.ClosedFolderBitmap"))
            CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).ImageList = iml
            AddHandler CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).AfterSelect, New TreeViewEventHandler(AddressOf Me.CategoryChange)
            AddHandler CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).BeforeSelect, New TreeViewCancelEventHandler(AddressOf Me.OnBeforeExpand)
            AddHandler CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).BeforeExpand, New TreeViewCancelEventHandler(AddressOf Me.OnBeforeExpand)
            AddHandler CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).BeforeCollapse, New TreeViewCancelEventHandler(AddressOf Me.OnBeforeCollapse)
            AddHandler CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SelectedIndexChanged, New EventHandler(AddressOf Me.SelectedIndexChange)
            AddHandler CType(MyBase.ControlDictionary.Item("templateListView"), ListView).DoubleClick, New EventHandler(AddressOf Me.OpenEvent)
            AddHandler MyBase.ControlDictionary.Item("openButton").Click, New EventHandler(AddressOf Me.OpenEvent)
            Dim service1 As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            CType(MyBase.ControlDictionary.Item("largeIconsRadioButton"), RadioButton).Checked = service1.GetProperty("Dialogs.NewProjectDialog.LargeImages", True)
            AddHandler CType(MyBase.ControlDictionary.Item("largeIconsRadioButton"), RadioButton).CheckedChanged, New EventHandler(AddressOf Me.CheckedChange)
            CType(MyBase.ControlDictionary.Item("largeIconsRadioButton"), RadioButton).FlatStyle = FlatStyle.Standard
            CType(MyBase.ControlDictionary.Item("largeIconsRadioButton"), RadioButton).Image = BasePojjamanForm.IconService.GetBitmap("Icons.16x16.LargeIconsIcon")
            CType(MyBase.ControlDictionary.Item("smallIconsRadioButton"), RadioButton).Checked = Not service1.GetProperty("Dialogs.NewProjectDialog.LargeImages", True)
            AddHandler CType(MyBase.ControlDictionary.Item("smallIconsRadioButton"), RadioButton).CheckedChanged, New EventHandler(AddressOf Me.CheckedChange)
            CType(MyBase.ControlDictionary.Item("smallIconsRadioButton"), RadioButton).FlatStyle = FlatStyle.Standard
            CType(MyBase.ControlDictionary.Item("smallIconsRadioButton"), RadioButton).Image = BasePojjamanForm.IconService.GetBitmap("Icons.16x16.SmallIconsIcon")
            Dim tip1 As New ToolTip
            tip1.SetToolTip(MyBase.ControlDictionary.Item("largeIconsRadioButton"), BasePojjamanForm.StringParserService.Parse("${res:Global.LargeIconToolTip}"))
            tip1.SetToolTip(MyBase.ControlDictionary.Item("smallIconsRadioButton"), BasePojjamanForm.StringParserService.Parse("${res:Global.SmallIconToolTip}"))
            tip1.Active = True
            MyBase.Owner = CType(WorkbenchSingleton.Workbench, Form)
            MyBase.StartPosition = FormStartPosition.CenterParent
            MyBase.Icon = Nothing
            Me.CheckedChange(Me, EventArgs.Empty)
        End Sub
        Private Sub InitializeTemplates()
            For Each template As FileTemplate In FileTemplate.FileTemplates
                Dim myTemplateItem As New TemplateItem(template)
                If (Not myTemplateItem.Template.Icon Is Nothing) Then
                    Me.m_icons.Item(myTemplateItem.Template.Icon) = 0
                End If
                If template.NewFileDialogVisible Then
                    Dim cat As Category = Me.GetCategory(myTemplateItem.Template.Category)
                    cat.Templates.Add(myTemplateItem)
                    If (Not cat.Selected AndAlso (template.WizardPath Is Nothing)) Then
                        cat.Selected = True
                    End If
                    If ((Not cat.HasSelectedTemplate AndAlso (myTemplateItem.Template.FileDescriptionTemplates.Count = 1)) AndAlso CType(myTemplateItem.Template.FileDescriptionTemplates.Item(0), FileDescriptionTemplate).Name.StartsWith("Empty")) Then
                        myTemplateItem.Selected = True
                        cat.HasSelectedTemplate = True
                    End If
                End If
                Me.m_alltemplates.Add(myTemplateItem)
            Next
        End Sub
        Private Sub InitializeView()
            Dim list1 As New ImageList
            Dim list2 As New ImageList
            list1.ColorDepth = ColorDepth.Depth32Bit
            list2.ColorDepth = ColorDepth.Depth32Bit
            list2.ImageSize = New Size(32, 32)
            list1.ImageSize = New Size(16, 16)
            list1.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.32x32.EmptyFileIcon"))
            list2.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.32x32.EmptyFileIcon"))
            Dim num1 As Integer = 0
            Dim hashtable1 As New Hashtable(Me.m_icons)
            Dim service1 As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            Dim entry1 As DictionaryEntry
            For Each entry1 In Me.m_icons
                Dim bitmap1 As Bitmap = service1.GetBitmap(entry1.Key.ToString)
                If (Not bitmap1 Is Nothing) Then
                    list1.Images.Add(bitmap1)
                    list2.Images.Add(bitmap1)
                    hashtable1.Item(entry1.Key) = ++num1
                Else
                    Console.WriteLine(("can't load bitmap " & entry1.Key.ToString & " using default"))
                End If
            Next
            Me.m_icons = hashtable1
            Dim item1 As TemplateItem
            For Each item1 In Me.m_alltemplates
                If (item1.Template.Icon Is Nothing) Then
                    item1.ImageIndex = 0
                Else
                    item1.ImageIndex = CType(Me.m_icons.Item(item1.Template.Icon), Integer)
                End If
            Next
            CType(MyBase.ControlDictionary.Item("templateListView"), ListView).LargeImageList = list2
            CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SmallImageList = list1
            Me.InsertCategories(Nothing, Me.m_categories)
            Dim service2 As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim num2 As Integer
            For num2 = 0 To Me.m_categories.Count - 1
                If (CType(Me.m_categories.Item(num2), Category).Name Is service2.GetProperty("Dialogs.NewFileDialog.LastSelectedCategory", "C#")) Then
                    CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).SelectedNode = CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).Nodes.Item(num2)
                    Return
                End If
            Next num2
        End Sub
        Private Sub InsertCategories(ByVal node As TreeNode, ByVal catarray As ArrayList)
            For Each cat As Category In catarray
                If (node Is Nothing) Then
                    CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).Nodes.Add(cat)
                Else
                    node.Nodes.Add(cat)
                End If
                Me.InsertCategories(cat, cat.Categories)
            Next
        End Sub
        Private Sub OnBeforeCollapse(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            e.Node.ImageIndex = 0
        End Sub
        Private Sub OnBeforeExpand(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            e.Node.ImageIndex = 1
        End Sub
        Private Sub OpenEvent(ByVal sender As Object, ByVal e As EventArgs)
            If (Not CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).SelectedNode Is Nothing) Then
                Dim service1 As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                service1.SetProperty("Dialogs.NewProjectDialog.LargeImages", CType(MyBase.ControlDictionary.Item("largeIconsRadioButton"), RadioButton).Checked)
                service1.SetProperty("Dialogs.NewFileDialog.LastSelectedCategory", CType(MyBase.ControlDictionary.Item("categoryTreeView"), TreeView).SelectedNode.Text)
            End If
            Me.m_createdFiles.Clear()
            If (CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SelectedItems.Count = 1) Then
                If Not Me.AllPropertiesHaveAValue Then
                    Dim service2 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    service2.ShowMessage("${res:Dialog.NewFile.FillOutFirstMessage}", "${res:Dialog.NewFile.FillOutFirstCaption}")
                Else
                    Dim fullFileName As String
                    Dim myTemplateItem As TemplateItem = CType(CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SelectedItems.Item(0), TemplateItem)
                    BasePojjamanForm.StringParserService.Properties.Item("StandardNamespace") = "DefaultNamespace"
                    If Me.m_allowUntitledFiles Then
                        fullFileName = Me.GenerateCurrentFileName
                    Else
                        'fullFileName = Path.Combine(Me.m_basePath, MyBase.ControlDictionary.Item("fileNameTextBox").Text)
                        'fullFileName = Path.GetFullPath(fullFileName)
                        'Dim service3 As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
                        'Dim project1 As Project = service3.CurrentSelectedProject
                        'If (Not project1 Is Nothing) Then
                        '    Dim service4 As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
                        '    Dim text2 As String = service4.AbsoluteToRelativePath(project1.BaseDirectory, Path.GetDirectoryName(fullFileName))
                        '    Dim chArray1 As Char() = New Char() {Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar}
                        '    Dim textArray1 As String() = text2.Split(chArray1)
                        '    Dim builder1 As New StringBuilder(project1.StandardNamespace)
                        '    Dim textArray2 As String() = textArray1
                        '    Dim num1 As Integer
                        '    For num1 = 0 To textArray2.Length - 1
                        '        Dim text3 As String = textArray2(num1)
                        '        If (((Not text3 Is ".") AndAlso (Not text3 Is "..")) AndAlso (Not text3 Is "")) Then
                        '            builder1.Append("."c)
                        '            builder1.Append(Me.GenerateValidClassName(text3))
                        '        End If
                        '    Next num1
                        '    BasePojjamanForm.StringParserService.Properties.Item("StandardNamespace") = builder1.ToString
                        'End If
                    End If
                    BasePojjamanForm.StringParserService.Properties.Item("FullName") = fullFileName
                    BasePojjamanForm.StringParserService.Properties.Item("FileName") = Path.GetFileName(fullFileName)
                    BasePojjamanForm.StringParserService.Properties.Item("FileNameWithoutExtension") = Path.GetFileNameWithoutExtension(fullFileName)
                    BasePojjamanForm.StringParserService.Properties.Item("Extension") = Path.GetExtension(fullFileName)
                    BasePojjamanForm.StringParserService.Properties.Item("Path") = Path.GetDirectoryName(fullFileName)
                    BasePojjamanForm.StringParserService.Properties.Item("ClassName") = Me.GenerateValidClassName(Path.GetFileNameWithoutExtension(fullFileName))
                    If (Not myTemplateItem.Template.WizardPath Is Nothing AndAlso myTemplateItem.Template.WizardPath.Length <> 0) Then
                        Dim properties1 As New DefaultProperties
                        properties1.SetProperty("Template", myTemplateItem.Template)
                        properties1.SetProperty("Creator", Me)
                        Dim dialog1 As New WizardDialog("File Wizard", properties1, myTemplateItem.Template.WizardPath)
                        If (dialog1.ShowDialog <> DialogResult.OK) Then
                            Return
                        End If
                        MyBase.DialogResult = DialogResult.OK
                    Else
                        Dim myScriptRunner As New ScriptRunner
                        Dim myFileDescriptionTemplate As FileDescriptionTemplate
                        For Each myFileDescriptionTemplate In myTemplateItem.Template.FileDescriptionTemplates
                            Me.SaveFile(myFileDescriptionTemplate.Name, myScriptRunner.CompileScript(myTemplateItem.Template, myFileDescriptionTemplate), myFileDescriptionTemplate.Language, True)
                        Next
                        MyBase.DialogResult = DialogResult.OK
                    End If
                End If
            End If
        End Sub
        Private Sub SelectedIndexChange(ByVal sender As Object, ByVal e As EventArgs)
            If (CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SelectedItems.Count = 1) Then
                MyBase.ControlDictionary.Item("descriptionLabel").Text = BasePojjamanForm.StringParserService.Parse(Me.SelectedTemplate.Description)
                MyBase.ControlDictionary.Item("openButton").Enabled = True
                If Me.SelectedTemplate.HasProperties Then
                    Me.ShowPropertyGrid()
                End If
                If Not Me.m_allowUntitledFiles Then
                    MyBase.ControlDictionary.Item("fileNameTextBox").Text = Me.GenerateCurrentFileName
                End If
            Else
                MyBase.ControlDictionary.Item("descriptionLabel").Text = String.Empty
                MyBase.ControlDictionary.Item("openButton").Enabled = False
                Me.HidePropertyGrid()
            End If
        End Sub
        Private Sub ShowPropertyGrid()
            If (Me.m_localizedTypeDescriptor Is Nothing) Then
                Me.m_localizedTypeDescriptor = New LocalizedTypeDescriptor
            End If
            If Not MyBase.Controls.Contains(Me.m_propertyGrid) Then
                MyBase.SuspendLayout()
                Me.m_propertyGrid.Location = New Point((MyBase.Width - 8), 8)
                Me.m_localizedTypeDescriptor.Properties.Clear()
                Dim myTemplateProperty As TemplateProperty
                For Each myTemplateProperty In Me.SelectedTemplate.Properties
                    Dim myLocalizedProperty As LocalizedProperty
                    If myTemplateProperty.Type.StartsWith("Types:") Then
                        myLocalizedProperty = New LocalizedProperty(myTemplateProperty.Name, "System.Enum", myTemplateProperty.Category, myTemplateProperty.Description)
                        Dim myTemplateType As TemplateType = Nothing
                        For Each theTemplateType As TemplateType In Me.SelectedTemplate.CustomTypes
                            If (theTemplateType.Name = myTemplateProperty.Type.Substring("Types:".Length)) Then
                                myTemplateType = theTemplateType
                                Exit For
                            End If
                        Next
                        If (myTemplateType Is Nothing) Then
                            Throw New Exception(("type : " & myTemplateProperty.Type & " not found."))
                        End If
                        myLocalizedProperty.TypeConverterObject = New CustomTypeConverter(myTemplateType)
                        BasePojjamanForm.StringParserService.Properties.Item(("Properties." & myLocalizedProperty.Name)) = myTemplateProperty.DefaultValue
                        myLocalizedProperty.DefaultValue = myTemplateProperty.DefaultValue
                    Else
                        myLocalizedProperty = New LocalizedProperty(myTemplateProperty.Name, myTemplateProperty.Type, myTemplateProperty.Category, myTemplateProperty.Description)
                        If (myTemplateProperty.Type = "System.Boolean") Then
                            myLocalizedProperty.TypeConverterObject = New BooleanTypeConverter
                            Dim text1 As String = CStr(IIf((myTemplateProperty.DefaultValue Is Nothing), Nothing, myTemplateProperty.DefaultValue.ToString))
                            If ((text1 Is Nothing) OrElse (text1.Length = 0)) Then
                                text1 = "True"
                            End If
                            BasePojjamanForm.StringParserService.Properties.Item(("Properties." & myLocalizedProperty.Name)) = text1
                            myLocalizedProperty.DefaultValue = Boolean.Parse(text1)
                        End If
                    End If
                    myLocalizedProperty.LocalizedName = myTemplateProperty.LocalizedName
                    Me.m_localizedTypeDescriptor.Properties.Add(myLocalizedProperty)
                Next
                Me.m_propertyGrid.ToolbarVisible = False
                Me.m_propertyGrid.SelectedObject = Me.m_localizedTypeDescriptor
                Me.m_propertyGrid.Size = New Size(256, (MyBase.Height - 32))
                MyBase.Width = (MyBase.Width + 256)
                MyBase.Controls.Add(Me.m_propertyGrid)
                MyBase.ResumeLayout(False)
            End If
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property SelectedTemplate() As FileTemplate
            Get
                If (CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SelectedItems.Count = 1) Then
                    Return CType(CType(MyBase.ControlDictionary.Item("templateListView"), ListView).SelectedItems.Item(0), TemplateItem).Template
                End If
                Return Nothing
            End Get
        End Property
        Private ReadOnly Property AllPropertiesHaveAValue() As Boolean
            Get
                For Each myProperty As TemplateProperty In Me.SelectedTemplate.Properties
                    Dim propertyName As String = BasePojjamanForm.StringParserService.Properties.Item(("Properties." & myProperty.Name))
                    If ((propertyName Is Nothing) OrElse (propertyName.Length = 0)) Then
                        Return False
                    End If
                Next
                Return True
            End Get
        End Property
        Public ReadOnly Property CreatedFiles() As StringCollection
            Get
                Return Me.m_createdFiles
            End Get
        End Property
#End Region

#Region "INewFileCreator"
        Public Function IsFilenameAvailable(ByVal fileName As String) As Boolean Implements INewFileCreator.IsFilenameAvailable
            Return True
        End Function
        Public Sub SaveFile(ByVal filename As String, ByVal content As String, ByVal languageName As String, ByVal showFile As Boolean) Implements INewFileCreator.SaveFile
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            Dim myFileName As String = BasePojjamanForm.StringParserService.Parse(filename)
            Me.m_createdFiles.Add(myFileName)
            myFileService.NewFile(myFileName, BasePojjamanForm.StringParserService.Parse(languageName), BasePojjamanForm.StringParserService.Parse(content))
            MyBase.DialogResult = DialogResult.OK
        End Sub
#End Region

#Region "Category"
        Friend Class Category
            Inherits TreeNode

#Region "Members"
            Public HasSelectedTemplate As Boolean
            Public Selected As Boolean

            Private m_categories As ArrayList
            Private m_name As String
            Private m_templates As ArrayList

            Private Shared m_stringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
#End Region

#Region "Constructors"
            Public Sub New(ByVal name As String)
                MyBase.New(Category.m_stringParserService.Parse(name))

                Me.Selected = False
                Me.HasSelectedTemplate = False

                Me.m_categories = New ArrayList
                Me.m_templates = New ArrayList
                Me.m_name = name

                MyBase.ImageIndex = 1
            End Sub
#End Region

#Region "Properties"
            Public ReadOnly Property Categories() As ArrayList
                Get
                    Return Me.m_categories
                End Get
            End Property
            Public ReadOnly Property Name() As String
                Get
                    Return Me.m_name
                End Get
            End Property
            Public ReadOnly Property Templates() As ArrayList
                Get
                    Return Me.m_templates
                End Get
            End Property
#End Region

        End Class
#End Region

#Region "TemplateItem"
        Private Class TemplateItem
            Inherits ListViewItem

#Region "Members"
            Private m_template As FileTemplate
#End Region

#Region "Constructors"
            Public Sub New(ByVal template As FileTemplate)
                MyBase.New(CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService).Parse(template.Name))
                Me.m_template = template
                MyBase.ImageIndex = 0
            End Sub
#End Region

#Region "Properties"
            Public ReadOnly Property Template() As FileTemplate
                Get
                    Return Me.m_template
                End Get
            End Property
#End Region

        End Class
#End Region

    End Class

End Namespace
