using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    public class CustomCheckBox : CheckBox
    {
        private ImageList _checkboxImages = new ImageList();

        public CustomCheckBox()
        {
            string whiteImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "white.bmp");
            string blackImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "black.bmp");
            _checkboxImages.Images.Add(Image.FromFile(whiteImagePath));
            _checkboxImages.Images.Add(Image.FromFile(blackImagePath));
            _checkboxImages.ImageSize = new Size(13, 13);
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            ImageList = _checkboxImages;
            TextImageRelation = TextImageRelation.ImageAboveText;

            base.CheckedChanged += CheckedChanged;
        }
        
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (Checked)
            {
                ImageIndex = 1;
            }
            else
            {
                ImageIndex = 0;
            }
        }
    }
}
