﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs.project07.pokemon
{
    public class Attack
    {
        private readonly string _name;
        private int _power;
        private readonly Type _type;
        private int _maxUsage;
        private int _currentUsage;


        public string Name => _name;
        public int Power { get => _power; set => _power = value; }
        public Type Type { get => _type; }
        public int Usage { get => _currentUsage; }

        public Attack(string name, int damage, Type type, int maxUsage = 20)
        {
            _name = name;
            _power = damage;
            _type = type;
            _maxUsage = maxUsage;
            _currentUsage = _maxUsage;
        }
        
        public void Use()
        {
            _currentUsage--;
        }

        public bool IsSpecialMove()
        {
            if (Type is (Type.DARK or Type.ELECTRIC or Type.FIRE or Type.WATER or Type.GRASS or Type.PSYCHIC))
            {
                return true;
            }
            else return false;
        }

        public bool IsPhysicalMove()
        {
            if (Type is (Type.NORMAL or Type.STEEL or Type.FIGHTING or Type.FLYING or Type.GROUND or Type.ROCK or Type.POISON or Type.GHOST or Type.BUG))
            {
                return true;
            }
            else return false;
        }
    }
}