using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : Chess
{
	protected override void OnClick_Chess ()
	{
		/* 顯示可移動範圍 */
		if (InternationalChessSystem.Instance.Turn_Camp == Force)
		{
			InternationalChessSystem.Instance.Selected_Chess = this;

			string[] coordinate = transform.parent.gameObject.name.Split (',');
			int x = Convert.ToInt32 (coordinate[0]);
			int y = Convert.ToInt32 (coordinate[1]);

			if (InternationalChessSystem.Instance.Turn_Camp == Camp.White)
			{
				CheckGrid (x, y + 1); // ↑

				if (y == 2) // 如果是第一次移動，可以走到兩步
				{
					CheckGrid (x, y + 2); // ↑↑
				}

				CheckGrid_PawnAttack (x + 1, y + 1); // ↗
				CheckGrid_PawnAttack (x - 1, y + 1); // ↖
			}
			else if (InternationalChessSystem.Instance.Turn_Camp == Camp.Black)
			{
				CheckGrid (x, y - 1); // ↓

				if (y == 7) // 如果是第一次移動，可以走到兩步
				{
					CheckGrid (x, y - 2); // ↓↓
				}

				CheckGrid_PawnAttack (x + 1, y - 1); // ↘
				CheckGrid_PawnAttack (x - 1, y - 1); // ↙
			}
		}
		else
		{
			base.OnClick_Chess ();
		}
	}

	private void CheckGrid (int x, int y)
	{
		Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x, y));

		/* 檢查「格子」是否存在 */
		if (search_result != null) 
		{
			/* 檢查「格子」是否有棋子在上面 */
			if (search_result.childCount == 0)  // 空格
			{
				search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
				InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
			}
			else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
			{
				search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
				InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
			}
		}
	}

	private void CheckGrid_PawnAttack (int x, int y)
	{
		Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x, y));

		/* 檢查「格子」是否存在 */
		if (search_result != null) 
		{
			/* 檢查「格子」是否有棋子在上面 */
			if (search_result.childCount != 0)  // 空格
			{
				if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
			}
		}
	}
}