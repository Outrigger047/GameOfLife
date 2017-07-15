using System;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    public class CustomCheckBox : CheckBox
    {
        /// <summary>
        /// Parameterized constructor to instantiate a CustomCheckBox
        /// </summary>
        /// <param name="checkboxImages">ImageList containing custom images for checkbox states</param>
        public CustomCheckBox(ImageList checkboxImages)
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            ImageList = checkboxImages;
            TextImageRelation = TextImageRelation.ImageAboveText;

            base.CheckedChanged += CheckedChanged;
        }
        
        /// <summary>
        /// Overrides base checkbox change event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
