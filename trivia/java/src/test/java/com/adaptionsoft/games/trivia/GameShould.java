package com.adaptionsoft.games.trivia;

import com.adaptionsoft.games.uglytrivia.Game;
import org.junit.Before;
import org.junit.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class GameShould {
    private ByteArrayOutputStream standardOut;
    private Game game;

    @Before
    public void before() {
        standardOut = interceptStandardOut();
        game = new Game();
    }

    @Test
    public void report_adding_the_first_player() {
        add(CHET);

        assertEquals(CHET_ADDED_TEXT, output());
    }

    @Test
    public void report_adding_the_first_two_players() {
        add(CHET);
        add(PAT);

        String expected =
                CHET_ADDED_TEXT +
                PAT_ADDED_TEXT;

        assertEquals(expected, output());
    }

    @Test
    public void start_with_the_first_player_that_was_added() {
        add(CHET);
        add(PAT);

        roll(1);

        String expected =
                CHET_ADDED_TEXT +
                PAT_ADDED_TEXT +
                CHET_ROLLED_A_ONE;

        assertEquals(expected, output());
    }

    @Test
    public void report_correct_answer() {
        add(CHET);

        roll(1);
        answerCorrectly();

        String expected =
                CHET_ADDED_TEXT +
                CHET_ROLLED_A_ONE +
                CHET_ANSWERED_CORRECTLY;

        assertEquals(expected, output());
    }

    @Test
    public void report_incorrect_answer() {
        add(CHET);

        roll(1);
        answerIncorrectly();

        String expected =
                CHET_ADDED_TEXT +
                CHET_ROLLED_A_ONE +
                CHET_ANSWERED_INCORRECTLY;

        assertEquals(expected, output());
    }

    @Test
    public void play_second_turn_with_second_player() {
        add(CHET);
        add(PAT);

        roll(1);
        answerCorrectly();
        roll(3);


        String expected =
                CHET_ADDED_TEXT +
                PAT_ADDED_TEXT +
                CHET_ROLLED_A_ONE +
                CHET_ANSWERED_CORRECTLY +
                PAT_ROLLED_A_THREE;

        assertEquals(expected, output());
    }


    @Test
    public void report_escape_from_penalty_box() {
        add(CHET);

        roll(1);
        answerIncorrectly();
        roll(1);

        String expected =
                CHET_ADDED_TEXT +
                CHET_ROLLED_A_ONE +
                CHET_ANSWERED_INCORRECTLY +
                CHET_ESCAPED_FROM_THE_PENALTY_BOX;

        assertEquals(expected, output());
    }

    private void answerIncorrectly() {
        game.answerIncorrectly();
    }

    @Test
    public void play_through_multiple_turns_for_each_player() {
        add(CHET);
        add(PAT);
        add(SUE);

        playManyTurns(30);

        assertTrue(output().contains(CHET));
        assertTrue(output().contains(PAT));
        assertTrue(output().contains(SUE));
    }

    private String output() {
        return standardOut.toString();
    }

    private void playManyTurns(int numberOfTurns){
        for(int i = 0; i < numberOfTurns; i++){
            roll(1);
            answerCorrectly();
        }
    }

    private boolean answerCorrectly() {
        return game.wasCorrectlyAnswered();
    }

    private boolean add(String chet) {
        return game.add(chet);
    }

    private ByteArrayOutputStream interceptStandardOut() {
        standardOut = new ByteArrayOutputStream();
        System.setOut(new PrintStream(standardOut));
        return standardOut;
    }

    private void roll(int roll) {
        game.roll(roll);
    }

    private static final String CHET = "Chet";
    private static final String PAT = "Pat";
    private static final String SUE = "Sue";

    private static final String CHET_ADDED_TEXT =
            "Chet was added\n" +
            "They are player number 1\n";

    private static final String PAT_ADDED_TEXT =
            "Pat was added\n" +
            "They are player number 2\n";

    private static final String CHET_ROLLED_A_ONE =
            "Chet is the current player\n" +
            "They have rolled a 1\n" +
            "Chet's new location is 1\n" +
            "The category is Science\n" +
            "Science Question 0\n";

    private static final String PAT_ROLLED_A_THREE =
            "Pat is the current player\n" +
            "They have rolled a 3\n" +
            "Pat's new location is 3\n" +
            "The category is Rock\n" +
            "Rock Question 0\n";

    private static final String CHET_ANSWERED_CORRECTLY =
            "Answer was correct!!!!\n" +
            "Chet now has 1 Gold Coins.\n";

    private static final String CHET_ANSWERED_INCORRECTLY =
            "Question was incorrectly answered\n" +
            "Chet was sent to the penalty box\n";

    private static final String CHET_ESCAPED_FROM_THE_PENALTY_BOX =
            "Chet is the current player\n" +
            "They have rolled a 1\n" +
            "Chet is getting out of the penalty box\n" +
            "Chet's new location is 2\n" +
            "The category is Sports\n" +
            "Sports Question 0\n";

}

