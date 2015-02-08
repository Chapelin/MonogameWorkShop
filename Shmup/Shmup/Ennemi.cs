using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shmup.Animation;

namespace Shmup
{
    public class Ennemi : DrawableGameComponent
    {

        private AnimatedSprite[] sprites;
        private SpriteBatch sb;
        private Vector2 position;

        public Ennemi(Game game, Vector2 initPost) : base(game)
        {
            this.Game.Components.Add(this);
            this.position = initPost;

        }

        public override void Initialize()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var stable = new AnimatedSprite();
            stable.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\composite\\ennemi0"),Frame.INFINITEFRAME);
            stable.InitialiserAnimation();

            var gauche = new AnimatedSprite();
            gauche.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\composite\\ennemi1"), Frame.INFINITEFRAME);
            gauche.InitialiserAnimation();

            var droite = new AnimatedSprite();
            droite.AjoutAnimationFrame(this.Game.Content.Load<Texture2D>("Vaisseaux\\composite\\ennemi2"), Frame.INFINITEFRAME);
            droite.InitialiserAnimation();

            this.sprites = new AnimatedSprite[3];
            this.sprites[(int) MouvementHorizontal.Stable] = stable;
            this.sprites[(int) MouvementHorizontal.Gauche] = gauche;
            this.sprites[(int) MouvementHorizontal.Droite] = droite;

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(this.sprites[(int)MouvementHorizontal.Stable].ActualSprite,this.position,Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
