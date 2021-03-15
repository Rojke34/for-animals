using UnityEngine;
using System.Collections;

public class Question {
	public string question;
	public string[] options;
	public string answer;

	public Question(string _question, string[] _options, string _answer) {
		question = _question;
		options = _options;
		answer = _answer;
	}
}