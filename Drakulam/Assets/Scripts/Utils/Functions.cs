using UnityEngine;

namespace Utils
{
    public class Functions
    {
        public static GameObject GetChildWithName(MonoBehaviour parent, string childName)
        {
            foreach (Transform child in parent.transform)
            {
                var gameobj = child.gameObject;
                if (gameobj.name == childName)
                    return gameobj;
            }
            return null;
        }

        public static TScript GetScriptOnChild<TScript>(MonoBehaviour parent, string childName)
        {
            var childGameObj = GetChildWithName(parent, childName);
            if (childGameObj == null)
                return default(TScript);
            
            return childGameObj.GetComponent<TScript>();
        }
    }
}