using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternationalChessSystem : MonoBehaviour
{
	public static InternationalChessSystem Instance;

	[Header ("Game Content")]
	public GameObject[] ChessBox; // 棋盒：存放各棋子prefab
	public Sprite[] ChessSprite; // 白棋：0~6、黑棋：7~12 (兵 城堡 騎士 主教 皇后 國王)
	public GameObject Checkerboard;
	public Grid[] CheckerboardGrids;
	public Transform[] StartingGrids; // 白棋：0~15、黑棋：16~31

	private List<Chess> WhiteChess = new List<Chess> ();
	private List<Chess> BlackChess = new List<Chess> ();

	[Header ("Game Play Use")]
	public Camp Player1_Camp;
	public Camp Player2_Camp;
	public Camp Turn_Camp = Camp.White;
	public Chess Selected_Chess;
	public List<Image> GridShow = new List<Image> (); // 點擊棋子所顯示的可移動方格

	void Awake ()
	{
		Instance = this;
	}

	void Start ()
	{
		CheckerboardGrids = Checkerboard.GetComponentsInChildren<Grid> (); // 將棋盤格按鈕讀入 checkerboard[] 裡
	}

	public void NewGameSetting ()
	{
		/* 先把棋子刪乾淨 */
		for (int i = 0; i < WhiteChess.Count; i++)
		{
			Destroy (WhiteChess[i].gameObject);
		}

		WhiteChess.Clear ();

		for (int i = 0; i < BlackChess.Count; i++)
		{
			Destroy (BlackChess[i].gameObject);
		}

		BlackChess.Clear ();

		for (int i = 0; i < 8; i++)
		{
			/* 生成棋子 - W_Pawn */
			GameObject w_pawn = Instantiate (ChessBox[0], StartingGrids[i]);
			w_pawn.GetComponent<Image> ().sprite = ChessSprite[0];
			w_pawn.GetComponent<Chess> ().Force = Camp.White;
			WhiteChess.Add (w_pawn.GetComponent<Chess> ());

			/* 生成棋子 - B_Pawn */
			GameObject b_pawn = Instantiate (ChessBox[0], StartingGrids[i + 16]);
			b_pawn.GetComponent<Image> ().sprite = ChessSprite[6];
			b_pawn.GetComponent<Chess> ().Force = Camp.Black;
			BlackChess.Add (b_pawn.GetComponent<Chess> ());
		}

		for (int i = 0; i < 2; i++)
		{
			/* 生成棋子 - W_Rook */
			GameObject w_rook = Instantiate (ChessBox[1], StartingGrids[i + 8]);
			w_rook.GetComponent<Image> ().sprite = ChessSprite[1];
			w_rook.GetComponent<Chess> ().Force = Camp.White;
			WhiteChess.Add (w_rook.GetComponent<Chess> ());

			/* 生成棋子 - B_Rook */
			GameObject b_rook = Instantiate (ChessBox[1], StartingGrids[i + 24]);
			b_rook.GetComponent<Image> ().sprite = ChessSprite[7];
			b_rook.GetComponent<Chess> ().Force = Camp.Black;
			BlackChess.Add (b_rook.GetComponent<Chess> ());

			/* 生成棋子 - W_Knight */
			GameObject w_knight = Instantiate (ChessBox[2], StartingGrids[i + 10]);
			w_knight.GetComponent<Image> ().sprite = ChessSprite[2];
			w_knight.GetComponent<Chess> ().Force = Camp.White;
			WhiteChess.Add (w_knight.GetComponent<Chess> ());

			/* 生成棋子 - B_Knight */
			GameObject b_knight = Instantiate (ChessBox[2], StartingGrids[i + 26]);
			b_knight.GetComponent<Image> ().sprite = ChessSprite[8];
			b_knight.GetComponent<Chess> ().Force = Camp.Black;
			BlackChess.Add (b_knight.GetComponent<Chess> ());

			/* 生成棋子 - W_Bishop */
			GameObject w_bishop = Instantiate (ChessBox[3], StartingGrids[i + 12]);
			w_bishop.GetComponent<Image> ().sprite = ChessSprite[3];
			w_bishop.GetComponent<Chess> ().Force = Camp.White;
			WhiteChess.Add (w_bishop.GetComponent<Chess> ());

			/* 生成棋子 - B_Bishop */
			GameObject b_bishop = Instantiate (ChessBox[3], StartingGrids[i + 28]);
			b_bishop.GetComponent<Image> ().sprite = ChessSprite[9];
			b_bishop.GetComponent<Chess> ().Force = Camp.Black;
			BlackChess.Add (b_bishop.GetComponent<Chess> ());
		}

		/* 生成棋子 - W_Queen */
		GameObject w_queen = Instantiate (ChessBox[4], StartingGrids[14]);
		w_queen.GetComponent<Image> ().sprite = ChessSprite[4];
		w_queen.GetComponent<Chess> ().Force = Camp.White;
		WhiteChess.Add (w_queen.GetComponent<Chess> ());

		/* 生成棋子 - B_Queen */
		GameObject b_queen = Instantiate (ChessBox[4], StartingGrids[30]);
		b_queen.GetComponent<Image> ().sprite = ChessSprite[10];
		b_queen.GetComponent<Chess> ().Force = Camp.Black;
		BlackChess.Add (b_queen.GetComponent<Chess> ());

		/* 生成棋子 - W_King */
		GameObject w_king = Instantiate (ChessBox[5], StartingGrids[15]);
		w_king.GetComponent<Image> ().sprite = ChessSprite[5];
		w_king.GetComponent<Chess> ().Force = Camp.White;
		WhiteChess.Add (w_king.GetComponent<Chess> ());

		/* 生成棋子 - B_King */
		GameObject b_king = Instantiate (ChessBox[5], StartingGrids[31]);
		b_king.GetComponent<Image> ().sprite = ChessSprite[11];
		b_king.GetComponent<Chess> ().Force = Camp.Black;
		BlackChess.Add (b_king.GetComponent<Chess> ());
	}
}