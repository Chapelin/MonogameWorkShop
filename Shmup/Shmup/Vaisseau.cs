using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shmup
{
    public class Vaisseau : DrawableGameComponent
    {
        public bool IsVisible;

        public Vector2 Position;

        public Vaisseau(Game game, Vector2 initPost)
            : base(game)
        {
           
            this.Position = initPost;
        }

  
    }
}
