using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.ViewInfo;
using System.Drawing;

namespace GridControlWithBar
{
    public class MultiRecordViewInfoDescendant: MultiRecordViewInfo
    {
        public MultiRecordViewInfoDescendant(VGridControlBase grid, bool isPrinting)
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
