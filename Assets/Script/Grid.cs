using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (OnClick_Grid);
	}

	private void OnClick_Grid ()
	{
		for (int i = 0; i < InternationalChessSystem.Instance.GridShow.Count; i++)
		{
			if (InternationalChessSystem.Instance.GridShow[i].gameObject == gameObject)
			{
				InternationalChessSystem.Instance.Selected_Chess.transform.SetParent (transform);
				InternationalChessSystem.Instance.Selected_Chess.transform.localPosition = Vector2.zero;
				InternationalChessSystem.Instance.Selected_Chess = null;

				for (int j = 0; j < InternationalChessSystem.Instance.GridShow.Count; j++)
				{
					InternationalChessSystem.Instance.GridShow[j].color = Color.clear;
				}
				InternationalChessSystem.Instance.GridShow.Clear ();

				if (InternationalChessSystem.Instance.Turn_Camp == Camp.White)
				{
					InternationalChessSystem.Instance.Turn_Camp = Camp.Black;
				}
				else
				{
					InternationalChessSystem.Instance.Turn_Camp = Camp.White;
				}
				break;
			}
		}
	}
}