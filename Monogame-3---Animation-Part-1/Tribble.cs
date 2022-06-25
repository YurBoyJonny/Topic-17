using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monogame_3___Animation_Part_1
{
    internal class Tribble
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;

        public Tribble(Texture2D texture, Rectangle rect, Vector2 speed)
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
        }
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }
        public void Move()
        {
            _rectangle.Offset(_speed);
        }
        public void BounceLeftRight()
        {
            _speed.X *= -1;
        }
        public void BounceTopBottom()
        {
            _speed.Y *= -1;
        }
    }
}
