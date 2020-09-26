package m306backend.repository;

import m306backend.model.BookingModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/*
	Class for Spring's own connection to hibernate
	@author Winkler Olivier, INF5J, 2019
 */

@Repository
public interface BookingRepository extends JpaRepository<BookingModel, Long> {

}
