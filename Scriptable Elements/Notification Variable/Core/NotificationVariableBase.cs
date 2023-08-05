using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrayHoodT
{
    public abstract class NotificationVariableBase : ScriptableObject
    {
        [SerializeField, HideInInspector] private string _guid;

        public string Guid
        {
            get => _guid;
            set => _guid = value;
        }

        public abstract Type GetGenericType { get; }
    }
}
