using Microsoft.Xna.Framework.Graphics;

namespace Shmup.Animation
{
    public class Frame
    {

        public static int INFINITEFRAME = -1;
        /// <summary>
        /// Texture de la frame
        /// </summary>
        readonly Texture2D _sprite;

        /// <summary>
        /// Accesseur de la texture de la frame
        /// </summary>
        public Texture2D Sprite
        {
            get { return _sprite; }
        }

        /// <summary>
        /// Nombre de ticks avant la fin de cette frame
        /// </summary>
        readonly int _nombreTicks;

        /// <summary>
        /// Compteur de ticks
        /// </summary>
        float _compteur;

        public Frame(Texture2D sprite, int attente)
        {
            this._sprite = sprite;
            this._nombreTicks = attente;
            _compteur = 0;
        }

        /// <summary>
        /// Permet de "ticker" la sprite
        /// </summary>
        /// <returns>True si la frame est finie</returns>
        public bool Tick()
        {
            return Tick(1);
        }

        /// <summary>
        /// Ticke la frame un certain nombre de fois
        /// </summary>
        /// <param name="nombre">Nombre de ticks à effectuer</param>
        /// <returns>True si la frame est finie</returns>
        public bool Tick(float nombre)
        {
            if (this._nombreTicks == Frame.INFINITEFRAME)
                return false;
            this._compteur += nombre;
            var retour = this._compteur >= this._nombreTicks;
            if (retour)
                this.Reset();
            return retour;
        }

        /// <summary>
        /// Remet à zéro le compteur de ticks
        /// </summary>
        public void Reset()
        {
            _compteur = 0;
        }
    }
}
