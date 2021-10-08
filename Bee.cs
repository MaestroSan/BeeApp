using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp
{
    class Bee
    {
        private float health = 100;
        private bool dead = false;
        private bool isQueen = false;
        private bool isWorker = false;
        private bool isDrone = false;
        private string name = string.Empty;

        public float Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public bool Dead
        {
            get
            {
                return this.dead;
            }
            set
            {
                this.dead = value;
            }
        }
        public bool IsQueen
        {
            get
            {
                return this.isQueen;
            }
            set
            {
                this.isQueen = value;
            }
        }

        public bool IsWorker
        {
            get
            {
                return this.isWorker;
            }
            set
            {
                this.isWorker = value;
            }
        }

        public bool IsDrone
        {
            get
            {
                return this.isDrone;
            }
            set
            {
                this.isDrone = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Bee Damage(int value)
        {
            if (!Dead)
            {
                Health = (float)Math.Round(Health * (100 - value) / 100, 2);
                Dead = Health < (IsQueen ? 20 : IsDrone ? 50 : 70) ? true : false;
            }

            return this;
        }

        public float HealthStatus()
        {
            return this.Health;
        }

        public bool IsAlive()
        {
            return !this.Dead;
        }
    }
}
