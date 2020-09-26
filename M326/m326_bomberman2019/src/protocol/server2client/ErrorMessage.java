package protocol.server2client;

import network.Message;

public class ErrorMessage implements Message {
  private String errorMessage;

  public ErrorMessage(String errorMessage) {
    this.errorMessage = errorMessage;
  }

  public String getErrorMessage() {
    return errorMessage;
  }
}
