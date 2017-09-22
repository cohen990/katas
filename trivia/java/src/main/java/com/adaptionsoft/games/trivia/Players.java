package com.adaptionsoft.games.trivia;

import java.util.ArrayList;

public class Players {
    private ArrayList<Player> players;

    public Players() {
        players = new ArrayList<Player>();
    }

    public int count() {
        return players.size();
    }

    public void add(Player player) {
        players.add(player);
    }

    public Player get(int i) {
        return players.get(i);
    }

    public void add(Player... players) {
        for (Player player: players) {
            add(player);
        }
    }
}
