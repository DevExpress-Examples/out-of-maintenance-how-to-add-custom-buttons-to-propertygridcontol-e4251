using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraVerticalGrid.Painters;
using DevExpress.XtraVerticalGrid.ViewInfo;

namespace GridControlWithBar
{
    public class VGridPainterDescendant : VGridPainter
    {
        public VGridPainterDescendant(DevExpress.XtraVerticalGrid.Painters.PaintEventHelper eventHelper)
            : base(eventHelper)
        {
           
        }

        protected override void DoDrawCore(DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo vi)
        {
            base.DoDrawCore(vi);
            DrawButton(vi);

        }
        protected  void DrawButton(BaseViewInfo vi)
        {
            if (((PropertyGridControlDescendant)vi.Grid).ButtonInfoList != null)
            foreach (EditorButtonObjectInfoArgs info in ((PropertyGridControlDescendant)vi.Grid).ButtonInfoList)
            {
                if (info != null)
                {
                    EditorButtonPainter painter = EditorButtonHelper.GetPainter(BorderStyles.Default);
                    info.Cache = this.DrawInfo.Cache;
                    painter.DrawObject(info);
                }
            }
        }

       
    }
}
