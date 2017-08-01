using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour
{
	public ChessType Type; // 兵種
	public Camp Force; // 陣營所屬勢力

	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (OnClick_Chess);
	}

	protected virtual void OnClick_Chess ()
	{
		for (int i = 0; i < InternationalChessSystem.Instance.GridShow.Count; i++)
		{
			if (InternationalChessSystem.Instance.GridShow[i].transform == transform.parent)
			{
				InternationalChessSystem.Instance.Selected_Chess.transform.SetParent (transform.parent);
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

				/* 把Chess從List Remove掉 */
				if (Force == Camp.White)
				{
					InternationalChessSystem.Instance.Turn_Camp = Camp.White; // 哪方被吃掉，意味著下回合是該方行動
					Main_GUI.Instance.TurnMessage.text = "輪到白棋";
				}
				else
				{
					InternationalChessSystem.Instance.Turn_Camp = Camp.Black; // 哪方被吃掉，意味著下回合是該方行動
					Main_GUI.Instance.TurnMessage.text = "輪到黑棋";
				}

				Destroy (gameObject);
			}
		}
	}
}