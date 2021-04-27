using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public static MapSelection instance;

    private void Awake()
    {
        instance = this;
    }
    public Map map;
    public void StartMap()
    {
        SceneManager.LoadScene(1);
    }
}
