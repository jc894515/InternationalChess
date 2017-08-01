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
				InternationalChessSystem.Instance.Re_GridShow ();

				/* Pawn的升變 */
				if (InternationalChessSystem.Instance.Selected_Chess.name == "Pawn")
				{
					string[] coordinate = InternationalChessSystem.Instance.Selected_Chess.transform.name.Split (',');

					if (int.Parse (coordinate[1]) == 1 || int.Parse (coordinate[1]) == 8)
					{
						InternationalChessSystem.Instance.PromotionMenu.SetActive (true);
					}
					else
					{
						InternationalChessSystem.Instance.Selected_Chess = null;
					}
				}
				else
				{
					InternationalChessSystem.Instance.Selected_Chess = null;
				}

				if (InternationalChessSystem.Instance.Turn_Camp == Camp.White)
				{
					InternationalChessSystem.Instance.Turn_Camp = Camp.Black;
					Main_GUI.Instance.TurnMessage.text = "輪到黑棋";
				}
				else
				{
					InternationalChessSystem.Instance.Turn_Camp = Camp.White;
					Main_GUI.Instance.TurnMessage.text = "輪到白棋";
				}
				break;
			}
		}
	}
}