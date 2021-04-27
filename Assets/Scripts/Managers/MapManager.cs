using UnityEngine;
using Cinemachine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    [SerializeField] Transform parent;
    [SerializeField] GameObject finishPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject holePrefab;
    [SerializeField] GameObject hillPrefab;
    public Map selectedMap;
    [SerializeField] GameObject targetGroup;
    public GameObject[,] mapInstance;
    private Vector3 roverStartPosition;
    private Quaternion roverStartRotation;


    Transform rover;


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void ResetMap()
    {
        rover.position = roverStartPosition;
        rover.rotation = roverStartRotation;
    }

    private void Start()
    {
        rover = RoverManager.instance.rover.transform;
        int[,] map = selectedMap.GetMap();
        int z = map.GetLength(0);
        int x = map.GetLength(1);
        mapInstance = new GameObject[z, x];
        for (int zi = 0; zi < z; zi++)
        {
            for (int xi = 0; xi < x; xi++)
            {
                GameObject go = null;
                switch (map[zi, xi])
                {   
                    case (int)TileType.StartTile:
                        Vector3 start = new Vector3(xi, 0.3f, zi);
                        rover.position = start;
                        roverStartPosition = start;
                        roverStartRotation = rover.rotation;
                        go = Instantiate(pathPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        mapInstance[zi, xi] = go;
                        break;
                    case (int)TileType.FinishTile:
                        go = Instantiate(finishPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        mapInstance[zi, xi] = go;
                        break;
                    case (int)TileType.PathTile:
                        go = Instantiate(pathPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        mapInstance[zi, xi] = go;
                        break;
                    case (int)TileType.HillTile:
                        go = Instantiate(hillPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        mapInstance[zi, xi] = go;
                        break;
                    case (int)TileType.HoleTile:
                        go = Instantiate(holePrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        mapInstance[zi, xi] = go;
                        break;
                    default:
                        break;
                }
                if (go != null)
                {
                    targetGroup.GetComponent<CinemachineTargetGroup>().AddMember(go.transform, 1f, 2f);
                }
            }
        }
    }
}