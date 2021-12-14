﻿using Abstractions;
using UnityEngine;

namespace Core
{
    public sealed class GrenadierBuilding : MonoBehaviour, ISelectable
    {

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 1000;

        public Vector3 RallyPoint { get; set; }



        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public EnvironmentType Type { get; }
        public Transform PivotPoint => _pivotPoint;
    } 
}

