using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shmup
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Shmup.Animation;

    /// <summary>
    /// The missile.
    /// </summary>
    public class Missile : DrawableGameComponent
    {
        private AnimatedSprite spriteMissile;

        public Vector2 Position;

        public Vector2 Vitesse;

        private SpriteBatch sb;

        public Missile(Game game)
            : base(game)
        {
            this.spriteMissile = new AnimatedSprite();
            this.spriteMissile.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Missiles\\composite\\tir0"), 20);
            this.spriteMissile.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Missiles\\composite\\tir1"), 10);
            this.spriteMissile.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Missiles\\composite\\tir2"), Frame.INFINITEFRAME);
            this.spriteMissile.InitialiserAnimation();

            this.sb = new SpriteBatch(this.Game.GraphicsDevice);

        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.spriteMissile.Tick();
            this.Position += Vitesse;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(this.spriteMissile.ActualSprite, this.Position, null, Color.White, this.Vitesse.Y>0 ? 0 : MathHelper.Pi, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
