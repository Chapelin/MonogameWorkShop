using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shmup.Comportement
{
    public class ShootAndMove : BaseComportement
    {

        private Move moving;
        private Shoot shooting;

        public ShootAndMove(Vaisseau v, int duration, int frequence, Vector2 d) : base(v,duration)
        {
           this.moving = new Move(this.v,d,duration);
           this.shooting = new Shoot(this.v, duration, frequence);
        }

        public override void Update()
        {
            this.moving.Update();
            this.shooting.Update();
            base.Update();
        }
    }
}
