using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static T AddComponentIfNoExist<T>(this Transform trans) where T : Component
    {
        T t = trans.GetComponent<T>();
        if (t == null) t = trans.gameObject.AddComponent<T>();
        return t;
    }
}
