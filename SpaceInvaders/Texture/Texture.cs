using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Texture : DLink
    {

        //---------------------------------------------
        // Data
        //---------------------------------------------
        public Name TextureName;
        public Azul.Texture poAzulTexture;

        //---------------------------------------------
        // Enum
        //---------------------------------------------
        public enum Name
        {
            Aliens,
            Stitch,
            Birds,

            Consolas,

            NullTexture,
            Uninitialized
        }

        //---------------------------------------------
        // Constructors
        //---------------------------------------------
        public Texture(Name _name, string _textureName)
        {
            Debug.Assert(_textureName != null);

            this.TextureName = _name;

            // LTN - Texture
            this.poAzulTexture = new Azul.Texture(_textureName);
            Debug.Assert(poAzulTexture != null);
        }

        public Texture()
        {
            this.TextureName = Name.Uninitialized;

            // LTN - Texture
            this.poAzulTexture = new Azul.Texture();
        }

        //---------------------------------------------
        // Methods
        //---------------------------------------------
        public override void Wash()
        {
            base.Wash();
            this.Clear();
        }

        private void Clear()
        {
            Debug.Assert(this.poAzulTexture != null);
            this.poAzulTexture.Set("HotPink.tga", Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            this.TextureName = Name.Uninitialized;
        }

        public void Set(Name _name, string _textureName)
        {

            this.TextureName = _name;

            Debug.Assert(this.poAzulTexture != null);
            this.poAzulTexture.Set(_textureName, Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);

            Texture compTex = (Texture)pNode;

            return (this.TextureName == compTex.TextureName);
        }
    }
}
