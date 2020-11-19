using UnityEngine;

public class MenuController : MonoBehaviour
{
	[SerializeField] private GameObject panel;

	private void Start()
	{
		Cursor.visible = false;
		panel.SetActive(false);
	}

	public void ActivateMenu()
	{
		Cursor.visible = true;
		panel.SetActive(true);
	}
}
