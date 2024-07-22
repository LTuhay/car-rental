using System.ComponentModel.DataAnnotations.Schema;

namespace Car_rental.Models.Domain
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped]
        public decimal TotalPrice => CalculateTotalPrice();

        private decimal CalculateTotalPrice()
        {
            if (Car != null)
            {
                int totalDays = (EndDate - StartDate).Days;
                return Car.PricePerDay * totalDays;
            }
            return 0;
        }
    }
}
