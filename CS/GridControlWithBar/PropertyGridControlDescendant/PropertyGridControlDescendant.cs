using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Painters;

namespace GridControlWithBar
{
    public class PropertyGridControlDescendant : PropertyGridControl
    {
        public PropertyGridControlDescendant()

        {
            fButtonList = new List<EditorButton>();
            
        }

        public VGridPainterDescendant VGridPainter;

        public void AddButton(String NameAndCaption)
        {
            EditorButton Button = new EditorButton();
            Button.Kind = ButtonPredefines.Glyph;
            Button.Caption = NameAndCaption;
            Button.Tag = NameAndCaption;
            Button.Width = TextRenderer.MeasureText(NameAndCaption, DefaultFont).Width;
            ButtonList.Add(Button);
            CalcButtonInfo();

        }
        public void AddButton(string Name, Image image)
        {
            EditorButton Button = new EditorButton();
            Button.Kind = ButtonPredefines.Glyph;
            Button.Image = image;
            Button.Tag = Name;
            if (image.HorizontalResolution > 60)
                Button.Width = 60;
            else Button.Width = (int)image.HorizontalResolution;
            ButtonList.Add(Button);
            CalcButtonInfo();
        
        }
        public int BarHeight = 30;
        public List<EditorButton> fButtonList;
        private List<EditorButton> ButtonList
        {
            get { return fButtonList; }
        }
        public List<EditorButtonObjectInfoArgs> ButtonInfoList;
        public delegate void CustomButtonHitedHandler(object sendet, CustomButtonsEventArgs e);
        public event CustomButtonHitedHandler CustomButtonHited;
        public virtual void OnCustomButtonHited(CustomButtonsEventArgs e)
        {
            if (CustomButtonHited != null)
                CustomButtonHited(this, e);
        }

        private EditorButtonObjectInfoArgs buttonInfo;
        internal EditorButtonObjectInfoArgs ButtonInfo
        {
            get
            {
                return buttonInfo;
            }
        }

        protected virtual void CalcButtonInfo()
        {
            if (ButtonInfoList == null)
                ButtonInfoList = new List<EditorButtonObjectInfoArgs>();
            ButtonInfoList.Clear();
            if (ButtonList != null)
                if (ButtonList.Count > 0)
                    foreach (EditorButton EB in ButtonList)
                    {
                        buttonInfo = new EditorButtonObjectInfoArgs(EB, EB.Appearance);
                        Rectangle rect = new Rectangle(2, 2, EB.Width, BarHeight);
                        if (ButtonInfoList.Count > 0)
                        {
                            EditorButtonObjectInfoArgs PrevButton = ButtonInfoList[ButtonInfoList.Count - 1];
                            rect = new Rectangle(2 + PrevButton.Bounds.Width + PrevButton.Bounds.X,
                                2, EB.Width, BarHeight);
                        }
                        buttonInfo.Bounds = rect;
                        ButtonInfoList.Add(buttonInfo);
                    }
        }



        #region ClassDescendants
        protected override VGridScroller CreateScroller()
        {
            return new VGridScrollerDescendant(this);
        }

        protected override DevExpress.XtraVerticalGrid.Painters.VGridPainter CreatePainterCore(DevExpress.XtraVerticalGrid.Painters.PaintEventHelper eventHelper)
        {
            return new VGridPainterDescendant(eventHelper) ;
        }

        protected override DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo CreateViewInfo(bool isPrinting)
        {
            this.Tag = LayoutStyle;
            if (LayoutStyle == LayoutViewStyle.SingleRecordView)
                return new SingleRecordViewInfoDescendant(this, isPrinting);
            if (LayoutStyle == LayoutViewStyle.MultiRecordView)
                return new MultiRecordViewInfoDescendant(this, isPrinting);
            return new BandsViewInfoDescendant(this, isPrinting);
        }

        #endregion
        



        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (EditorButtonObjectInfoArgs info in ButtonInfoList)
            {
                if (ButtonHited(e.Location) == info.Button.Tag)
                {
                    info.State = ObjectState.Pressed;
                    this.Invalidate(info.Bounds);
                }
            }
            if(ButtonHited(e.Location) != null)
            OnCustomButtonHited(new CustomButtonsEventArgs((string)ButtonHited(e.Location)));

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            
            base.OnMouseMove(e);
            CustomButtonHotTrack(e);
        }
      
        
        private void CustomButtonHotTrack(System.Windows.Forms.MouseEventArgs e)
        {
            if (ButtonInfoList != null)
            foreach (EditorButtonObjectInfoArgs info in ButtonInfoList)
            {
                if (ButtonHited(e.Location) == info.Button.Tag)
                {
                    info.State = ObjectState.Hot;
                    this.Invalidate(info.Bounds);

                }
                else
                {
                    info.State = ObjectState.Normal;
                    this.Invalidate(info.Bounds);
                }
            }
        }


        protected object ButtonHited(Point location)
        {
            if (ButtonInfoList == null) return false;
            foreach (EditorButtonObjectInfoArgs info in ButtonInfoList)
            {
                if (info.Bounds.Contains(location))
                    return info.Button.Tag;
            }
            return null;
        }

    }
}
