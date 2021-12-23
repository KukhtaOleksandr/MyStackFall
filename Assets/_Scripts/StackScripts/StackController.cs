using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField]
    private StackPartController[] stackPartControllers=null;

    public void ShatterAllParts()
    {
        
        if(transform.parent!=null)
            transform.parent = null;
        
        foreach(var ctrl in stackPartControllers)
        {
            ctrl.Shatter();
        }
    }
}
