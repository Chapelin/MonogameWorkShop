#region Using Statements

using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Shmup
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MonoShmup : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private Joueur _joueur;

        private Missile ms;

        private Ennemi ennemi;



        public MonoShmup()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 600,
                PreferredBackBufferWidth = 600
            };

            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this._joueur = new Joueur(this, new Vector2(400, 400));
            this.ennemi = new Ennemi(this, new Vector2(150, 10));
            this.ennemi.comportement = new ComportementVaisseau(this.ennemi).WaitToAppear(300).ThenMove(10000,2,2);
            this.ms = new Missile(this);
            this.Components.Add(this.ms);
            this.ms.Position = new Vector2(30,30);
            this.ms.Vitesse = new Vector2(0,5);
            var scoreComp = new ScoreComponent(this);
            this.Components.Add(scoreComp);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
