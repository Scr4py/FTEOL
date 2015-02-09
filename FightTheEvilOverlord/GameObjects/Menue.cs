using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class Button :  GameObject
    {
        private CompoundRenderer render;
        private Transform transform;
        private MouseMenueInteractive mouse;
        public bool isPlayed = false;
        Rectangle source;

        public Button(Texture2D image, Rectangle source)
        {
            this.source = source;
            EventManager.OnUpdate += Update;
            this.transform = this.AddComponent<Transform>();
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.render = this.AddComponent<CompoundRenderer>();
            this.render.AddInLists(image, source);
            this.render.start();
            this.mouse.start();
            this.mouse.OnClick += OnClick;
            this.mouse.ButtonClick();
            
        }

        private void Update(GameTime gameTime)
        {
            this.mouse.ButtonClick();
        }

        private void OnClick()
        {
            Console.WriteLine("Test");
        }
    }
}
