namespace Shmup
{
    using Microsoft.Xna.Framework;

    public class Vaisseau : DrawableGameComponent
    {
        public bool IsVisible;

        public Vector2 Position;

        public Vaisseau(Game game, Vector2 initPost)
            : base(game)
        {
            this.Position = initPost;
        }

  
    }
}
