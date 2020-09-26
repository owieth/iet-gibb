package protocol.server2client;

import network.Message;

/**
 * Diese Meldung wird vom Server an alle Clients gesendet, sobald gen�gend Spieler angemeldet
 * sind und das Spiel los geht.
 * 
 * @author Andres Scheidegger
 *
 */
public class StartGame implements Message {
  private char[][] map;

  public StartGame(char[][] map) {
    this.map = map;
  }

  public char[][] getMap() {
    return map;
  }
}
