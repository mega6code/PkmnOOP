using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PkmnGameOOP
{
    public enum Energy 
    {
        FIRE,
        GRASS,
        LIGHTNING,
        WATER  
    }
    interface IMonster
    {
        void ReceiveDamage(int damage);
        void Attack(Monster target);

    }

    public abstract class Monster : IMonster 
    {
        //I wanted to test the #region thing so i tried it
        #region Fields
        private string name;
        private int hp, ap, hp_max;
        #endregion
  
        #region Properties       
        public int Hp { get { return hp; } set { hp = value; } }
        public int Ap { get => ap; set => ap = value; }
        public int Hp_max { get => hp_max; set => hp_max = value; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region Functions
        public virtual void ReceiveDamage(int damage) 
        {
            hp -= damage;             
        }
        public abstract void Attack(Monster target);
        #endregion

        #region Construtorz
        public Monster(string name, int ap, int hp)
        {
            this.name = name;
            this.ap = ap;
            this.hp = hp;
            this.hp_max = hp;
        }
        #endregion
    }

    public class Pokemon : Monster
    {


        #region Fields

        private int speed;

        private Energy type;

        private bool fainted;

        #endregion

        #region Properties 
        public int Speed { get => speed; set => speed = value; }
        public bool Fainted { get => fainted; set => fainted = value; }
        public Energy Type { get => type; set => type = value; }
        public string State
        {
            get
            {
                if (fainted) { return "INACTIVE"; }
                else { return "ACTIVE"; }

            }
        }

        #endregion

        #region Functions

        public override void ReceiveDamage(int damage)
        {
            this.Hp -= damage;
            if (this.Hp <= 0) { fainted = true; }
        }

        public override void Attack(Monster target) 
        {
            if (!this.fainted)
            {
                //Random random_dmg = new Random();
                target.ReceiveDamage(new Random().Next(this.Ap));
            }
            else
            {
                Console.WriteLine("Pokemon is not Active yet!");

            }
        }

        public void Heal() 
        {
            this.Hp = Hp_max;
            fainted = false;       
        }

        public override string ToString() 
        { 
            return $"{Name}: {Hp} HP | {Ap} AP | {speed} Speed | Currently {State} | {type} type";
        }
        #endregion

        #region Construtorz

        public Pokemon(int speed_inp, string name_inp, int ap_inp, int hp_inp): base(name_inp, ap_inp, hp_inp)
        {
            this.fainted = false;
            this.speed = speed_inp;
            
        }
        #endregion
    }
}
