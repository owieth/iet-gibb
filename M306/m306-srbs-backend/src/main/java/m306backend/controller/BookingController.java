package m306backend.controller;

import m306backend.exception.ResourceNotFoundException;
import m306backend.model.BookingModel;
import m306backend.repository.BookingRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

/*
	Controllerclass handling requests
	@author Winkler Olivier, INF5J, 2019
 */

@RestController
@CrossOrigin
public class BookingController {

    @Autowired
    private BookingRepository bookingRepository;

    /*
        Returns a list with all bookings found in the hibernate database.
        @return List
     */
    @GetMapping("/bookings")
    @ResponseBody
    public List<BookingModel> getAllBookings() {
        return bookingRepository.findAll();
    }

    /*
        Returns a single booking found by id
        @return BookingModel
     */
    @GetMapping("/bookings/{id}")
    public BookingModel getNoteById(@PathVariable(value = "id") long id) throws ResourceNotFoundException {
        return bookingRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException(id));
    }

    /*
        Creates a new booking
        @return BookingModel
     */
    @PostMapping("/bookings/create")
    public BookingModel createBooking(@Valid @RequestBody BookingModel bookingModel) {
        return bookingRepository.save(bookingModel);
    }

    /*
        Updates a specific booking
        @return BookingModel
     */
    @PutMapping("/bookings/{id}")
    public BookingModel updateNote(@PathVariable(value = "id") long id, @Valid @RequestBody BookingModel booking) throws ResourceNotFoundException {
        BookingModel bookingModel = bookingRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException(id));

        bookingModel.setBookingTime(booking.getBookingTime());
        bookingModel.setRoom(booking.getRoom());
        bookingModel.setENumber(booking.getENumber());

        return bookingRepository.save(bookingModel);
    }

    /*
        Deletes a booking with id
        @return ResponseEntitiy
     */
    @DeleteMapping("/bookings/{id}")
    public ResponseEntity<?> deleteBook(@PathVariable(value = "id") long id) throws ResourceNotFoundException {
        BookingModel bookingModel = bookingRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException(id));

        bookingRepository.delete(bookingModel);
        return ResponseEntity.ok().build();
    }
}
