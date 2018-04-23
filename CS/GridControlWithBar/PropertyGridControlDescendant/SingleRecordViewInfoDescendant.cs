using System.Drawing;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;
using System;
using System.Collections.Generic;



namespace GridControlWithBar
{
    public class SingleRecordViewInfoDescendant : SingleRecordViewInfo
    {
        public SingleRecordViewInfoDescendant(VGridControlBase grid, bool isPrinting)
            : base(grid, isPrinting)
        {

        }


       
        protected override void CreateBand(int bandHeight, int bandWidth)
        {
            int left = (ViewRects.BandRects.Count == 0 ? ViewRects.Client.Left :
          ((Rectangle)ViewRects.BandRects[ViewRects.BandRects.Count - 1]).Right);
            Rectangle br = new Rectangle(left, ViewRects.Client.Top + (Grid as PropertyGridControlDescendant).BarHeight, bandWidth, Math.Min(bandHeight, ViewRects.Client.Height));
            ViewRects.BandRects.Add(br);

        }

    }
}

