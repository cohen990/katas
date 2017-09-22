package com.adaptionsoft.games.trivia;

import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class PlayersShould{
    private static final String CHET = "Chet";
    private static final String PAT = "Pat";
    private static final String SUE = "Sue";

    private Players players;

    @Before
    public void before(){
        players = new Players();
    }

    @Test
    public void have_no_players_when_new(){
        assertEquals(0, players.count());
    }

    @Test
    public void have_one_player_if_one_player_added(){
        players.add(new Player(CHET));
        assertEquals(1, players.count());
    }

    @Test
    public void have_3_players_if_three_added(){
        players.add(new Player(CHET), new Player(PAT), new Player(SUE));
        assertEquals(3, players.count());
    }

    @Test
    public void returns_first_player_when_asked_for_first_player(){
        Player chet = new Player(CHET);
        Player pat = new Player(PAT);
        Player sue = new Player(SUE);
        players.add(chet);
        players.add(pat);
        players.add(sue);

        assertEquals(chet, players.get(0));
    }
    @Test
    public void returns_second_player_when_asked_for_second_player(){
        Player chet = new Player(CHET);
        Player pat = new Player(PAT);
        Player sue = new Player(SUE);
        players.add(chet);
        players.add(pat);
        players.add(sue);

        assertEquals(pat, players.get(1));
    }
    @Test
    public void returns_third_player_when_asked_for_third_player(){
        Player chet = new Player(CHET);
        Player pat = new Player(PAT);
        Player sue = new Player(SUE);
        players.add(chet);
        players.add(pat);
        players.add(sue);

        assertEquals(sue, players.get(2));
    }
}
