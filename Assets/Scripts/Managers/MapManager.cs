using UnityEngine;
using Cinemachine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    [SerializeField] Transform parent;
    [SerializeField] GameObject finishPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject holePrefab;
    [SerializeField] GameObject hillPrefab;
    [SerializeField] GameObject targetGroup;
    public Map selectedMap;
    private Vector3 roverStartPosition;
    private Quaternion roverStartRotation;
    private Quaternion alienRotation;
    private Transform rover;

    public void ResetMap()
    {
        rover.position = roverStartPosition;
        rover.rotation = roverStartRotation;
    }

    private Quaternion CalculateRotation(int r)
    {
        Quaternion calculatedrotation;
        switch (r)
        {
            case 0:
                calculatedrotation = Quaternion.LookRotation(Vector3.forward * -1);
                break;
            case 1:
                calculatedrotation = Quaternion.LookRotation(Vector3.right * -1);
                break;
            case 2:
                calculatedrotation = Quaternion.LookRotation(Vector3.forward);
                break;
            case 3:
                calculatedrotation = Quaternion.LookRotation(Vector3.right);
                break;
            default:
                calculatedrotation = Quaternion.LookRotation(Vector3.forward);
                break;
        }
        return calculatedrotation;
    }

    private void Start()
    {
        rover = RoverManager.instance.rover.transform;
        roverStartRotation = CalculateRotation(selectedMap.roverRotation);
        alienRotation = CalculateRotation(selectedMap.alienRotation);
        int[,] map = selectedMap.GetMap();
        int z = map.GetLength(0);
        int x = map.GetLength(1);
        for (int zi = 0; zi < z; zi++)
        {
            for (int xi = 0; xi < x; xi++)
            {
                GameObject go = null;
                switch (map[zi, xi])
                {
                    case (int)TileType.StartTile:
                        Vector3 start = new Vector3(xi, 0.3f, -zi);
                        roverStartPosition = start;
                        rover.position = roverStartPosition;
                        rover.rotation = roverStartRotation;
                        go = Instantiate(pathPrefab, new Vector3(xi, 0f, -zi), Quaternion.LookRotation(Vector3.forward), parent); break;
                    case (int)TileType.FinishTile:
                        go = Instantiate(finishPrefab, new Vector3(xi, 0f, -zi), alienRotation, parent); break;
                    case (int)TileType.PathTile:
                        go = Instantiate(pathPrefab, new Vector3(xi, 0f, -zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;
                    case (int)TileType.HillTile:
                        go = Instantiate(hillPrefab, new Vector3(xi, 0f, -zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;
                    case (int)TileType.HoleTile:
                        go = Instantiate(holePrefab, new Vector3(xi, 0f, -zi), Quaternion.LookRotation(Vector3.forward), parent);
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