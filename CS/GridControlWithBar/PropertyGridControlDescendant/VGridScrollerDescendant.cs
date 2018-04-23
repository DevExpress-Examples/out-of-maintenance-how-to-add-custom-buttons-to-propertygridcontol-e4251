using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors;

namespace GridControlWithBar
{
    public class VGridScrollerDescendant : VGridScroller
    {
        public VGridScrollerDescendant(VGridControlBase grid)
            : base(grid)
        {
            Grid = grid;
        }
        VGridControlBase Grid;
        protected override VGridScrollStrategy CreateScrollStrategy()
        {
            if (Grid != null)
            
                switch ((LayoutViewStyle)Grid.Tag)
                {
                    case LayoutViewStyle.SingleRecordView: return new SingleRecordScrollStrategyDescendant(Grid.ViewInfo);
                    case LayoutViewStyle.MultiRecordView: return new MultiRecordScrollStrategyDescendant(Grid.ViewInfo);
                    case LayoutViewStyle.BandsView: return new BandsScrollStrategyDescendant(Grid.ViewInfo);
                    default: throw new ApplicationException("Illegal layout view style.");
                }
            return base.CreateScrollStrategy();
        }
        protected override void Update()
        {
            try
            {
                
                UpdateHScrollBar();
                UpdateVScrollBar();
                Rectangle newRect = this.Grid.DisplayRectangle;
                newRect.Width -= 2;
                newRect.Y += (Grid as PropertyGridControlDescendant).BarHeight;
                newRect.Height -= 34;
                ScrollInfo.UpdateScrollerLocation(newRect);
                int leftRecord = LeftVisibleRecord,
                    topRowIndex = TopVisibleRowIndex;
                LeftVisibleRecord = leftRecord;
                TopVisibleRowIndex = topRowIndex;
                if (leftRecord != LeftVisibleRecord || topRowIndex != TopVisibleRowIndex)
                {
                    Grid.LayoutChanged();
                }
            }
            finally
            {
            }
        }
        protected void UpdateVScrollBar()
        {
           
                ScrollInfo.VScrollVisible = scrollStrategy.IsNeededVScrollBar(this.Grid.DisplayRectangle.Height);

            {

                int n = scrollStrategy.GetVScrollLargeChange((int)Grid.ViewInfo.ViewRects.Client.Height);
                if (n < 1) n = 1;
                ScrollArgs args = new ScrollArgs();
                args.Maximum = Math.Max(0, Grid.NotFixedRows.Count);
                args.Value = TopVisibleRowIndex+1;
                args.LargeChange = n;
                if (!args.IsEquals(ScrollInfo.VScrollArgs))
                {
                    args.AssignTo(ScrollInfo.VScroll);
                }
            }
        }

    }
}
