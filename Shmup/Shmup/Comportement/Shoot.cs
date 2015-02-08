using System;
using Microsoft.Xna.Framework;

namespace Shmup.Comportement
{
    public class Shoot : BaseComportement
    {

        public int compteurFrequence = 0;
        public int frequence;

        // TODO : handle missile direction

        public Shoot(Vaisseau v, int duration, int frequence) : base(v,duration)
        {
            this.frequence = frequence;
        }

        public override void Update()
        {
            this.compteurFrequence++;
            if (compteurFrequence % frequence == 0)
            {
                compteurFrequence = 0;
                // TODO: spaw missile

            }
            base.Update();
        }
    }
}
