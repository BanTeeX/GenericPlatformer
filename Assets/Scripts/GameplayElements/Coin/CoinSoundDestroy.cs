using UnityEngine;

public class CoinSoundDestroy : MonoBehaviour
{
    private void Update()
    {
		if (GetComponent<AudioSource>().isPlaying == false)
		{
			Destroy(gameObject);
		}
    }
}
