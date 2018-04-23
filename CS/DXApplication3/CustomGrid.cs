using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DXApplication3
{
    [ToolboxItem(true)]
    public class CustomGrid : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            return CreateView("CustomGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridViewInfoRegistrator());
        }
    }

    public class CustomGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName
        {
            get
            {
                return "CustomGridView";
            }
        }
        public override BaseView CreateView(GridControl grid)
        {
            return new CustomGridView(grid);
        }
        public override BaseViewHandler CreateHandler(BaseView view)
        {
            return new CustomGridViewHandler(view as CustomGridView);
        }
    }

    public class CustomGridView : GridView
    {
        public virtual bool IsRowSelect { get { return IsMultiSelect && OptionsSelection.MultiSelectMode == GridMultiSelectMode.RowSelect; } }
        public CustomGridView()
        {
        }
        public CustomGridView(GridControl grid) : base(grid)
        {
        }
        protected override string ViewName
        {
            get
            {
                return "CustomGridView";
            }
        }
        internal new void StartAccessSelection()
        {
            base.StartAccessSelection();
        }
        public override EditorShowMode GetShowEditorMode()
        {
            if (OptionsBehavior.EditorShowMode == EditorShowMode.Default && IsRowSelect)
                return EditorShowMode.Click;
            return base.GetShowEditorMode();
        }
    }

    public class CustomGridViewHandler : DevExpress.XtraGrid.Views.Grid.Handler.GridHandler
    {
        private GridHitInfo mouseDownHitInfo;
        public new CustomGridView View { get { return base.View as CustomGridView; } }
        public CustomGridViewHandler(GridView view) : base(view)
        {
        }
        protected override bool OnMouseDown(MouseEventArgs ev)
        {
            var result = base.OnMouseDown(ev);
            if (ev.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None && View.IsRowSelect && DownPointHitInfo.InRowCell)
                mouseDownHitInfo = DownPointHitInfo;
            else
                mouseDownHitInfo = null;
            return result;
        }
        protected override bool OnMouseMove(MouseEventArgs ev)
        {
            var result = base.OnMouseMove(ev);
            if (!result && ev.Button == MouseButtons.Left && mouseDownHitInfo != null)
            {
                var dragSize = SystemInformation.DragSize;
                var dragRect = new Rectangle(
                    new Point(mouseDownHitInfo.HitPoint.X - dragSize.Width / 2, mouseDownHitInfo.HitPoint.Y - dragSize.Height / 2),
                    dragSize);
                if (!dragRect.Contains(ev.Location))
                {
                    mouseDownHitInfo = null;
                    View.StartAccessSelection();
                    result = true;
                }
            }
            return result;
        }
    }
}
