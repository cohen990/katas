package com.adaptionsoft.games.trivia;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class PlayerShould {
    private static final String CHET = "Chet";

    @Test
    public void return_correct_name_when_asked(){
        Player player = new Player(CHET);
        assertEquals(CHET, player.getName());
    }

    @Test
    public void have_no_gold_when_initialized(){
        Player player = new Player(CHET);
        assertEquals(0, player.getGold());
    }

    @Test
    public void increment_gold_when_rewarded(){
        Player player = new Player(CHET);
        player.giveReward();

        assertEquals(1, player.getGold());
    }
}
