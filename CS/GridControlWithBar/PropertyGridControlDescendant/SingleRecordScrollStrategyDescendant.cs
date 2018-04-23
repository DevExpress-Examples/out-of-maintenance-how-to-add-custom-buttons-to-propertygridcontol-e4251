using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.ViewInfo;

namespace GridControlWithBar
{
    class SingleRecordScrollStrategyDescendant : SingleRecordScrollStrategy
    {
        public SingleRecordScrollStrategyDescendant(DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo viewInfo)
            : base(viewInfo)
        {
            
        }
        public override int GetCorrectTopIndex(int scrollRectHeight, int value)
        {

            return base.GetCorrectTopIndex(scrollRectHeight - (ViewInfo.Grid as PropertyGridControlDescendant).BarHeight, value);
        }


    }
}
