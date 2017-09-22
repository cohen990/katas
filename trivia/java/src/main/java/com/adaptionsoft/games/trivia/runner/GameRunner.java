package com.adaptionsoft.games.trivia.runner;
import java.util.Random;

import com.adaptionsoft.games.trivia.Player;
import com.adaptionsoft.games.uglytrivia.Game;


public class GameRunner {

	private static Random random;

	public static void main(String[] args) {
		runGame(new Random());
	}

	protected static void runGame(Random random) {
		GameRunner.random = random;

		Game game = new Game(
			new Player("Chet"),
			new Player("Pat"),
			new Player("Sue"));

		playGame(game);
	}

	private static void playGame(Game game) {
		while (true) {
            if(!playTurn(game)) {
                break;
            }
        };
	}

    private static Boolean playTurn(Game game) {
        game.roll(getRoll());
        return evaluateGameState(game);
    }

	private static int getRoll() {
		return random.nextInt(5) + 1;
	}

    private static boolean evaluateGameState(Game game) {
		if (answerIsCorrect())
            return game.wasCorrectlyAnswered();

        game.answerIncorrectly();
        return true;
	}

    private static boolean answerIsCorrect() {
        return random.nextInt(9) != 7;
    }
}
