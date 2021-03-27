using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public void StartMap(int index)
    {
        SceneManager.LoadScene(index);
    }
}
