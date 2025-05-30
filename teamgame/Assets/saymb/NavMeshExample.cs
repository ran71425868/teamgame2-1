using UnityEngine;
//using UnityEngine.AI;
//using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshExample : MonoBehaviour
{
    /// <summary>
    /// NavMeshSurface コンポーネント
    /// </summary>
    [SerializeField] private NavMeshSurface surface;

    void Start()
    {
       //this.surface = this.GetComponent<NavMeshSurface>();

        //this.surface = GameObject.FindObjectOfType<NavMeshSurface>();

        // NavMeshを動的に再生成
        this.surface.BuildNavMesh();


        //NavMeshSurface surface;
        //if (TryGetComponent<NavMeshSurface>(out surface))
        //{
        //    Debug.Log("surface取れた");

        //    // NavMeshを動的に再生成
        //    surface.BuildNavMesh();
        //}
        //else
        //{
        //    Debug.Log("surfaceとれん");
        //    //}
        //}
    }

    void Update()
    {
        //NavMeshSurface surface;
        //if (TryGetComponent<NavMeshSurface>(out surface))
        //{
        //    Debug.Log("surface取れた");

        //    //NavMeshを動的に再生成
        //    surface.BuildNavMesh();
        //}
        //else
        //{
        //    Debug.Log("surfaceとれん");
        //}
    }

    public void ClickStartButton()
    {
        // NavMeshを動的に再生成
        this.surface.BuildNavMesh();

        Debug.Log("ナビメッシュ再生成");
    }
}