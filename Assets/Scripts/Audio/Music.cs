using UnityEngine;

public class Music : MonoBehaviour
{
    private static GameObject music;

    private void Start()
    {
		if (music == null)
		{
            music = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
		{
            Destroy(gameObject);
		}
    }
}
