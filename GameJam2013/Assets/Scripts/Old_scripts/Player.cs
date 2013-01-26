using UnityEngine;
using System.Collections;

public class Player : CharacterBasics {
	
    #region Mono Inherit Functions
	
	public void Update()
	{
        if (GameManager.gameState != GameState.PlayGame)
            return;


        base.BaseMovement(InputMovement(), InputMovement().magnitude );
		if (Input.GetButtonDown("Jump"))
		{
			base.Launch();
		}
        if (Input.GetButtonDown("Rush"))
        {
            base.Rush(trans.forward, 30);
        }
	}

    #endregion

    #region Utilities

    /// <summary>
    /// Recieves the input from the axes
    /// </summary>
    /// <returns>
    /// The movement.
    /// </returns>
    private Vector2 InputMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    #endregion


}