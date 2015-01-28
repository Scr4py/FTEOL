using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    interface ICharacterInterface
    {
        private Transform transform;
        protected int AttackPower;
        public bool isDead = false;
        public Tile tile;


        public void GetDamage(GameObject gameObject)
        {

        }

        public void Attack(GameObject target)
        {

        }

        public void SetToStack()
        {

        }
    }
}
