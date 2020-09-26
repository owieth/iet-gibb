package m306backend.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/*
	Exception
	@author Winkler Olivier, INF5J, 2019
 */

@ResponseStatus(value = HttpStatus.NOT_FOUND)
public class ResourceNotFoundException extends RuntimeException {

    /*
        Throws an self-made exception
     */
    public ResourceNotFoundException(Long fieldValue) {
        super(String.format("Booking not found with Id : '%s'",fieldValue));
    }
}
