using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shmup.Comportement
{
    public class Move : BaseComportement
    {
      
        public Vector2 Deplacement;

        

        public Move(Vaisseau v, Vector2 deplacement, int duration) : base(v,duration)
        {
        
            this.Deplacement = deplacement;
        }



        public override void Update()
        {
            v.Position += Deplacement;
            base.Update();
        }

     
    }
}
