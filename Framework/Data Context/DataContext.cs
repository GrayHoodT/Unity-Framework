using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataContext
{
    private static Dictionary<string, object> dataDict = new Dictionary<string, object>();

    public static void AddData<T>(string path, T value) 
    {
        if (dataDict.ContainsKey(path) == true)
        {
            Debug.LogWarning($"This path already exists. : {path}");
            return;
        }

        dataDict[path] = new DataNode<T>(value);
    }

    public static void RemoveData<T>(string path)
    {
        if (dataDict.ContainsKey(path) == false)
        {
            Debug.LogWarning($"The path does not exist. : {path}");
            return;
        }

        dataDict.Remove(path);
    }

    public static void SetData<T>(string path, T value)
    {
        if (dataDict.ContainsKey(path) == true)
        {
            Debug.LogWarning($"The path does not exist. : {path}");
            return;
        }

        ((DataNode<T>)dataDict[path]).SetValue(value);
    }

    public static T GetData<T>(string path) 
    {
        if (dataDict.ContainsKey(path) == false)
        {
            Debug.LogWarning($"The path does not exist. : {path}");
            return default(T);
        }

        return ((DataNode<T>)dataDict[path]).GetValue();
    }

    public static void Subscribe<T>(string path, Action<T> action)
    {
        if (dataDict.ContainsKey(path) == false)
        {
            Debug.LogWarning($"The path does not exist. : {path}");
            return;
        }

        ((DataNode<T>)dataDict[path]).Subscribe(action);
    }

    public static void Unsubscribe<T>(string path, Action<T> action) 
    {
        if (dataDict.ContainsKey(path) == false)
        {
            Debug.LogWarning($"The path does not exist. : {path}");
            return;
        }

        ((DataNode<T>)dataDict[path]).Unsubscribe(action);
    }
}
