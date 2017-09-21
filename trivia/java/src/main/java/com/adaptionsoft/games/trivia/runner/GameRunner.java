package com.adaptionsoft.games.trivia.runner;
import java.util.Random;

import com.adaptionsoft.games.uglytrivia.Game;


public class GameRunner {

	private static Random random;

	public static void main(String[] args) {
		banana(new Random());
	}

	protected static void banana(Random random) {
		GameRunner.random = random;
		Game game = new Game();

		game.add("Chet");
		game.add("Pat");
		game.add("Sue");

		playGame(game);
	}

	private static void playGame(Game game) {
		while (playTurn(game));
	}

    private static Boolean playTurn(Game game) {
        game.roll(getRoll());
        return evaluateGameState(game);
    }

	private static int getRoll() {
		return random.nextInt(5) + 1;
	}

    private static boolean evaluateGameState(Game game) {
		if (answerIsIncorrect())
            return game.wrongAnswer();

        return game.wasCorrectlyAnswered();
	}

    private static boolean answerIsIncorrect() {
        return random.nextInt(9) == 7;
    }
}
