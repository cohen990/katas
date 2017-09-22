package com.adaptionsoft.games.uglytrivia;

import com.adaptionsoft.games.trivia.Player;
import com.adaptionsoft.games.trivia.Players;

import java.util.LinkedList;

public class Game {
    Players players = new Players();
    int[] places = new int[6];
    boolean[] inPenaltyBox  = new boolean[6];
    
    LinkedList popQuestions = new LinkedList();
    LinkedList scienceQuestions = new LinkedList();
    LinkedList sportsQuestions = new LinkedList();
    LinkedList rockQuestions = new LinkedList();
    
    int currentPlayer = 0;
    boolean isGettingOutOfPenaltyBox;
    
    public  Game(){
    	this.players = new Players();
    	for (int i = 0; i < 50; i++) {
			popQuestions.addLast("Pop Question " + i);
			scienceQuestions.addLast(("Science Question " + i));
			sportsQuestions.addLast(("Sports Question " + i));
			rockQuestions.addLast(createRockQuestion(i));
    	}
    }

	public Game(Player... players) {
		this();
		addAll(players);
	}

	private void addAll(Player[] players) {
    	for(int i = 0; i < players.length; i++){
    		add(players[i]);
		}
	}

	public String createRockQuestion(int index){
		return "Rock Question " + index;
	}

	public boolean add(String playerName) {
		add(new Player(playerName));
		return true;
	}

	private void add(Player player) {
		players.add(player);
		places[howManyPlayers()] = 0;
		inPenaltyBox[howManyPlayers()] = false;

		reportPlayerAdded(player.getName(), howManyPlayers());
	}

	private void reportPlayerAdded(String playerName, int playerNumber) {
		System.out.println(playerName + " was added");
		printPlayerNumber(playerNumber);
	}

    public int howManyPlayers() {
		return players.count();
	}

	public void roll(int roll) {
        printCurrentPlayer();
        printCurrentRoll(roll);

		if (!isInPenaltyBox() || !tryToGetOutOfPenaltyBox(roll))
			executePlayerTurn(roll);
	}

	private boolean tryToGetOutOfPenaltyBox(int roll) {
		if (!isGettingOutOfPenaltyBox(roll)) {
            printIsNotGettingOutOfPenaltyBox();
            markCurrentPlayerAsNotGettingOutOfPenaltyBox();
			return true;
        }

		markCurrentPlayerAsGettingOutOfPenaltyBox();
		printIsGettingOutOfPenaltyBox();
		return false;
	}

	private void executePlayerTurn(int roll) {
        movePlayer(roll);
        printUpdatedPosition();
        printCurrentCategory();
        askQuestion();
    }

    private boolean isInPenaltyBox() {
        return inPenaltyBox[currentPlayer];
    }

    private boolean isGettingOutOfPenaltyBox(int roll) {
        return roll % 2 != 0;
    }

    private void printCurrentRoll(int roll) {
        System.out.println("They have rolled a " + roll);
    }

    private void printCurrentPlayer() {
        System.out.println(currentPlayer() + " is the current player");
    }

    private void markCurrentPlayerAsGettingOutOfPenaltyBox() {
        isGettingOutOfPenaltyBox = true;
    }

    private void markCurrentPlayerAsNotGettingOutOfPenaltyBox() {
        isGettingOutOfPenaltyBox = false;
    }

    private void printIsNotGettingOutOfPenaltyBox() {
        System.out.println(currentPlayer().getName() + " is not getting out of the penalty box");
    }

    private void printIsGettingOutOfPenaltyBox() {
        System.out.println(currentPlayer() + " is getting out of the penalty box");
    }

    private void movePlayer(int roll) {
        places[currentPlayer] = places[currentPlayer] + roll;
        if (places[currentPlayer] > 11)
            places[currentPlayer] = places[currentPlayer] - 12;
    }

    private void askQuestion() {
		if (currentCategory() == "Pop")
			System.out.println(popQuestions.removeFirst());
		if (currentCategory() == "Science")
			System.out.println(scienceQuestions.removeFirst());
		if (currentCategory() == "Sports")
			System.out.println(sportsQuestions.removeFirst());
		if (currentCategory() == "Rock")
			System.out.println(rockQuestions.removeFirst());
	}
	
	private String currentCategory() {
		if (places[currentPlayer] == 0) return "Pop";
		if (places[currentPlayer] == 4) return "Pop";
		if (places[currentPlayer] == 8) return "Pop";
		if (places[currentPlayer] == 1) return "Science";
		if (places[currentPlayer] == 5) return "Science";
		if (places[currentPlayer] == 9) return "Science";
		if (places[currentPlayer] == 2) return "Sports";
		if (places[currentPlayer] == 6) return "Sports";
		if (places[currentPlayer] == 10) return "Sports";
		return "Rock";
	}

	public boolean wasCorrectlyAnswered() {
		if (shouldSkipTurn()) {
            moveToNextPlayersTurn();
				return true;
		}

		return answerCorrectly();
	}

    private boolean answerCorrectly() {
        printCorrectAnswerConfirmation();
        rewardPlayerForCorrectAnswer();

        boolean isWinner = playerIsWinner();
        moveToNextPlayersTurn();
        return isWinner;
    }

	private boolean shouldSkipTurn() {
		return isInPenaltyBox() &&
			!isGettingOutOfPenaltyBox;
	}

	public void answerIncorrectly(){
		printIncorrectAnswerConfirmation();
		putCurrentPlayerInPenaltyBox();
		moveToNextPlayersTurn();
	}

	private void putCurrentPlayerInPenaltyBox() {
		System.out.println(currentPlayer() + " was sent to the penalty box");
		inPenaltyBox[currentPlayer] = true;
	}

	private void moveToNextPlayersTurn() {
		currentPlayer++;
		if (currentPlayer == players.count())
		    currentPlayer = 0;
	}

	private boolean playerIsWinner() {
		return currentPlayer().getGold() != 6;
	}

	private void rewardPlayerForCorrectAnswer() {
		currentPlayer().giveReward();
		printGoldAmount();
	}

    private Player currentPlayer() {
        return players.get(currentPlayer);
    }

    private void printGoldAmount() {
		System.out.println(currentPlayer()
                + " now has "
                + currentPlayer().getGold()
                + " Gold Coins.");
	}

	private void printCorrectAnswerConfirmation() {
		System.out.println("Answer was correct!!!!");
	}

	private void printIncorrectAnswerConfirmation() {
		System.out.println("Question was incorrectly answered");
	}

    private void printUpdatedPosition() {
        System.out.println(currentPlayer().getName()
                + "'s new location is "
                + places[currentPlayer]);
    }

    private void printCurrentCategory() {
        System.out.println("The category is " + currentCategory());
    }

    private void printPlayerNumber(int playerNumber) {
        System.out.println("They are player number " + playerNumber);
    }
}
