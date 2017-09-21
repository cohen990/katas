
package com.adaptionsoft.games.trivia.runner;
import java.util.Random;

import com.adaptionsoft.games.uglytrivia.Game;


public class GameRunner {

	private static boolean notAWinner;

	public static void main(String[] args) {
		banana(new Random());
	}

	protected static void banana(Random rand) {
		Game game = new Game();

		game.add("Chet");
		game.add("Pat");
		game.add("Sue");

		do {
			game.roll(getRoll(rand));

			if (rand.nextInt(9) == 7) {
				notAWinner = game.wrongAnswer();
			} else {
				notAWinner = game.wasCorrectlyAnswered();
			}
		} while (notAWinner);
	}

	private static int getRoll(Random rand) {
		return rand.nextInt(5) + 1;
	}
}
