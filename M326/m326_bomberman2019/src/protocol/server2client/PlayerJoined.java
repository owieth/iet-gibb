package protocol.server2client;

import network.Message;

/**
 * Diese Meldung wird vom Server an alle bereits im Spiel angemeldeten Spieler gesendet,
 * sobald sich ein neuer Spieler angemeldet hat und die n�tige Anzahl der Spieler noch
 * nicht �berschritten ist. Diese Meldung wird auch zur Best�tigung an den neu angemeldeten
 * Spieler gesendet.
 * Die Meldung enth�lt den Spielernamen des neu angemeldeten Spielers und seine
 * Startposition auf dem Spielfeld.
 * 
 * @author Andres Scheidegger
 *
 */
public class PlayerJoined implements Message {
  private String playerName;
  private int initialX;
  private int initialY;

  public PlayerJoined(String playerName, int initialX, int initialY) {
    this.playerName = playerName;
    this.initialX = initialX;
    this.initialY = initialY;
  }

  public String getPlayerName() {
    return playerName;
  }
  public int getInitialPositionX() {
    return initialX;
  }

  public int getInitialPositionY() {
    return initialY;
  }
}
