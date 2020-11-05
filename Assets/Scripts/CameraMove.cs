using UnityEngine;

public class CameraMove : MonoBehaviour
{
	[SerializeField] private bool isFollowingPlayer = true;
	[SerializeField] private Transform player;

	private void Update()
	{
		if (isFollowingPlayer)
		{
			transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
		}
	}
}
