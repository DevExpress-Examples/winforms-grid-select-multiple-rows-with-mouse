<!-- default file list -->
*Files to look at*:

* [CustomGrid.cs](./CS/DXApplication3/CustomGrid.cs) (VB: [CustomGrid.vb](./VB/DXApplication3/CustomGrid.vb))
* [Form1.cs](./CS/DXApplication3/Form1.cs) (VB: [Form1.vb](./VB/DXApplication3/Form1.vb))
* [Program.cs](./CS/DXApplication3/Program.cs) (VB: [Program.vb](./VB/DXApplication3/Program.vb))
<!-- default file list end -->
# GridView - How to select multiple rows by dragging the mouse in RowSelect mode


<p>The <strong>GridMultiSelectMode.CellSelect</strong> mode allows an end-user to select a contiguous block of cells by dragging the mouse over them. To select multiple rows in <strong>GridMultiSelectMode.RowSelect </strong>mode in the same way as in <strong>GridMultiSelectMode.CellSelect</strong> mode, you need to create a GridView descendant and override the GridHandler.OnMouseDown method as shown below.</p>

<br/>


