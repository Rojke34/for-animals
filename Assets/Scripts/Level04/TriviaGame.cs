using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaGame : MonoBehaviour {

	public GameObject trivia;

	public Text question;
	public Button answerOne;
	public Button answerTwo;
	public Button answerThree;
	public Button answerFour;

	private string currentAnswer;
	private int index = 0;

	List<Question> questionsList;

	private int numberOfIntents = 4;

	// Use this for initialization
	void Start () {
		questionsList = new List<Question> ();
		PrepareList ();

		StartTrivia ();
	}

	void StartTrivia() {
		Question currentQuestion = questionsList[index];

		//Store the current answer
		currentAnswer = currentQuestion.answer;

		//Get the options
		string[] options = currentQuestion.options;

		//Get the current question
		string qa = currentQuestion.question;

		//set the question to text gameobject
		question.text = qa;

		//set the 1 op to button;
		answerOne.GetComponentInChildren<Text>().text = options[0];

		//set the 2 op to button;
		answerTwo.GetComponentInChildren<Text>().text = options[1];

		//set the 3 op to button;
		answerThree.GetComponentInChildren<Text>().text = options[2];

		//set the 4 op to button;
		answerFour.GetComponentInChildren<Text>().text = options[3];
	}

	public void FunctionOne () {
		string tx = answerOne.GetComponentInChildren<Text> ().text;

		ValidateOptionSelected (tx);
	}

	public void FunctionTwo () {
		string tx = answerTwo.GetComponentInChildren<Text> ().text;

		ValidateOptionSelected (tx);
	}

	public void FunctionThree () {
		string tx = answerThree.GetComponentInChildren<Text> ().text;

		ValidateOptionSelected (tx);
	}

	public void FunctionFour () {
		string tx = answerFour.GetComponentInChildren<Text> ().text;

		ValidateOptionSelected (tx);
	}

	void ValidateOptionSelected(string tx) {
		if (tx == currentAnswer) {
			
			//Subir el slider
			Debug.Log("Good");
			FindObjectOfType<GameManager> ().PointUp ();
		} else {
			//remover una vida
			numberOfIntents -= 1;

			if(numberOfIntents <= 0) {
				HideTrivia ();
				FindObjectOfType<GameManager> ().EndGame ();
			}

			Debug.Log("Bad");
		}

		if (index < questionsList.Count - 1) {
			NextQuestion ();
		} else {
			Debug.Log ("Se acabo");
			HideTrivia ();
			FindObjectOfType<GameManager> ().CompleteLevel ();
		}
	}

	void HideTrivia() {
		trivia.SetActive (false);
	}

	void NextQuestion() {
		index += 1;

		StartTrivia ();
	}

	void PrepareList() {
		string[] op01 = {"Papel y Cartón", "Plásticos", "Residuos Peligrosos", "Desechos de comida"};
		questionsList.Add(new Question("¿Qué elementos deben ir en la caneca de color Azul?", op01, "Plásticos"));

		string[] op02 = {"Papel y Cartón", "Vidrios", "Residuos Peligrosos", "Desechos de comida"};
		questionsList.Add(new Question("¿Qué elementos deben ir en la caneca de color Verde?", op02, "Desechos de comida"));

		string[] op03 = {"Papel y Cartón", "Vidrios", "Residuos Peligrosos", "Desechos de comida"};
		questionsList.Add(new Question("¿Qué elementos deben ir en la caneca de color Rojo?", op03, "Residuos Peligrosos"));

		string[] op04 = {"Papel y Cartón", "Vidrios", "Residuos Peligrosos", "Desechos de comida"};
		questionsList.Add(new Question("¿Qué elementos deben ir en la caneca de color Blanco?", op04, "Vidrios"));

		string[] op05 = {"Papel y Cartón", "Vidrios", "Residuos Peligrosos", "Desechos de comida"};
		questionsList.Add(new Question("¿Qué elementos deben ir en la caneca de color Gris?", op05, "Papel y Cartón"));

		string[] op06 = {"Mi perro", "Un niño", "Un adulto", "Mi mascota"};
		questionsList.Add(new Question("¿Quién debe manipular los desechos peligrosos?", op06, "Un adulto"));

		string[] op07 = {"Rojo", "Blanco", "Azul", "Verde"};
		questionsList.Add(new Question("¿De qué color es la caneca para Residuos de Plásticos?", op07, "Azul"));
	}
}
