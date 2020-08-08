using UnityEngine;
using UnityEngine.AI;

public class LoadNavmesh : MonoBehaviour
{
    [SerializeField] string assetname = "Cube";

    private NavMeshDataInstance instance;

    void OnEnable()
    {
        // NavMeshの登録
        var data = Resources.Load<NavMeshData>(assetname);
        instance = NavMesh.AddNavMeshData(data);
    }

    void OnDisable()
    {
        // NavMeshの破棄
        NavMesh.RemoveNavMeshData(instance);
    }
}