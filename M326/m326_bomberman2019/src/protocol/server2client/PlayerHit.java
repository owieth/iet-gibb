package protocol.server2client;

import network.Message;

public class PlayerHit implements Message {
  private String playerName;

  public PlayerHit(String playerName) {
    this.playerName = playerName;
  }

  public String getPlayerName() {
    return playerName;
  }
}
