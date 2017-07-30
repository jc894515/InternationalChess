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
				if (y == 2) // 如果是第一步
				{
					
				}
				else
				{
					
				}
			}
			else if (InternationalChessSystem.Instance.Turn_Camp == Camp.White)
			{
				if (y == 7) // 如果是第一步
				{

				}
				else
				{

				}
			}
		}
		else
		{
			base.OnClick_Chess ();
		}
	}


}