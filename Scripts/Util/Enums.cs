using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrayHoodT.Enums
{
    #region [ Example. ]

    public enum ExampleType
    {
        ExampleA,
        ExampleB,
        ExampleC
    }

    #endregion

    #region Scene

    public enum SceneType
    {
        // Core Scenes. <Only Single Scene>
        Initialisation,
        Persistent,
        
        // Game Progress Scene. <Only Single Scene>
        Main,

        // Additive Scenes. <Additive Scene>
        Sub,
        Level,
    }

    public enum SceneLoadType
    {
        LoadSingleAsync,
        LoadAdditiveAsync,
        UnloadAsync
    }

    #endregion

    #region Joystick

    public enum JoystickType 
    { 
        Fixed, 
        Floating, 
        Dynamic
    }

    public enum AxisOptions
    {
        Both,
        Horizontal,
        Vertical
    }

    #endregion
}
