using DG.Tweening;
using GrayHoodT.Enums;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace GrayHoodT.Structs
{
    #region [ Example. ]

    public struct ExampleStruct
    {
        public int _exampleID;
        public string _exampleName;
    }

    #endregion

    #region SceneLoader

    [Serializable]
    public struct SceneLoadMessage
    {
        [SerializeField] private string _sceneNameToLoad;
        [SerializeField] private SceneLoadType _loadType;

        public string SceneNameToLoad 
        { 
            get => _sceneNameToLoad;
            private set => _sceneNameToLoad = value;
        }

        public SceneLoadType LoadType 
        {
            get => _loadType;
            private set => _loadType = value;
        }

        public SceneLoadMessage(string sceneName, SceneLoadType sceneLoadType)
        {
            _sceneNameToLoad = sceneName;
            _loadType = sceneLoadType;
        }
    }

    [Serializable]
    public struct SceneReferenceLoadMessage
    {
        [SerializeField] private SceneReferenceSO _sceneReference;
        [SerializeField] private SceneLoadType _loadType;

        public SceneReferenceSO SceneReference
        {
            get => _sceneReference;
            private set => _sceneReference = value;
        }

        public SceneLoadType LoadType
        {
            get => _loadType;
            private set => _loadType = value;
        }

        public SceneReferenceLoadMessage(SceneReferenceSO sceneReference, SceneLoadType loadType)
        {
            _sceneReference = sceneReference;
            _loadType = loadType;
        }
    }

    #endregion

    #region SceneTransitioner

    [Serializable]
    public struct ScreenFadeMessage
    {
        [SerializeField] private float _startValue;
        [SerializeField] private float _endValue;
        [SerializeField] private float _duration;
        [SerializeField] private Color _color;
        [SerializeField] private Ease _ease;

        public float StartValue 
        {
            get => _startValue;
            private set => _startValue = value;
        }

        public float EndValue 
        {
            get => _endValue; 
            private set => _startValue = value; 
        }

        public float Duration 
        { 
            get => _duration; 
            private set => _startValue = value;
        }

        public Color Color
        {
            get => _color;
            private set => _color = value;
        }

        public Ease Ease 
        {
            get => _ease;
            private set => _ease = value;
        }

        public ScreenFadeMessage(float startValue, float endValue, float duration, Color color, Ease ease)
        {
            _startValue = startValue;
            _endValue = endValue;
            _duration = duration;
            _color = color;
            _ease = ease;
        }
    }

    #endregion
}

