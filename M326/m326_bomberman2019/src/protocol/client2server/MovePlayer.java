package protocol.client2server;

import protocol.Direction;

public class MovePlayer extends ClientMessage {
  private Direction direction;

  public MovePlayer(String playerName, Direction direction) {
    super(playerName);
    this.direction = direction;
  }

  public Direction getDirection() {
    return direction;
  }
}
