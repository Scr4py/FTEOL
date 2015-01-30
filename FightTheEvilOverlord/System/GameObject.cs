using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Reflection;

namespace FightTheEvilOverlord
{
    public class GameObject
    {
        protected Hashtable componentList = new Hashtable();

        public T AddComponent<T>() where T : Component, new()
        {
            if (!HasComponent<T>())
            {
                T component = new T();
                component.SetGameObject(this);
                componentList.Add(typeof(T), component);
                InvokeStart(component, typeof(T));
            }

            return (T)componentList[typeof(T)];
        }

        public bool HasComponent<T>()
        {
            return componentList.ContainsKey(typeof(T));
        }

        public T GetComponent<T>()
        {
            return (T)componentList[typeof(T)];
        }

        public void RemoveComponent<T>()
        {
            componentList.Remove(typeof(T));
        }
        public virtual void Destroy()
        {
            Component[] tempComponents = new Component[componentList.Count];
            componentList.Values.CopyTo(tempComponents, 0);

            foreach (var tempComponent in tempComponents)
            {
                tempComponent.Destroy();
            }
        }

        private void InvokeStart(object component,Type type)
        {
            MethodInfo info = type.GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
            if (info != null)
            {
                info.Invoke(component, null);
            }
        }
    }
}
