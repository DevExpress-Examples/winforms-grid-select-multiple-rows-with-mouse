Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.Handler
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace DXApplication3

    <ToolboxItem(True)>
    Public Class CustomGrid
        Inherits GridControl

        Protected Overrides Function CreateDefaultView() As BaseView
            Return CreateView("CustomGridView")
        End Function

        Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
            MyBase.RegisterAvailableViewsCore(collection)
            collection.Add(New CustomGridViewInfoRegistrator())
        End Sub
    End Class

    Public Class CustomGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Overrides ReadOnly Property ViewName As String
            Get
                Return "CustomGridView"
            End Get
        End Property

        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New CustomGridView(grid)
        End Function

        Public Overrides Function CreateHandler(ByVal view As BaseView) As BaseViewHandler
            Return New CustomGridViewHandler(TryCast(view, CustomGridView))
        End Function
    End Class

    Public Class CustomGridView
        Inherits GridView

        Public Overridable ReadOnly Property IsRowSelect As Boolean
            Get
                Return IsMultiSelect AndAlso OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal grid As GridControl)
            MyBase.New(grid)
        End Sub

        Protected Overrides ReadOnly Property ViewName As String
            Get
                Return "CustomGridView"
            End Get
        End Property

        Friend Overloads Sub StartAccessSelection()
            MyBase.StartAccessSelection()
        End Sub

        Public Overrides Function GetShowEditorMode() As EditorShowMode
            If OptionsBehavior.EditorShowMode = EditorShowMode.Default AndAlso IsRowSelect Then Return EditorShowMode.Click
            Return MyBase.GetShowEditorMode()
        End Function
    End Class

    Public Class CustomGridViewHandler
        Inherits Views.Grid.Handler.GridHandler

        Private mouseDownHitInfo As GridHitInfo

        Public Overloads ReadOnly Property View As CustomGridView
            Get
                Return TryCast(MyBase.View, CustomGridView)
            End Get
        End Property

        Public Sub New(ByVal view As GridView)
            MyBase.New(view)
        End Sub

        Protected Overrides Function OnMouseDown(ByVal ev As MouseEventArgs) As Boolean
            Dim result = MyBase.OnMouseDown(ev)
            If ev.Button = MouseButtons.Left AndAlso Control.ModifierKeys = Keys.None AndAlso View.IsRowSelect AndAlso DownPointHitInfo.InRowCell Then
                mouseDownHitInfo = DownPointHitInfo
            Else
                mouseDownHitInfo = Nothing
            End If

            Return result
        End Function

        Protected Overrides Function OnMouseMove(ByVal ev As MouseEventArgs) As Boolean
            Dim result = MyBase.OnMouseMove(ev)
            If Not result AndAlso ev.Button = MouseButtons.Left AndAlso mouseDownHitInfo IsNot Nothing Then
                Dim dragSize = SystemInformation.DragSize
                Dim dragRect = New Rectangle(New Point(mouseDownHitInfo.HitPoint.X - dragSize.Width \ 2, mouseDownHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)
                If Not dragRect.Contains(ev.Location) Then
                    mouseDownHitInfo = Nothing
                    View.StartAccessSelection()
                    result = True
                End If
            End If

            Return result
        End Function
    End Class
End Namespace
