using UnityEngine;

public class MenuController : MonoBehaviour
{
	[SerializeField] private GameObject panel;

	private void Start()
	{
		panel.SetActive(false);
	}

	public void ActivateMenu()
	{
		panel.SetActive(true);
	}
}
