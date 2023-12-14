using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject scene;
    [SerializeField] public SceneInfo sceneInfo;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        SceneManager.LoadScene(scene.name);
    }
}
