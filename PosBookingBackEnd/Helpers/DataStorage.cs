using PosBookingBackEnd.Model;
using PosBookingBackEnd.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PosBookingBackEnd.Helpers
{
    public class DataStorage
    {
        List<Booking> bookings = new List<Booking>();
        List<BookingType> bookingTypes = new List<BookingType>();
        
        string bookingPath = "JsonStorage/bookings.json";
        string bookingTypePath = "JsonStorage/bookingTypes.json";
        public List<Booking> Bookings
        {
            get
            {
                return bookings;
            }
            set
            {
                if(bookings != value)
                {
                    bookings = value;
                }
            }
        }
        public List<BookingType> BookingTypes
        {
            get { return bookingTypes; }
            set
            {
                if(bookingTypes != value)
                {
                    bookingTypes = value;
                }
            }
        }
        

        public DataStorage()
        {
            
            if (File.Exists(bookingTypePath))
            {
                BookingTypes = getBookingTypes();
            }
            else
            {
                initBookingTypes();
            }

            if (File.Exists(bookingPath))
            {
                Bookings = getBookings();
            }
            else
            {
                initBookings();
            }
            
            
        }
        private void initBookings()
        {
            List<Booking> bookingList = new List<Booking>();
            

            BookingType Perm = new BookingType { Id = 1, Name = "Perm" };
            BookingType HairCut = new BookingType { Id = 2, Name = "Haircut" };
            BookingType HairColouring = new BookingType { Id = 3, Name = "Hair Colouring" };

            Bookings.Add(new Booking { CustomerName = "Peter Sørensen", CustomerPhone = "45789856", StartTime = new DateTime(2023, 12, 29, 9, 30, 0), EndTime = new DateTime(2023, 12, 29, 11, 0, 0), Id = 1, Type = Perm, Note = "perm note test" });
            Bookings.Add(new Booking { CustomerName = "Anni Andersen", CustomerPhone = "32165478", StartTime = new DateTime(2023, 12, 29, 8, 30, 0), EndTime = new DateTime(2023, 12, 29, 9, 30, 0), Id = 2, Type = HairCut, Note = "HairCut note test" });
            Bookings.Add(new Booking { CustomerName = "Lars Andersen", CustomerPhone = "25896314", StartTime = new DateTime(2023, 12, 29, 11, 00, 0), EndTime = new DateTime(2023, 12, 29, 12, 0, 0), Id = 3, Type = HairColouring, Note = "HairColouring note test" });
            Bookings.Add(new Booking { CustomerName = "Jørgen Petersen", CustomerPhone = "98765432", StartTime = new DateTime(2023, 12, 29, 13, 30, 0), EndTime = new DateTime(2023, 12, 29, 15, 0, 0), Id = 4, Type = Perm, Note = "perm note test 2" });
            Bookings.Add(new Booking { CustomerName = "Julie Jørgensen", CustomerPhone = "13245678", StartTime = new DateTime(2023, 12, 29, 15, 0, 0), EndTime = new DateTime(2023, 12, 29, 16, 0, 0), Id = 5, Type = HairCut, Note = "HairCut note test 2" });
            Bookings.Add(new Booking { CustomerName = "Ida Clausen", CustomerPhone = "46578912", StartTime = new DateTime(2023, 12, 28, 9, 30, 0), EndTime = new DateTime(2023, 12, 28, 11, 0, 0), Id = 6, Type = HairColouring, Note = "HairColouring note test 2" });
            Bookings.Add(new Booking { CustomerName = "Mads Poulsen", CustomerPhone = "64579853", StartTime = new DateTime(2023, 12, 28, 8, 30, 0), EndTime = new DateTime(2023, 12, 28, 9, 30, 0), Id = 7, Type = Perm, Note = "perm note test 3" });
            Bookings.Add(new Booking { CustomerName = "Frederik Hansen", CustomerPhone = "55441122", StartTime = new DateTime(2023, 12, 28, 11, 00, 0), EndTime = new DateTime(2023, 12, 28, 12, 0, 0), Id = 8, Type = HairCut, Note = "HairCut note test 3" });
            Bookings.Add(new Booking { CustomerName = "Irene Nielsen", CustomerPhone = "99885522", StartTime = new DateTime(2023, 12, 28, 13, 30, 0), EndTime = new DateTime(2023, 12, 28, 15, 0, 0), Id = 9, Type = HairColouring, Note = "HairColouring note test 3" });
            Bookings.Add(new Booking { CustomerName = "Inger Juhl", CustomerPhone = "44226655", StartTime = new DateTime(2023, 12, 28, 15, 30, 0), EndTime = new DateTime(2023, 12, 28, 16, 0, 0), Id = 10, Type = Perm, Note = "perm note test 4" });

            Bookings.Add(new Booking { CustomerName = "Peter Sørensen", CustomerPhone = "45789856", StartTime = new DateTime(2024, 1, 1, 9, 30, 0), EndTime = new DateTime(2024, 1, 1, 11, 0, 0), Id = 11, Type = Perm, Note = "perm note test" });
            Bookings.Add(new Booking { CustomerName = "Anni Andersen", CustomerPhone = "32165478", StartTime = new DateTime(2024, 1, 1, 8, 30, 0), EndTime = new DateTime(2024, 1, 1, 9, 30, 0), Id = 12, Type = HairCut, Note = "HairCut note test" });
            Bookings.Add(new Booking { CustomerName = "Lars Andersen", CustomerPhone = "25896314", StartTime = new DateTime(2024, 1, 1, 11, 00, 0), EndTime = new DateTime(2024, 1, 1, 12, 0, 0), Id =13, Type = HairColouring, Note = "HairColouring note test" });
            Bookings.Add(new Booking { CustomerName = "Jørgen Petersen", CustomerPhone = "98765432", StartTime = new DateTime(2024, 1, 1, 13, 30, 0), EndTime = new DateTime(2024, 1, 1, 15, 0, 0), Id = 14, Type = Perm, Note = "perm note test 2" });
            Bookings.Add(new Booking { CustomerName = "Julie Jørgensen", CustomerPhone = "13245678", StartTime = new DateTime(2024, 1, 1, 15, 0, 0), EndTime = new DateTime(2024, 1, 1, 16, 0, 0), Id = 15, Type = HairCut, Note = "HairCut note test 2" });
            Bookings.Add(new Booking { CustomerName = "Ida Clausen", CustomerPhone = "46578912", StartTime = new DateTime(2024, 1, 2, 9, 30, 0), EndTime = new DateTime(2024, 1, 2, 11, 0, 0), Id = 16, Type = HairColouring, Note = "HairColouring note test 2" });
            Bookings.Add(new Booking { CustomerName = "Mads Poulsen", CustomerPhone = "64579853", StartTime = new DateTime(2024, 1, 2, 8, 30, 0), EndTime = new DateTime(2024, 1, 2, 9, 30, 0), Id = 17, Type = Perm, Note = "perm note test 3" });
            Bookings.Add(new Booking { CustomerName = "Frederik Hansen", CustomerPhone = "55441122", StartTime = new DateTime(2024, 1, 2, 11, 00, 0), EndTime = new DateTime(2024, 1, 2, 12, 0, 0), Id = 18, Type = HairCut, Note = "HairCut note test 3" });
            Bookings.Add(new Booking { CustomerName = "Irene Nielsen", CustomerPhone = "99885522", StartTime = new DateTime(2024, 1, 2, 13, 30, 0), EndTime = new DateTime(2024, 1, 2, 15, 0, 0), Id = 19, Type = HairColouring, Note = "HairColouring note test 3" });
            Bookings.Add(new Booking { CustomerName = "Inger Juhl", CustomerPhone = "44226655", StartTime = new DateTime(2024, 1, 2, 15, 30, 0), EndTime = new DateTime(2024, 1, 2, 16, 0, 0), Id = 20, Type = Perm, Note = "perm note test 4" });

            //Bookings = bookingList;


        }

        private void BookingsTypes_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            SaveBookingTypes();
        }

        private void Bookings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SaveBookings();
        }

        private void initBookingTypes()
        {
            List<BookingType> types = new List<BookingType>();

            BookingType Perm = new BookingType { Id = 1, Name = "Perm" };
            BookingType HairCut = new BookingType { Id = 2, Name = "Haircut" };
            BookingType HairColouring = new BookingType { Id = 3, Name = "Hair Colouring" };

            BookingTypes.Add(Perm);
            BookingTypes.Add(HairCut);
            BookingTypes.Add(HairColouring);

        }

        private List<Booking> getBookings()
        {
            string json = File.ReadAllText(bookingPath);
            return JsonSerializer.Deserialize<List<Booking>>(json);
        }
        private List<BookingType> getBookingTypes()
        {
            string json = File.ReadAllText(bookingTypePath);
            return JsonSerializer.Deserialize<List<BookingType>>(json);
        }
        public void SaveBookings()
        {
            string json = JsonSerializer.Serialize(Bookings);
            
            File.WriteAllText(bookingPath, json);
        }
        public void SaveBookingTypes()
        {
            string json = JsonSerializer.Serialize(BookingTypes);
            
            File.WriteAllText(bookingTypePath, json);
        }
       
    }
}
