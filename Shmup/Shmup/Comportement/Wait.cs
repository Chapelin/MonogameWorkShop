using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shmup.Comportement
{
    public class Wait : BaseComportement
    {
        public Wait(Vaisseau v, int dur):base(v,dur)
        {
        }

        public override void Update()
        {
            this.v.IsVisible = false;
            base.Update();
            if (this.IsFinished)
                this.v.IsVisible = true;
        }
    }
}
