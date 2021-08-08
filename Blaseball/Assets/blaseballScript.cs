//code by Krazztar

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class blaseballScript : MonoBehaviour
{
	public new KMAudio audio;
	public KMBombInfo bomb;

	public KMSelectable buttonSubmit;
	public KMSelectable buttonLeftAway;
	public KMSelectable buttonRightAway;
	public KMSelectable buttonLeftHome;
	public KMSelectable buttonRightHome;

	int awaySolve = 0;
	int awayTeamMenu = 26;
	public String[] awayTeamSelected;
	int awayTeamSelectedSolve = 26;

	int homeSolve = 0;
	int homeTeamMenu = 26;
	public String[] homeTeamSelected;
	int homeTeamSelectedSolve = 26;

	List<int> trueTeamSelected = new List<int>
	{
		5, 23, 6, 3, 22, 19, 0, 17, 13, 2, 20, 8, 9, 21, 7, 4, 10, 15, 11, 12, 14, 16, 1, 18, 24, 25, 26
	};

	int[,] weatherSolve = new int[4,18]
	{
		//Number, Even SN
		{10, 2, 11, 4, 12, 6, 13, 8, 14, 24, 16, 25, 18, 26, 20, 27, 22, 28},
		//Number, Odd SN
		{1, 2, 3, 4, 5, 6, 7, 8, 9, 15, 16, 17, 18, 19, 20, 21, 22, 23},
		//Letter, Even SN
		{22, 21, 20, 19, 18, 17, 16, 15, 14, 9, 8, 7, 6, 5, 4, 3, 2, 1},
		//Letter, Odd SN
		{22, 26, 20, 25, 18, 24, 16, 23, 14, 9, 13, 7, 12, 5, 11, 3, 10, 1}
	};

	List<int> teamFontSize = new List<int>
	{
		41, 42, 42, 28, 33, 28, 35, 42, 42, 42, 42, 33, 42, 28, 36, 29, 42, 33, 42, 42, 33, 42, 42, 37, 25, 42, 42
	};

	string[,] weatherLetters = new string[2,18]
	{
		//Letter, Even SN
		{"V", "U", "T", "S", "R", "Q", "P", "O", "N", "I", "H", "G", "F", "E", "D", "C", "B", "A"},
		//Letter, Odd SN
		{"V", "Z", "T", "Y", "R", "X", "P", "W", "N", "I", "M", "G", "L", "E", "K", "C", "J", "A"}
	};

	public String[] teamOptions;
	public String[] weatherOptions;
	public Color[] teamColors;
	public Sprite[] weatherSprites;
	public SpriteRenderer[] weatherSlots;

	int snOddEven = 1;

	public TextMesh awayTeam;
	public TextMesh homeTeam;


	// ------

	// LOGGING

	// ------

	static int moduleIdCounter = 1;
	int moduleId;
	private bool moduleSolved;



	// ------

	// THE AWAKENING

	// ------

	void Awake()
	{
			moduleId = moduleIdCounter++;

			buttonSubmit.OnInteract += delegate () { PressButtonSubmit(); return false; };
			buttonLeftAway.OnInteract += delegate () { PressButtonLeftAway(); return false; };
			buttonRightAway.OnInteract += delegate () { PressButtonRightAway(); return false; };
			buttonLeftHome.OnInteract += delegate () { PressButtonLeftHome(); return false; };
			buttonRightHome.OnInteract += delegate () { PressButtonRightHome(); return false; };
	}



	// ------

	// MODULE BEGIN!

	// ------

	void Start ()
	{
			DetermineSolveStep1();
	}



	// ------

	// STEP 1

	// ------

	void DetermineSolveStep1()
	{
			//Dividing serial number into character values
			string serialNumber = bomb.GetSerialNumber();
			char[] serialNumberSplit = serialNumber.ToCharArray();

			if (serialNumber[5] == '0' || serialNumber[5] == '2' || serialNumber[5] == '4' || serialNumber[5] == '6' || serialNumber[5] == '8')
				{
					snOddEven = snOddEven - 1;
				}

			//Telling the debug log which serial number character it's on
			int sn = 1;

			//Calculating the additions to awaySolve and homeSolve from the serial number values
			foreach (char snValue in serialNumberSplit)
			{

				//Letters
				if (snValue >= 'A' && snValue <= 'Z')
				{
					Debug.LogFormat("[Blaseball #{0}] SN CHARACTER #{1}: {2}", moduleId, sn, snValue);

					if (snValue == 'A')
					{
						awaySolve = awaySolve + 1;
						Debug.LogFormat("[Blaseball #{0}] A converts to 1. Add 1 to the Away Team Value.", moduleId);
					}

					if (snValue == 'B')
					{
						awaySolve = awaySolve + 2;
						Debug.LogFormat("[Blaseball #{0}] B converts to 2. Add 2 to the Away Team Value.", moduleId);
					}

					if (snValue == 'C')
					{
						awaySolve = awaySolve + 3;
						Debug.LogFormat("[Blaseball #{0}] C converts to 3. Add 3 to the Away Team Value.", moduleId);
					}

					if (snValue == 'D')
					{
						awaySolve = awaySolve + 4;
						Debug.LogFormat("[Blaseball #{0}] D converts to 4. Add 4 to the Away Team Value.", moduleId);
					}

					if (snValue == 'E')
					{
						awaySolve = awaySolve + 5;
						Debug.LogFormat("[Blaseball #{0}] E converts to 5. Add 5 to the Away Team Value.", moduleId);
					}

					if (snValue == 'F')
					{
						awaySolve = awaySolve + 6;
						Debug.LogFormat("[Blaseball #{0}] F converts to 6. Add 6 to the Away Team Value.", moduleId);
					}

					if (snValue == 'G')
					{
						awaySolve = awaySolve + 7;
						Debug.LogFormat("[Blaseball #{0}] G converts to 7. Add 7 to the Away Team Value.", moduleId);
					}

					if (snValue == 'H')
					{
						awaySolve = awaySolve + 8;
						Debug.LogFormat("[Blaseball #{0}] H converts to 8. Add 8 to the Away Team Value.", moduleId);
					}

					if (snValue == 'I')
					{
						awaySolve = awaySolve + 9;
						Debug.LogFormat("[Blaseball #{0}] I converts to 9. Add 9 to the Away Team Value.", moduleId);
					}

					if (snValue == 'J')
					{
						awaySolve = awaySolve + 10;
						Debug.LogFormat("[Blaseball #{0}] J converts to 10. Add 10 to the Away Team Value.", moduleId);
					}

					if (snValue == 'K')
					{
						awaySolve = awaySolve + 11;
						Debug.LogFormat("[Blaseball #{0}] K converts to 11. Add 11 to the Away Team Value.", moduleId);
					}

					if (snValue == 'L')
					{
						awaySolve = awaySolve + 12;
						Debug.LogFormat("[Blaseball #{0}] L converts to 12. Add 12 to the Away Team Value.", moduleId);
					}

					if (snValue == 'M')
					{
						awaySolve = awaySolve + 13;
						Debug.LogFormat("[Blaseball #{0}] M converts to 13. Add 13 to the Away Team Value.", moduleId);
					}

					if (snValue == 'N')
					{
						awaySolve = awaySolve + 14;
						Debug.LogFormat("[Blaseball #{0}] N converts to 14. Add 14 to the Away Team Value.", moduleId);
					}

					if (snValue == 'O')
					{
						awaySolve = awaySolve + 15;
						Debug.LogFormat("[Blaseball #{0}] O converts to 15. Add 15 to the Away Team Value.", moduleId);
					}

					if (snValue == 'P')
					{
						awaySolve = awaySolve + 16;
						Debug.LogFormat("[Blaseball #{0}] P converts to 16. Add 16 to the Away Team Value.", moduleId);
					}

					if (snValue == 'Q')
					{
						awaySolve = awaySolve + 17;
						Debug.LogFormat("[Blaseball #{0}] Q converts to 17. Add 17 to the Away Team Value.", moduleId);
					}

					if (snValue == 'R')
					{
						awaySolve = awaySolve + 18;
						Debug.LogFormat("[Blaseball #{0}] R converts to 18. Add 18 to the Away Team Value.", moduleId);
					}

					if (snValue == 'S')
					{
						awaySolve = awaySolve + 19;
						Debug.LogFormat("[Blaseball #{0}] S converts to 19. Add 19 to the Away Team Value.", moduleId);
					}

					if (snValue == 'T')
					{
						awaySolve = awaySolve + 20;
						Debug.LogFormat("[Blaseball #{0}] T converts to 20. Add 20 to the Away Team Value.", moduleId);
					}

					if (snValue == 'U')
					{
						awaySolve = awaySolve + 21;
						Debug.LogFormat("[Blaseball #{0}] U converts to 21. Add 21 to the Away Team Value.", moduleId);
					}

					if (snValue == 'V')
					{
						awaySolve = awaySolve + 22;
						Debug.LogFormat("[Blaseball #{0}] V converts to 22. Add 22 to the Away Team Value.", moduleId);
					}

					if (snValue == 'W')
					{
						awaySolve = awaySolve + 23;
						Debug.LogFormat("[Blaseball #{0}] W converts to 23. Add 23 to the Away Team Value.", moduleId);
					}

					if (snValue == 'X')
					{
						awaySolve = awaySolve + 24;
						Debug.LogFormat("[Blaseball #{0}] X converts to 24. Add 24 to the Away Team Value.", moduleId);
					}

					if (snValue == 'Y')
					{
						awaySolve = awaySolve + 25;
						Debug.LogFormat("[Blaseball #{0}] Y converts to 25. Add 25 to the Away Team Value.", moduleId);
					}

					if (snValue == 'Z')
					{
						awaySolve = awaySolve + 26;
						Debug.LogFormat("[Blaseball #{0}] Z converts to 26. Add 26 to the Away Team Value.", moduleId);
					}

				}

				//Numbers
				else
				{

					Debug.LogFormat("[Blaseball #{0}] SN CHARACTER #{1}: {2}", moduleId, sn, snValue);

					if (snValue == '0')
					{
						Debug.LogFormat("[Blaseball #{0}] The Home Team Value stays the same.", moduleId);
					}

					if (snValue == '1')
					{
						homeSolve = homeSolve + 1;
						Debug.LogFormat("[Blaseball #{0}] Add 1 to the Home Team Value.", moduleId);
					}

					if (snValue == '2')
					{
						homeSolve = homeSolve + 2;
						Debug.LogFormat("[Blaseball #{0}] Add 2 to the Home Team Value.", moduleId);
					}

					if (snValue == '3')
					{
						homeSolve = homeSolve + 3;
						Debug.LogFormat("[Blaseball #{0}] Add 3 to the Home Team Value.", moduleId);
					}

					if (snValue == '4')
					{
						homeSolve = homeSolve + 4;
						Debug.LogFormat("[Blaseball #{0}] Add 4 to the Home Team Value.", moduleId);
					}

					if (snValue == '5')
					{
						homeSolve = homeSolve + 5;
						Debug.LogFormat("[Blaseball #{0}] Add 5 to the Home Team Value.", moduleId);
					}

					if (snValue == '6')
					{
						homeSolve = homeSolve + 6;
						Debug.LogFormat("[Blaseball #{0}] Add 6 to the Home Team Value.", moduleId);
					}

					if (snValue == '7')
					{
						homeSolve = homeSolve + 7;
						Debug.LogFormat("[Blaseball #{0}] Add 7 to the Home Team Value.", moduleId);
					}

					if (snValue == '8')
					{
						homeSolve = homeSolve + 8;
						Debug.LogFormat("[Blaseball #{0}] Add 8 to the Home Team Value.", moduleId);
					}

					if (snValue == '9')
					{
						homeSolve = homeSolve + 9;
						Debug.LogFormat("[Blaseball #{0}] Add 9 to the Home Team Value.", moduleId);
					}

				}

				//State the current Away and Home Team values.
				StateValues();

				//Tell the debug log which serial number character it's on
				sn = sn + 1;

			}

			DetermineSolveStep2();

	}



	// ------

	// STEP 2

	// ------

	void DetermineSolveStep2()
	{
			System.Random weather = new System.Random();

			int weatherValue = 0;
			int w = 1;

			for (int i = 0; i < 3; i++)
			{
					//Randomize the weather value
					weatherValue = (weather.Next(18) * ((moduleId * 2) - 1)) % 18;

					//Display images
					weatherSlots[i].sprite = weatherSprites[weatherValue];

					//State what the weather value is
					Debug.LogFormat("[Blaseball #{0}] Weather #{1}: {2}", moduleId, w, weatherOptions[weatherValue]);

					//Add to awaySolve and homeSolve
					awaySolve = awaySolve + weatherSolve[snOddEven,weatherValue];
					homeSolve = homeSolve + weatherSolve[(snOddEven + 2),weatherValue];

					if (snOddEven == 0)
					{
							Debug.LogFormat("[Blaseball #{0}] The number value for {1} with an even last digit is {2}. Add {2} to the Away Team Value.", moduleId, weatherOptions[weatherValue], weatherSolve[snOddEven,weatherValue]);

							Debug.LogFormat("[Blaseball #{0}] The letter value for {1} with an even last digit is {2}, which converts to {3}. Add {3} to the Home Team Value.", moduleId, weatherOptions[weatherValue], weatherLetters[snOddEven,weatherValue], weatherSolve[(snOddEven + 2),weatherValue]);
					}

					else
					{
							Debug.LogFormat("[Blaseball #{0}] The number value for {1} with an odd last digit is {2}. Add {2} to the Away Team Value.", moduleId, weatherOptions[weatherValue], weatherSolve[snOddEven,weatherValue]);

							Debug.LogFormat("[Blaseball #{0}] The letter value for {1} with an odd last digit is {2}, which converts to {3}. Add {3} to the Home Team Value.", moduleId, weatherOptions[weatherValue], weatherLetters[snOddEven,weatherValue], weatherSolve[(snOddEven + 2),weatherValue]);
					}

					//State the current Away and Home Team values.
					StateValues();

					//Reset the weather value to 0, otherwise it would add and modulo
					weatherValue = 0;

					//Tell the debug log which weather number it's on
					w = w + 1;
			}

			DetermineSolveStep3();

	}



	// ------

	// STEP 3

	// ------

	void DetermineSolveStep3()
	{
			//Modulo awaySolve and homeSolve to get the final values.
			awaySolve = awaySolve % 26;
			homeSolve = homeSolve % 24;

			//State the final Away and Home Team values.
			Debug.LogFormat("[Blaseball #{0}] FINAL VALUES", moduleId);
			Debug.LogFormat("[Blaseball #{0}] Away Team: {1} || Home Team: {2}", moduleId, awaySolve, homeSolve);

			//This line avoids complications with the Team Selection screens.
			if (awaySolve == 25)
			{
					awaySolve = 24;
			}

			//If the teams are the same!
			if (awaySolve == homeSolve)
			{
					awaySolve = 24;
					homeSolve = 25;
					Debug.LogFormat("[Blaseball #{0}] The teams are the same! The special rule is applied.", moduleId);
					Debug.LogFormat("[Blaseball #{0}] The Away Team is {1}. The Home Team is {2}.", moduleId, teamOptions[awaySolve], teamOptions[homeSolve]);
			}

			//Account for teams with "The" in their names
			else if (awaySolve == 24 || awaySolve == 25)
			{
					Debug.LogFormat("[Blaseball #{0}] The Away Team is {1}. The Home Team is the {2}.", moduleId, teamOptions[awaySolve], teamOptions[homeSolve]);
			}

			//Otherwise...
			else
			{
					Debug.LogFormat("[Blaseball #{0}] The Away Team is the {1}. The Home Team is the {2}.", moduleId, teamOptions[awaySolve], teamOptions[homeSolve]);
			}

	}



	// ------

	// FUNCTIONS

	// ------

	void StateValues()
	{
		//States the current Away and Home Team values.
			Debug.LogFormat("[Blaseball #{0}] Away Team: {1} || Home Team: {2}", moduleId, awaySolve, homeSolve);
			Debug.LogFormat("[Blaseball #{0}] ---", moduleId);
	}



	// ------

	// BUTTON LOGIC

	// ------

	void PressButtonLeftAway()
	{
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);

		if (awayTeamMenu == 0)
		{
				awayTeamMenu = 26;
		}

		else
		{
				awayTeamMenu = awayTeamMenu - 1;
		}

		awayTeamSelectedSolve = trueTeamSelected[awayTeamMenu];

		ChangeAwayText();

	}

	// ---

	void PressButtonRightAway()
	{
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);

		if (awayTeamMenu == 26)
		{
				awayTeamMenu = 0;
		}

		else
		{
				awayTeamMenu = awayTeamMenu + 1;
		}

		awayTeamSelectedSolve = trueTeamSelected[awayTeamMenu];

		ChangeAwayText();

	}

	// ---

	void ChangeAwayText()
	{
			awayTeam.text = awayTeamSelected[awayTeamMenu];
			awayTeam.color = teamColors[awayTeamMenu];
			awayTeam.fontSize = teamFontSize[awayTeamMenu];
	}

	// ---

	void PressButtonLeftHome()
	{
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);

		if (homeTeamMenu == 0)
		{
				homeTeamMenu = 26;
		}

		else
		{
				homeTeamMenu = homeTeamMenu - 1;
		}

		homeTeamSelectedSolve = trueTeamSelected[homeTeamMenu];

		ChangeHomeText();

	}

	// ---

	void PressButtonRightHome()
	{
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);

		if (homeTeamMenu == 26)
		{
				homeTeamMenu = 0;
		}

		else
		{
				homeTeamMenu = homeTeamMenu + 1;
		}

		homeTeamSelectedSolve = trueTeamSelected[homeTeamMenu];

		ChangeHomeText();

	}

	// ---

	void ChangeHomeText()
	{
			homeTeam.text = homeTeamSelected[homeTeamMenu];
			homeTeam.color = teamColors[homeTeamMenu];
			homeTeam.fontSize = teamFontSize[homeTeamMenu];
	}

	// ---

	void PressButtonSubmit()
	{
			buttonSubmit.AddInteractionPunch(.5f);
			GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);

			if (moduleSolved == true)
			{
					return;
			}

			Debug.LogFormat("[Blaseball #{0}] ---", moduleId);
			Debug.LogFormat("[Blaseball #{0}] The submit button was pressed!", moduleId);
			Debug.LogFormat("[Blaseball #{0}] Away Team: {1} || Home Team: {2}", moduleId, awayTeamSelected[awayTeamMenu], homeTeamSelected[homeTeamMenu]);

			if (awayTeamSelectedSolve == awaySolve && homeTeamSelectedSolve == homeSolve)
			{
					moduleSolved = true;
					GetComponent<KMBombModule>().HandlePass();
					Debug.LogFormat("[Blaseball #{0}] Module solved. PLAY BLALL!", moduleId);
			}

			else
			{
					GetComponent<KMBombModule>().HandleStrike();
					Debug.LogFormat("[Blaseball #{0}] Incorrect submission.", moduleId);
			}

	}

}
