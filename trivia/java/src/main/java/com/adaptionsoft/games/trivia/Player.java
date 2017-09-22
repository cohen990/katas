package com.adaptionsoft.games.trivia;

public class Player {
    private int gold;
    private final String name;

    public Player(String name) {
        this.name = name;
    }

    public int getGold() {
        return gold;
    }

    public void giveReward() {
        gold += 1;
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        return name;
    }
}
