using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridControlWithBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            propertyGridControlDescendant1.SelectedObject = propertyGridControlDescendant1;
            propertyGridControlDescendant1.AddButton("Alphabetical");
            propertyGridControlDescendant1.AddButton("ImageAlphabetical", GetImageByName("Alphabetical.png"));
            propertyGridControlDescendant1.AddButton("Categorized");
            propertyGridControlDescendant1.AddButton("ImageCategorized", GetImageByName("Categorized.png"));

            propertyGridControlDescendant1.CustomButtonHited += new PropertyGridControlDescendant.CustomButtonHitedHandler(propertyGridControlDescendant1_CustomButtonHited);
        }

        void propertyGridControlDescendant1_CustomButtonHited(object sendet, CustomButtonsEventArgs e)
        {
            if (e.Name == "Alphabetical" || e.Name == "ImageAlphabetical")
                propertyGridControlDescendant1.OptionsView.ShowRootCategories = false;
            if (e.Name == "Categorized" || e.Name == "ImageCategorized")
                propertyGridControlDescendant1.OptionsView.ShowRootCategories = true;
        }

        private Image GetImageByName(string imageName)
        {
            return Image.FromStream(this.GetType().Assembly.GetManifestResourceStream(String.Format("GridControlWithBar.{0}", imageName)));
        }
    }
}
