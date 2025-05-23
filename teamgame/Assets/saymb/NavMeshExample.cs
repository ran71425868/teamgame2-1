using UnityEngine;
//using UnityEngine.AI;
//using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshExample : MonoBehaviour
{
   void Start()
    {
        NavMeshSurface surface;
        if(TryGetComponent<NavMeshSurface>(out surface))
        {
            Debug.Log("surfaceæ‚ê‚½");

            // NavMesh‚ğ“®“I‚ÉÄ¶¬
            surface.BuildNavMesh();
        }
        else
        {
            Debug.Log("surface‚Æ‚ê‚ñ");
        }
    }

    void Update()
    {
    }
}
