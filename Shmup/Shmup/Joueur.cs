using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shmup.Animation;

namespace Shmup
{
    public enum MouvementHorizontal
    {
        Stable,
        Droite,
        Gauche
    }

    public class Joueur : DrawableGameComponent
    {
        private AnimatedSprite[] spritesMouvement;
        private MouvementHorizontal _currentMovementHorizontal;
        private Vector2 _position;
        private SpriteBatch sb;

        public Joueur(MonoShmup game, Vector2 initPos)
            : base(game)
        {
            this._position = initPos;
            this._currentMovementHorizontal = MouvementHorizontal.Stable;
            this.spritesMouvement = new AnimatedSprite[3];
            this.Game.Components.Add(this);
        }


        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            MouvementHorizontal mouvementToapply;
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this._position.X -= 5;
                mouvementToapply = MouvementHorizontal.Gauche;
            }
            else
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    this._position.X += 5;
                    mouvementToapply = MouvementHorizontal.Droite;
                }
                else
                {
                    mouvementToapply = MouvementHorizontal.Stable;
                }
            if (mouvementToapply != _currentMovementHorizontal)
            {
                this.spritesMouvement[(int)_currentMovementHorizontal].InitialiserAnimation();
                this._currentMovementHorizontal = mouvementToapply;
            }

            this.spritesMouvement[(int)this._currentMovementHorizontal].Tick();
            base.Update(gameTime);
        }

        public override void Initialize()
        {
            this.sb = new SpriteBatch(this.Game.GraphicsDevice);

            InitializeAnimation();
            base.Initialize();
        }

        private void InitializeAnimation()
        {
            var moi = new AnimatedSprite();
            moi.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\Composite\\moi2"), Frame.INFINITEFRAME);
            moi.InitialiserAnimation();
            this.spritesMouvement[(int)MouvementHorizontal.Stable] = moi;

            var moiDroite = new AnimatedSprite();
            moiDroite.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\Composite\\moi3"), 10);
            moiDroite.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\Composite\\moi4"), Frame.INFINITEFRAME);
            moiDroite.InitialiserAnimation();
            this.spritesMouvement[(int)MouvementHorizontal.Droite] = moiDroite;

            var moiGauche = new AnimatedSprite();
            moiGauche.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\Composite\\moi1"), 10);
            moiGauche.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\Composite\\moi0"), Frame.INFINITEFRAME);
            moiGauche.InitialiserAnimation();
            this.spritesMouvement[(int)MouvementHorizontal.Gauche] = moiGauche;
        }

        public override void Draw(GameTime gameTime)
        {
            this.sb.Begin();
            this.sb.Draw(this.spritesMouvement[(int)this._currentMovementHorizontal].ActualSprite, _position, Color.White);
            this.sb.End();
            base.Draw(gameTime);
        }
    }
}
