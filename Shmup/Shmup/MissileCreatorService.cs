using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shmup
{
    using Microsoft.Xna.Framework;

    public class MissileCreatorService
    {

        public Game g;

        public MissileCreatorService(Game g)
        {
            this.g = g;
        }

        private Missile CreateMissile(Vector2 position, Vector2 direction)
        {

            var mis = new Missile(g);
            g.Components.Add(mis);
            mis.Position = position;
            mis.Vitesse = direction;
            return new Missile(g);
        }



        public Missile CreateMissile(Vaisseau v, bool isEnnemi)
        {
            var pos = new Vector2(v.Position.X, v.Position.Y);
            var direction = new Vector2(0, 3);
            if (!isEnnemi)
            {
                direction *= -1;
                pos.Y -= 10;
            }
            else
            {
                pos.Y += 10;
            }


            return this.CreateMissile(pos, direction);
        }



    }
}
