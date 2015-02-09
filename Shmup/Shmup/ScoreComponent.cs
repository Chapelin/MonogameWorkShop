using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shmup
{
    public interface IScoreComponent
    {
        void AddScore(int nombreToAdd);
    }

    public class ScoreComponent : DrawableGameComponent, IScoreComponent
    {

        private int score;
        private string scoreString;
        private SpriteBatch sb;
        private SpriteFont font;
        private Vector2 textPosition;
        
        public ScoreComponent(MonoShmup game) : base(game)
        {
            this.Game.Services.AddService(typeof(IScoreComponent),this);
            
        }

        public override void Initialize()
        {
            this.score = 0;
            this.scoreString = "Score : 0";
            this.sb = new SpriteBatch(this.Game.GraphicsDevice);
            this.textPosition = new Vector2(10,10);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            this.font = this.Game.Content.Load<SpriteFont>("DefaultFont");
            base.LoadContent();
        }

        public void AddScore(int nombreToAdd)
        {
            this.score += nombreToAdd;
            this.scoreString = "Score : "+this.score;
        }

        public override void Update(GameTime gameTime)
        {
            var keybState = Keyboard.GetState();
            if(keybState.IsKeyDown(Keys.Space))
                this.AddScore(2);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(this.font, this.scoreString, this.textPosition, Color.Red);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
