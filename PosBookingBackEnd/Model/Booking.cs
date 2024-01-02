using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PosBookingBackEnd.Model
{
    public class Booking : INotifyPropertyChanged
    {
        private int id;
        private BookingType type;
        private DateTime startTime;
        private DateTime endTime;
        private string customerName;
        private string customerPhone;
        private string note;
        public int Id 
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public required BookingType Type 
        {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        public required DateTime StartTime 
        {
            get
            {
                return startTime;
            }
            set
            {
                if (startTime != value) 
                { 
                    startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                } 
            }
        }
        public required DateTime EndTime 
        {
            get
            {
                return endTime;
            }
            set
            {
                if(endTime != value)
                {
                    endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }
        public required string CustomerName 
        {
            get
            {
                return customerName;
            }
            set
            {
                if(customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }
        public string? CustomerPhone
        {
            get
            {
                return customerPhone;
            }
            set
            {
                if(customerPhone != value)
                {
                    customerPhone = value;
                    OnPropertyChanged(nameof(CustomerPhone));
                }
            }
        }
        public string? Note { get; set; }
        public TimeSpan Duration { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
