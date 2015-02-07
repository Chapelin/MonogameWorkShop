using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shmup.Animation;

namespace Shmup
{
    public enum MouvementHorizontal
    {
        Stable,
        DebutDroite,
        Droite,
        DebutGauche,
        Gauche
    }

    public class Joueur : DrawableGameComponent
    {
        private AnimatedSprite[] spritesMouvement;
        private MouvementHorizontal currentMovementHorizontal;
        private Vector2 position;
        private SpriteBatch sb;

        public Joueur(MonoShmup game, Vector2 initPos)
            : base(game)
        {
            this.position = initPos;
            this.currentMovementHorizontal = MouvementHorizontal.Stable;
            this.spritesMouvement = new AnimatedSprite[5];
            this.Game.Components.Add(this);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Initialize()
        {
            this.sb = new SpriteBatch(this.Game.GraphicsDevice);
          
            var moi = new AnimatedSprite();
            moi.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\Composite\\moi2"), 1000);
            moi.InitialiserAnimation();
            this.spritesMouvement[(int) MouvementHorizontal.Stable] = moi;
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            this.sb.Begin();
            this.sb.Draw(this.spritesMouvement[(int) this.currentMovementHorizontal].ActualSprite,position,Color.White);
            this.sb.End();
            base.Draw(gameTime);
        }
    }
}
