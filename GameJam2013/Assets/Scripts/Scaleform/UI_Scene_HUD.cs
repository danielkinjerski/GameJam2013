using System;
using UnityEngine;
using System.Runtime.InteropServices;
using Scaleform;
using Scaleform.GFx;

public class UI_Scene_HUD : Movie
{
	protected Value hudMovie = null;
	private GameManager gManager;
	public bool pauseMenuOpen = false;
	
	// Required to implement this constructor.
	public UI_Scene_HUD(SFManager sfmgr, SFMovieCreationParams cp):
		base(sfmgr, cp)
	{
		if (MovieID != -1)
		{
		//	SetBackgroundAlpha(1);
		}
		
		// 
	}
	
	public GameManager GManager
	{
		get 
		{
			if(gManager == null)
			{
				gManager = GameObject.Find("GameManager").GetComponent<GameManager>();	
			}
			
			return gManager;
		}	
	}
	
	// Callback from the content that provides a reference to the MainMenu object once it's fully loaded.
	public void OnRegisterSWFCallback(Value movieRef)
	{
		Debug.Log("UI_Scene_MainMenu::OnRegisterSWFCallback()");
		hudMovie = movieRef;
		Console.WriteLine("mainmenu type = " + hudMovie.type);
		Init();
	}
	
	public void Init()
	{
		 
	}

	// Callback from the content that provides a reference to the MainMenu object once it's fully loaded.
	public void RegisterMovies(Value movieRef)
	{
		hudMovie = movieRef;
	}

	
	public void OnStartButtonClick()
	{
		Debug.Log("START GAME HAS BEEN CLICKED");
		GManager.Play();
		
	}

	// Callback from the content to launch the game when the "close" animation has finished playing.
	public void OnExitGameCallback()
	{
		Console.WriteLine("In OnExitGameCallback");
		sfMgr.DestroyMovie(this);
		// Application.Quit() is Ignored in the editor!
		OpenHUD();
		Application.Quit();
		// Application.LoadLevelAsync("Level");
		// Destroy(this); // NFM: Do our Value references need to be cleared? How do we cleanup a movie?
	}
	
	public void ExitGame()
	{
		Debug.Log("THE GAME WILL NOW EXIT");
		OnExitGameCallback();
	}
	
	public void OnMainMenuClick()
	{
		Debug.Log("Go to main menu");	
		GManager.BackToMain();
	}
	
	public void OnResumeGameButtonClick()
	{
		Debug.Log("Resume clicked");
		
		GManager.ResumeGame();
	}
	
	public void PauseGame()
	{
		Invoke("root.PauseGame", null, 0);
	}
	
	public void OpenHUD()
	{
		Invoke("root.OpenHUD", null, 0);	
	}
	
	
	public void OpenMainMenu()
	{
		Invoke("root.OpenPauseMenu", null, 0);	
	}
	
	public void OpenEndGameMenu()
	{
		Invoke("root.OpenEndGameMenu", null, 0);
	}
	
	
	public void ClosePauseMenu()
	{
		Invoke("root.ClosePauseMenu", null, 0);
		pauseMenuOpen = false;
	}
	
	public void CloseMainMenu()
	{
		Invoke("root.OpenPauseMenu", null, 0);
	}
	
	public void CloseEndGameMenu()
	{
		Invoke("root.CloseEndGameMenu", null, 0);
	}
		
	
}