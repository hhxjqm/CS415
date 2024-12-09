using UnityEngine;

public class UIHandle : MonoBehaviour
{
    public void RestartScene()
    {
        GameManager.instance.RestartScene();
    }
}
