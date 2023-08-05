using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrayHoodT
{
    [Serializable]
    public abstract class EventBase : ScriptableObject
    {
        [SerializeField, HideInInspector] private string _guid;

        public string Guid
        {
            get => _guid;
            set => _guid = value;
        }
    }
}

