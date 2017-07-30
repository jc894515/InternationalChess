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
				InternationalChessSystem.Instance.Selected_Chess.transform.SetParent (transform);
				InternationalChessSystem.Instance.Selected_Chess.transform.localPosition = Vector2.zero;
				InternationalChessSystem.Instance.Selected_Chess = null;
			}
		}
	}
}