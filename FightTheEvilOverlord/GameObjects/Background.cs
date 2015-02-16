using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace FightTheEvilOverlord
{
    class Background : GameObject
    {
        Transform transform;
        BackgroundRender render;

        public Background(Texture2D image)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<BackgroundRender>();
            this.render.SetImage(image);
            this.render.start();
            this.render.SetPosition(new Vector2(600, 0));

        }
    }
}
