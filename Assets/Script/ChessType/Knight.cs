using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Chess
{
	protected override void OnClick_Chess ()
	{
		/* 顯示可移動範圍 */
		if (InternationalChessSystem.Instance.Turn_Camp == Force)
		{
			InternationalChessSystem.Instance.Selected_Chess = this;

			string[] coordinate = transform.parent.name.Split (',');
			int x = Convert.ToInt32 (coordinate[0]);
			int y = Convert.ToInt32 (coordinate[1]);

			CheckGrid (x + 1, y + 2);
			CheckGrid (x + 2, y + 1);
			CheckGrid (x + 2, y - 1);
			CheckGrid (x + 1, y - 2);
			CheckGrid (x - 1, y - 2);
			CheckGrid (x - 2, y - 1);
			CheckGrid (x - 2, y + 1);
			CheckGrid (x - 1, y + 2);
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
}