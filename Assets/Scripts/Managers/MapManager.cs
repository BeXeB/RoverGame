using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    [SerializeField] Transform parent;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject holePrefab;
    [SerializeField] GameObject hillPrefab;
    [SerializeField] Map selectedMap;
    public GameObject[,] mapInstance;


    RoverMovement player;


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }



    private void Start()
    {
        player = RoverManager.instance.rover.GetComponent<RoverMovement>();

        int[,] map = selectedMap.getMap();
        int z = map.GetLength(0);
        int x = map.GetLength(1);
        mapInstance = new GameObject[z, x];
        for (int zi = 0; zi < z; zi++)
        {
            for (int xi = 0; xi < x; xi++)
            {
                switch (map[zi, xi])
                {
                    case 0:
                        Vector3 dest = new Vector3(xi, 0.55f, zi);
                        player.transform.position = dest;
                        mapInstance[zi, xi] = Instantiate(pathPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;
                    case 1:
                        mapInstance[zi, xi] = Instantiate(pathPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;
                    case 2:
                        mapInstance[zi, xi] = Instantiate(hillPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;
                    case 3:
                        mapInstance[zi, xi] = Instantiate(holePrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;
                    default:
                        mapInstance[zi, xi] = Instantiate(hillPrefab, new Vector3(xi, 0f, zi), Quaternion.LookRotation(Vector3.forward), parent);
                        break;

                }
            }
        }
    }
}