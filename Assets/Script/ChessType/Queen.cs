using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Queen : Chess
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

			A (x, y); // ↑
			B (x, y); // ↗
			C (x, y); // -→
			D (x, y); // ↘
			E (x, y); // ↓
			F (x, y); // ↙
			G (x, y); // ←-
			H (x, y); // ↖
		}
		else
		{
			base.OnClick_Chess ();
		}
	}

	#region 8方位計算
	private void A (int x, int y) // ↑
	{
		int i = 1;
		while (y + i < 9)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x, y + i));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void B (int x, int y) // ↗
	{
		int i = 1;
		while (x + i < 9 && y + i < 9)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x + i, y + i));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void C (int x, int y) // -→
	{
		int i = 1;
		while (x + i < 9)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x + i, y));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void D (int x, int y) // ↘
	{
		int i = 1;
		while (x + i < 9 && y - i > 0)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x + i, y - i));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void E (int x, int y) // ↓
	{
		int i = 1;
		while (y - i > 0)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x, y - i));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void F (int x, int y) // ↙
	{
		int i = 1;
		while (x - i > 0 && y - i > 0)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x - i, y - i));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void G (int x, int y) // ←-
	{
		int i = 1;
		while (x - i > 0)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x - i, y));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}

	private void H (int x, int y) // ↖
	{
		int i = 1;
		while (x - i > 0 && y + i < 9)
		{
			Transform search_result = InternationalChessSystem.Instance.Checkerboard.transform.Find (string.Format ("{0},{1}", x - i, y + i));

			if (search_result != null)
			{
				if (search_result.childCount == 0)
				{
					search_result.GetComponent<Image> ().color = new Color (0, 1, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
				}
				else if (search_result.GetComponentInChildren<Chess> ().Force != Force) // 敵隊
				{
					search_result.GetComponent<Image> ().color = new Color (1, 0, 0, 0.5f);
					InternationalChessSystem.Instance.GridShow.Add (search_result.GetComponent<Image> ());
					break;
				}
				else // 同隊
				{
					break;
				}

				i++;
			}
		}
	}
	#endregion
}