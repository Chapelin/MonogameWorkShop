using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shmup.Comportement
{
    public interface IBaseComportement
    {
        void Update();
        bool IsFinished { get; set; }
    }

    public  class BaseComportement : IBaseComportement
    {

        public int duration;
        public Vaisseau v;
        private int cpt = 0;


        public BaseComportement(Vaisseau v, int duration)
        {
            this.v = v;
            this.duration = duration;
        }

        public virtual void Update()
        {
            this.cpt++;
            if (this.cpt >= this.duration)
                IsFinished = true;
        }

        public bool IsFinished { get; set; }
    }
}
