using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_GUI : MonoBehaviour
{
	public static Main_GUI Instance;

	[Header ("View")]
	public Text TurnMessage;

	[Header ("Menu Button")]
	public Button Btn_WhiteCamp;
	public Button Btn_BlackCamp;
	public Button Btn_Exit;

	void Awake ()
	{
		Instance = this;
	}

	void Start ()
	{
		Btn_WhiteCamp.onClick.AddListener (OnClick_WhiteCamp);
		Btn_BlackCamp.onClick.AddListener (OnClick_BlackCamp);
		Btn_Exit.onClick.AddListener (OnClick_Quit);
	}

	#region UI
	public void OnClick_WhiteCamp ()
	{
		InternationalChessSystem.Instance.Player1_Camp = Camp.White;
		InternationalChessSystem.Instance.Player2_Camp = Camp.Black;

		InternationalChessSystem.Instance.NewGameSetting ();
	}

	public void OnClick_BlackCamp ()
	{
		InternationalChessSystem.Instance.Player1_Camp = Camp.Black;
		InternationalChessSystem.Instance.Player2_Camp = Camp.White;

		InternationalChessSystem.Instance.NewGameSetting ();
	}

	public void OnClick_Quit ()
	{
		Application.Quit ();
	}
	#endregion
}