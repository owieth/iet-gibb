package m306backend.model;

import lombok.Data;

import javax.persistence.*;
import java.util.Date;

/*
	Model of a booking
	@author Winkler Olivier, INF5J, 2019
 */

@Entity // This tells Hibernate to make a table out of this class
@Table(name = "bookings")
@Data
public class BookingModel {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;

    private Date bookingTime;

    private Date bookingEndTime;

    private String room;

    private String eNumber;
}
