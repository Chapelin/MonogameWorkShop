using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Shmup.Comportement;

namespace Shmup
{
    public class ComportementVaisseau
    {
        private List<IBaseComportement> listComportements;

        private int currentComportementIndex;

        private IBaseComportement curentComportement;

        private Vaisseau v;

        public ComportementVaisseau(Vaisseau v)
        {
            this.v = v;
            this.currentComportementIndex = -1;
            this.listComportements = new List<IBaseComportement>();
        }

        public ComportementVaisseau WaitToAppear(int nombreFrame)
        {
            this.listComportements.Add(new Wait(this.v,nombreFrame));
            return this;
        }

        public ComportementVaisseau ThenMakeShoot(int nbreFrame,int frequence)
        {
            this.listComportements.Add(new Shoot(this.v,nbreFrame,frequence));
            return this;
        }

        public ComportementVaisseau ThenMove(int nbreFrame, int deplacementX, int deplacementY)
        {
            this.listComportements.Add(new Move(this.v, new Vector2(deplacementX,deplacementY),nbreFrame ));
            return this;
        }

        public ComportementVaisseau ThenShootAndMove(int nbreFrame, int frq,int deplacementX, int deplacementY)
        {
            listComportements.Add(new ShootAndMove(this.v,nbreFrame,frq,new Vector2(deplacementX,deplacementY)));
            return this;
        }

        public void Update()
        {
            if (this.currentComportementIndex == -1)
            {
                this.SetCurrentComportement(0);
            }
            this.curentComportement.Update();
            if (this.curentComportement.IsFinished)
            {
                this.SetCurrentComportement(this.currentComportementIndex+1);
            }
        }

        private void SetCurrentComportement(int i)
        {
            this.currentComportementIndex = i;
            this.curentComportement = this.listComportements[i];
        }
    }
}
