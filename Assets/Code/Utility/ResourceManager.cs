using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour{

    public static ResourceManager Inst { get { return m_Inst; } }
    static ResourceManager m_Inst;

    Dictionary<string, UnityEngine.Object> cachedObjects = new Dictionary<string, UnityEngine.Object>();

    public ResourceManager()
    {
        if (m_Inst == null)
            m_Inst = this;
    }

    public static GameObject Create(string prefabName)
    {
        if (!Inst.cachedObjects.ContainsKey(prefabName))
        {
            Inst.cachedObjects[prefabName] = Resources.Load(prefabName);
        }

        return UnityEngine.Object.Instantiate(Inst.cachedObjects[prefabName]) as GameObject;
    }
}
