using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FightTheEvilOverlord
{
    public abstract class Component
    {
        private GameObject gameObject;
        public GameObject GameObject { get { return this.gameObject; } }

        public void SetGameObject(GameObject gameObject)
        {
            if (this.gameObject == null)
            {
                this.gameObject = gameObject;
            }
            else
            {
                throw new Exception("GameObject parent already set");
            }
        }

        public virtual void Destroy()
        {
            Type t = this.GetType();
            MethodInfo method = typeof(GameObject).GetMethod("RemoveComponent");
            MethodInfo generic = method.MakeGenericMethod(t);
            generic.Invoke(gameObject, null);
        }
    }
}
