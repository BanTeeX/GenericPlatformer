using UnityEngine;

public class Parallax : MonoBehaviour
{
	[SerializeField] private GameObject cam;
	[SerializeField] private float parallaxEffect;

	private float length;
	private float startpos;
	private float ypos;

	private void Start()
	{
		startpos = transform.position.x;
		ypos = transform.position.y;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	private void Update()
	{
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		float dist = (cam.transform.position.x * parallaxEffect);
		float ydist = (cam.transform.position.y * parallaxEffect);

		transform.position = new Vector3(startpos + dist, ypos + ydist, transform.position.z);
		if (temp > startpos + length)
		{
			startpos += length;
		}
		else if (temp < startpos - length)
		{
			startpos -= length;
		}
	}
}