using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageProxy : DLink
    {
        public Image pImage;

        public ImageProxy(Image _pImage)
        {
            this.pImage = _pImage;
        }

        public void SwapImage(Image _pImage)
        {
            this.pImage = _pImage;
        }

        public override void Wash()
        {
            base.Wash();
            this.pImage = null;
        }

        public override bool Compare(NodeBase pNode)
        {
            Image pCompImage = (Image)pNode;

            return (this.pImage.ImageName == pCompImage.ImageName);
        }
    }
}
